
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class LoginController : Controller
    {
        private readonly SqlServerDbContext context;
      

        public LoginController(SqlServerDbContext context)
        {
            this.context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {

                //success
                var data = context.NhanViens.Where(e => e.TenTaiKhoan == nhanVien.TenTaiKhoan && e.MatKhau == nhanVien.MatKhau).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = (data.TenTaiKhoan == nhanVien.TenTaiKhoan && data.MatKhau == GetMD5(nhanVien.MatKhau));
                    HttpContext.Session.SetString("SessionUser", data.TenTaiKhoan);
                    HttpContext.Session.SetString("SessionImage", data.Anh);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MessageTaikhoan"] = "Không tìm thấy tài khoản!";
                    return View(nhanVien);
                }
            }
            else
            {
                return View(nhanVien);
            }
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
