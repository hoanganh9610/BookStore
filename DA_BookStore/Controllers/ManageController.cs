using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class ManageController : Controller
    {

        [HttpGet]
        public ActionResult Manage()
        {

            using (var db = new Models.BookStore())
            {
                if (Session["userID"] == null)
                    return RedirectToAction("Login", "Login");
                ViewBag.DsSachDeal = db.SACHes;
                ViewBag.DsTL = db.THELOAIs.ToList();

                var query = from s in db.SACHes
                            select new { s.MaSach, s.TenSach,s.SKU,s.NHACUNGCAP,s.MaNhaXuatBan,s.MaKhuyenMai,s.GiaBan,s.HinhSach,s.SoLuongTon,s.TenTacGia,s.GioiThieuSach,};

                List<Models.MANAGE> ctgh = new List<Models.MANAGE>();
                foreach (var item in query)
                {
                    Models.MANAGE cttemp = new Models.MANAGE();
                    cttemp.MaSach = item.MaSach;
                    cttemp.TenSach = item.TenSach;
                    cttemp.SKU = item.SKU;
                    cttemp.NHACUNGCAP = item.MaNhaXuatBan;
                    cttemp.MaNhaXuatBan = item.MaNhaXuatBan;
                    cttemp.GiaBan = item.GiaBan;
                    cttemp.MaKhuyenMai = item.MaKhuyenMai;
                    cttemp.HinhSach = item.HinhSach;
                    cttemp.SoLuongTon = item.SoLuongTon;
                    cttemp.TenTacGia = item.TenTacGia;
                    cttemp.GioiThieuSach = item.GioiThieuSach;
                    
                    ctgh.Add(cttemp);
                }

                ViewBag.DsCTGH = ctgh;
            }

            return View();
        }
    }
}