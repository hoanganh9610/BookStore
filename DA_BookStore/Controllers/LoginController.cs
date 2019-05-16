using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_BookStore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string id, string matKhau)
        {
            if (id == string.Empty || matKhau == string.Empty)
            {
                if (id == string.Empty)
                    ViewBag.TenKHError = "Vui lòng nhập tên tài khoản";
                if (matKhau == string.Empty)

                    ViewBag.MatKhauError = "Vui lòng nhập Mật khẩu";
                return View("Login");
            }
            else if (id != string.Empty && matKhau != string.Empty)
            {
                using (var db = new Models.BookStore())
                {
                    var temp = db.TAIKHOANs.Where(i => i.TenTaiKhoan == id && i.MauKhau == matKhau).FirstOrDefault();
                    if (temp == null)
                    {
                        ViewBag.AccError = "Thông tin không đúng";
                        return View("Login");
                    }
                    else
                    {
                        Models.TAIKHOAN tk = new Models.TAIKHOAN();
                        tk = db.TAIKHOANs.Find(temp.TenTaiKhoan);
                        Session["userID"] = tk.TenTaiKhoan.ToString();
                        Session["userName"] = tk.HoTen.ToString();
                        Models.NHANVIEN nv = db.NHANVIENs.Find(Session["userID"]);
                        if (nv != null)
                            Session["userPrio"] = nv.ChucVuNV;
                        return RedirectToAction("Home","Home");
                    }
                }
            }
            return RedirectToAction("Home", "Home");
        }
        //Get: DangKy
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string id, string pass, string ten, string email, string sdt, bool sex, string rePass,string diaChi)
        {
            using (var db = new Models.BookStore())
            {
                var temp = db.TAIKHOANs.Where(i => i.TenTaiKhoan == id).FirstOrDefault();
                if (rePass != pass)
                {
                    ViewBag.RePassError = "Mật khẩu không trùng khớp";
                    return View("SignUp");
                }
                if (temp == null)
                {
                    db.TAIKHOANs.Add(new Models.TAIKHOAN() { TenTaiKhoan = id, MauKhau = pass, Email = email, Sdt = sdt, DiaChi = diaChi, GioiTinh = sex, HoTen = ten });
                    db.SaveChanges();
                    db.Dispose();
                }
                else
                {
                    ViewBag.AccEx = "Tài khoản đã được sử dụng";
                    return View("SignUp");
                }
            }
            return RedirectToAction("Login","Login");
        }

    }
}