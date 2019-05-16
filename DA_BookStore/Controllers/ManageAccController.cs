using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class ManageAccController : Controller
    {
        //
        // GET: /ManageAcc/
        public ActionResult ManageAcc()
        {

            using (var db = new Models.BookStore())
            {
                ViewBag.Acc = db.TAIKHOANs;
                ViewBag.DsTL = db.THELOAIs.ToList();
                var query = from t in db.TAIKHOANs
                            select new { t.TenTaiKhoan, t.MauKhau, t.HoTen, t.Sdt, t.DiaChi, t.Email };

                List<Models.ManageAcc> ctgh = new List<Models.ManageAcc>();
                foreach (var item in query)
                {
                    Models.ManageAcc cttemp = new Models.ManageAcc();
                    cttemp.TenTaiKhoan = item.TenTaiKhoan;
                    cttemp.MauKhau = item.MauKhau;
                    cttemp.HoTen = item.HoTen;
                    cttemp.Sdt = item.Sdt;
                    cttemp.DiaChi = item.DiaChi;
                    cttemp.Email = item.Email;
                    ctgh.Add(cttemp);
                }

                ViewBag.DsACC = ctgh;
            }

            return View();
        }
	}
}