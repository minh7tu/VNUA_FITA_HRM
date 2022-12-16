using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class QuanLyChucVuController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QuanLyChucVuController(SqlServerDbContext context)
        {
            _context = context;
        }

        public bool KiemTranChucNang(int? phanQuyen)
        {
            string tk = HttpContext.Session.GetString("SessionUser");
            string pg = HttpContext.Session.GetString("SessionPhanQuyen");

            //var count = _context.NhanViens.CountConvert.ToInt32(pg));

            if (Convert.ToInt32(pg) != phanQuyen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IActionResult Index()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var displayData = _context.NhanViens.ToList();
            return View(displayData);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string maNV)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            ViewData["GetMNV"] = maNV;

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var maNhanVien = from x in _context.NhanViens select x;

            if (!string.IsNullOrEmpty(maNV))
            {
                maNhanVien = maNhanVien.Where(x => x.MaNhanVien.Contains(maNV));
            }

            return View(await maNhanVien.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getData = await _context.NhanViens.FindAsync(id);

            return View(getData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Data.Model.NhanVien nhanVien)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            if (ModelState.IsValid)
            {
                _context.Update(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        public IActionResult GetListNV()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var displayData = _context.NhanViens.ToList();
            return View(displayData);
        }
    }
}
