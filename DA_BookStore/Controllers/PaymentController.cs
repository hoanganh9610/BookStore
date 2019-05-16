using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        [HttpGet]
        public ActionResult Payment()
        {
            using (var db = new Models.BookStore())
            {
                ViewBag.DsSachDeal = db.SACHes.Where(t => t.KHUYENMAI.NgayKetThuc > DateTime.Now && t.HienThiS == true).Take(5).ToList();
                ViewBag.DsTL = db.THELOAIs.ToList();
            }

            return View("~/Views/Cart/Payment.cshtml");
        }
        [HttpPost]
        public ActionResult Payment(string id)
        {
            return View();
        }
    }
}