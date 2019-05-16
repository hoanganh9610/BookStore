using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Account(string id = "", bool edit = false)
        {
            using (var db = new Models.BookStore())
            {
                if (Session["userID"] != null)
                {
                    if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin" && edit)
                    {
                        ViewBag.editMode = 1;
                        Models.TAIKHOAN tk = db.TAIKHOANs.Find(id);
                        ViewBag.TK = tk;
                        Models.NHANVIEN nv = db.NHANVIENs.Find(id);
                        if (nv != null)
                            ViewBag.tkPrio = nv.ChucVuNV;
                    }
                    else
                    {
                        Models.TAIKHOAN tk = db.TAIKHOANs.Find(Session["userID"]);
                        ViewBag.TK = tk;
                    }
                }
                else
                {
                    return RedirectToAction("Home","Home");
                }
                ViewBag.DsTL = db.THELOAIs.ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Account(string id, string pass, string name, string email, string sdt, string sex, string rePass, string prio = "")
        {
            using (var db = new Models.BookStore())
            {
                if (rePass != pass && rePass != "")
                {
                    ViewBag.error = "Mật khẩu nhập không trùng khớp";
                    return RedirectToAction("Account","Account");
                }

                Models.TAIKHOAN tk = db.TAIKHOANs.Find(id);

                if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
                {
                    if (prio == "QuanLy")
                        db.NHANVIENs.Add(new Models.NHANVIEN { TenTaiKhoanNV = id, ChucVuNV = "Manager" });
                    else if (prio == "Admin")
                        db.NHANVIENs.Add(new Models.NHANVIEN { TenTaiKhoanNV = id, ChucVuNV = "Admin" });
                }
                else
                {
                    if (id != Session["userID"].ToString())
                        return RedirectToAction("Home","Home");
                }

                if (pass != "")
                    tk.MauKhau = pass;
                tk.HoTen = name;
                tk.Email = email;
                tk.Sdt = sdt;
                tk.GioiTinh = (sex == "Nam") ? true : false;

                db.SaveChanges();

                ViewBag.DsTL = db.THELOAIs.ToList();
                ViewBag.TK = tk;
            }

            return View();
        }

        public ActionResult DeleteAccount(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    Models.TAIKHOAN tk = db.TAIKHOANs.Find(id);
                    Models.NHANVIEN nv = db.NHANVIENs.Find(id);

                    tk.HienThiTK = false;
                    db.Entry(tk).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                return RedirectToAction("AccountManage","Account");
            }
            return RedirectToAction("Home","Home");
        }

        [HttpGet]
        public ActionResult AccountManage()
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    ViewBag.DsTK = db.TAIKHOANs.Where(t => t.HienThiTK == true).ToList();
                    ViewBag.slTK = db.TAIKHOANs.Where(t => t.HienThiTK == true).ToList().Count();
                    ViewBag.DsNV = db.NHANVIENs.ToList();
                }

                return View();
            }
            return RedirectToAction("Home","Home");
        }
        [HttpPost]
        public ActionResult AccountManage(string id)
        {
            if (Session["userPrio"] != null && Session["userPrio"].ToString() == "Admin")
            {
                using (var db = new Models.BookStore())
                {
                    ViewBag.DsTL = db.THELOAIs.ToList();
                    ViewBag.DsNV = db.NHANVIENs.ToList();

                    ViewBag.DsTK = db.TAIKHOANs.Where(t => t.TenTaiKhoan.Contains(id)).ToList();
                    ViewBag.slTK = db.TAIKHOANs.Where(t => t.TenTaiKhoan.Contains(id)).ToList().Count();
                }

                return View();
            }
            return RedirectToAction("Home","Home");
        }
    }
}