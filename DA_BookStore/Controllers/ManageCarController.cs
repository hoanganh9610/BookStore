using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class ManageCarController : Controller
    {
        //
        // GET: /ManageCar/
        public ActionResult ManageCar()
        {
            using (var db = new Models.BookStore())
            {
                ViewBag.Acc = db.CTGIOHANGs;
                ViewBag.DsTL = db.THELOAIs.ToList();
                var query = from c in db.CTGIOHANGs
                            select new { c.MaSach, c.TenTaiKhoan, c.SoLuongGioHang };

                List<Models.MANAGECAR> ctgh = new List<Models.MANAGECAR>();
                foreach (var item in query)
                {
                    Models.MANAGECAR cttemp = new Models.MANAGECAR();
                    cttemp.MaSach = item.MaSach;
                    cttemp.TenTaiKhoan = item.TenTaiKhoan;
                    cttemp.SoLuonGioHang = item.SoLuongGioHang;
                    ctgh.Add(cttemp);
                }

                ViewBag.DsCAR = ctgh;
            }
            return View();
        }
	}
}