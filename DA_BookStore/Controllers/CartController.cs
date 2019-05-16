using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class CartController : Controller
    {
        public ActionResult GetToCart(int soLuong)
        {

            if (Session["userID"] != null)
            {
                using (var db = new Models.BookStore())
                {
                    Models.CTGIOHANG ct = new Models.CTGIOHANG();
                    ct.MaSach = Session["bookID"].ToString();
                    ct.TenTaiKhoan = Session["userID"].ToString();
                    Models.CTGIOHANG ct2 = db.CTGIOHANGs.Find(ct.MaSach, ct.TenTaiKhoan);
                    if (ct2 != null)
                    {
                        ct2.SoLuongGioHang += short.Parse(soLuong.ToString());
                        db.Entry(ct2).State = EntityState.Modified;
                    }
                    else
                    {
                        ct2 = new Models.CTGIOHANG();
                        ct2.MaSach = ct.MaSach;
                        ct2.TenTaiKhoan = ct.TenTaiKhoan;
                        ct2.SoLuongGioHang = short.Parse(soLuong.ToString());
                        db.CTGIOHANGs.Add(ct2);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("Login","Login");
            }
            return RedirectToAction("Home","Home");
        }
        [HttpGet]
        public ActionResult Cart()
        {
            if (Session["userID"] == null)
                return RedirectToAction("Login","Login");
            using (var db = new Models.BookStore())
            {
                ViewBag.DsSachDeal = db.SACHes.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiS == true).Take(5).ToList();
                ViewBag.DsTL = db.THELOAIs.ToList();
                List<Models.CTGIOHANG> ct = new List<Models.CTGIOHANG>();
                string temp = Session["userID"].ToString();


                var query = from gh in db.CTGIOHANGs
                            join s in db.SACHes on gh.MaSach equals s.MaSach
                            where gh.TenTaiKhoan == temp
                            select new { s.HinhSach, s.TenSach, gh.SoLuongGioHang, s.MaSach,s.MaKhuyenMai,s.GiaBan };

                List<Models.CTGIOHANGViewModel> ctgh = new List<Models.CTGIOHANGViewModel>();
                Models.KHUYENMAI km = new Models.KHUYENMAI();


                foreach (var item in query)
                {
                    Models.CTGIOHANGViewModel cttemp = new Models.CTGIOHANGViewModel();
                    cttemp.HinhSach = item.HinhSach;
                    cttemp.TenSach = item.TenSach;
                    cttemp.SoLuongTon = item.SoLuongGioHang;
                    cttemp.MaSach = item.MaSach;
                    km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == item.MaKhuyenMai).FirstOrDefault();
                    cttemp.GiaBan = item.GiaBan * item.SoLuongGioHang * ((100 - km.PhanTramKhuyenMai) * 0.01);
                    cttemp.TietKiem = item.GiaBan * item.SoLuongGioHang * (km.PhanTramKhuyenMai * 0.01);
                    ctgh.Add(cttemp);
                }

                ViewBag.DsCTGH = ctgh;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Cart(string id)
        {
            return RedirectToAction("Home","Home");
        }
        [HttpGet]
        public ActionResult DeleteItemCart()
        {
            string idSach = Request.QueryString["id"].ToString();
            if (Session["userID"] == null && Session["userID"].Equals(""))
            {
                return RedirectToAction("Login","Login");
            }
            string idKhach = Session["userID"].ToString();
            using (var db = new Models.BookStore())
            {
                var sql = from c in db.CTGIOHANGs
                          where c.MaSach == idSach && c.TenTaiKhoan == idKhach
                          select c;

                var sql2 = sql.FirstOrDefault();
                db.Entry(sql2).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Cart","Cart");
        }

    }
}