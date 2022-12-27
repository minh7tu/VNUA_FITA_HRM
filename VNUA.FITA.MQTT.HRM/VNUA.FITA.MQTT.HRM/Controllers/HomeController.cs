using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlServerDbContext _context;

        public HomeController(SqlServerDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ViewData["nv"] = (from s in _context.NhanViens
                              select s.IdNhanVien).Count();
            ViewData["phong"] = (from s in _context.Phongs
                              select s.IdPhong).Count();
            string accconut = HttpContext.Session.GetString("SessionUser");
            var nhanVien = _context.NhanViens.Where(n => n.TenTaiKhoan.Equals(accconut)).SingleOrDefault();
            int idnhanvien = nhanVien.IdNhanVien;
            ViewData["dontu"] = (from s in _context.DonTus.Where(n=>n.IdNhanVien==idnhanvien)
                              select s.IdDonTu).Count();
            return View();
        }


    }
}
