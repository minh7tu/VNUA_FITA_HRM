using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class QuanLyBoPhanController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QuanLyBoPhanController(SqlServerDbContext context)
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

        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Data.Model.BoPhan boPhan)
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
                _context.Add(boPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetListBP");
            }
            return View(boPhan);
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

            if(!string.IsNullOrEmpty(maNV))
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

            if (id==null)
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

        public async Task<IActionResult> EditBP(int? id)
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
                return RedirectToAction("GetListBP");
            }

            var getData = await _context.BoPhans.FindAsync(id);

            return View(getData);
        }

        [HttpPost]
        public async Task<IActionResult> EditBP(Data.Model.BoPhan boPhan)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            //ViewData["TenPhong"] = new SelectList(_context.Phongs, "IdPhong", "IdPhong");
            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            if (ModelState.IsValid)
            {
                _context.Update(boPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetListBP");
            }
            return View(boPhan);
        }


        public IActionResult GetListBP()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var displayData = _context.BoPhans.ToList();
            return View(displayData);
        }

        public IActionResult GetListP()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var displayData = _context.Phongs.ToList();
            return View(displayData);
        }

        public async Task<IActionResult> EditP(int? id)
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
                return RedirectToAction("GetListP");
            }

            var getData = await _context.Phongs.FindAsync(id);

            return View(getData);
        }

        [HttpPost]
        public async Task<IActionResult> EditP(Data.Model.Phong phong)
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
                _context.Update(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetListP");
            }
            return View(phong);
        }

        public IActionResult CreateP()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateP(Data.Model.Phong phong)
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
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetListP");
            }
            return View(phong);
        }
    }
}