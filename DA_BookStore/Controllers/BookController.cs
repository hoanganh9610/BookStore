using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Detail(string id)
        {
            if (Session["bookEdit"] != null && Session["bookID"].ToString() != id)
                Session["bookEdit"] = null;
            using (var db = new Models.BookStore())
            {
                Session["bookID"] = id;

                ViewBag.id = id;
                Models.TRANH s = db.SACHes.Where(t => t.MaSach == id).FirstOrDefault();

                if (s.HienThiS == false)
                    return RedirectToAction("Home","Home");

                ViewBag.Sach = s;
                ViewBag.MSach = s.MaSach;
                ViewBag.Hinh = s.HinhSach;

                Models.KHUYENMAI km = db.KHUYENMAIs.Where(t => t.MaKhuyenMai == s.MaKhuyenMai).FirstOrDefault();
                if (km != null)
                {
                    ViewBag.KhuyenMai = km;

                    ViewBag.TietKiem = s.GiaBan * (km.PhanTramKhuyenMai * 0.01);
                    ViewBag.GiaBanHienTai = s.GiaBan * ((100 - km.PhanTramKhuyenMai) * 0.01);
                }

                ViewBag.DsTL = db.THELOAIs.ToList();
                if (Session["userID"] != null)
                {
                    db.CTXEMSACHes.Add(new Models.CTXEMSACH() { MaSach = id, TenTaiKhoan = Session["userID"].ToString(), NgayXemSach = DateTime.Now });
                    db.SaveChanges();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Detail(string tenSach, string tacGia, string sku, string giaBan, string gioiThieuSach, HttpPostedFileBase hinh)
        {
            using (var db = new Models.BookStore())
            {
                Models.TRANH s = db.SACHes.Find(Session["bookID"]);
                s.TenSach = tenSach;
                s.TenTacGia = tacGia;
                s.SKU = sku;
                s.GiaBan = int.Parse(giaBan);
                s.GioiThieuSach = gioiThieuSach;
                if (hinh != null)
                {
                    try
                    {
                        string _path = "";
                        if (hinh.ContentLength > 0)
                        {
                            string _fileName = System.IO.Path.GetFileName(hinh.FileName);
                            _path = System.IO.Path.Combine(Server.MapPath("~/Image/Book"), _fileName);
                            hinh.SaveAs(_path);
                        }

                        s.HinhSach = "Image/Book/" + hinh.FileName;
                    }
                    catch
                    {

                    }
                }

                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            Session["bookEdit"] = null;
            return RedirectToAction("Detail","Book", new { id = Session["BookID"].ToString() });
        }

        public ActionResult BookEdit(string id)
        {
            Session["bookEdit"] = "sua";
            Detail(id);
            return View("Detail");
        }

        public ActionResult BookDelete(string id)
        {
            using (var db = new Models.BookStore())
            {
                Models.TRANH s = db.SACHes.Find(id);
                s.HienThiS = false;
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("BookManage","Book");
        }
        [HttpGet]
        public ActionResult BookManage()
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.TRANH> lst = db.SACHes.Where(t => t.HienThiS == true).ToList();
                    ViewBag.DsS = lst;
                    ViewBag.slS = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Home","Home");
        }

        [HttpPost]
        public ActionResult BookManage(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    List<Models.TRANH> lst = db.SACHes.Where(t => t.HienThiS == true && t.TenSach.Contains(id)).ToList();
                    ViewBag.DsS = lst;
                    ViewBag.slS = lst.Count();
                }

                return View();
            }
            return RedirectToAction("Home","Home");
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                }

                return View();
            }
            return RedirectToAction("Home","Home");
        }

        [HttpPost]
        public ActionResult AddBook(string tenSach, string tacGia, string sku, string giaBan, string gioiThieuSach, HttpPostedFileBase hinh)
        {
            using (var db = new Models.BookStore())
            {
                Models.TRANH s = new Models.TRANH();
                int slS = db.SACHes.ToList().Count() + 1;

                var maSach = "S" + slS.ToString().PadLeft(9, '0');

                s.MaSach = maSach;
                s.TenSach = tenSach;
                s.TenTacGia = tacGia;
                s.SKU = sku;
                s.GiaBan = int.Parse(giaBan);
                s.GioiThieuSach = gioiThieuSach;
                s.MaNhaCungCap = "NCC0000001";
                s.MaNhaXuatBan = "NXB0000001";
                s.SoLanTruyCap = 0;
                s.SoLuongTon = 100;
                s.NgayXuatBan = DateTime.Today;

                s.HienThiS = true;
                if (hinh != null)
                {
                    try
                    {
                        string _path = "";
                        if (hinh.ContentLength > 0)
                        {
                            string _fileName = System.IO.Path.GetFileName(hinh.FileName);
                            _path = System.IO.Path.Combine(Server.MapPath("~/Image/Book"), _fileName);
                            hinh.SaveAs(_path);
                        }

                        s.HinhSach = "Image/Book/" + hinh.FileName;
                    }
                    catch
                    {

                    }
                }

                db.SACHes.Add(s);
                db.SaveChanges();

                return RedirectToAction("Detail","Book", new { id = maSach });
            }


        }


    }
}