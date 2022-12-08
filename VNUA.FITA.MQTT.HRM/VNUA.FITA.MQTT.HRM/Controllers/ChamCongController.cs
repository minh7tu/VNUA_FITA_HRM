using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class ChamCongController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly INotyfService _notyfService;

        public ChamCongController(INotyfService notyfService,SqlServerDbContext context)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: ChamCong
        public async Task<IActionResult> Index(string sortOder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["CurrentSort"] = sortOder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var sqlServerDbContext = from s in _context.ChamCongs.Include(c => c.NhanViens).Where(m => m.NhanViens.TenTaiKhoan == accconut)
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sqlServerDbContext = sqlServerDbContext.Where(s => s.ThoiGian.ToString().Contains(searchString)
                                      );
            }
            int pageSize = 3;
            return View(await PaginatedList<ChamCong>.CreateAsync(sqlServerDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ChamCong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCongs
                .Include(c => c.NhanViens)
                .FirstOrDefaultAsync(m => m.IdCong == id);
            if (chamCong == null)
            {
                return NotFound();
            }

            return View(chamCong);
        }

        // GET: ChamCong/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ChamCong chamCong = new ChamCong();
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", chamCong.IdNhanVien);
            return View();
        }

        // POST: ChamCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCong,ThoiGian,TrangThai,GhiChu,IdNhanVien")] ChamCong chamCong)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (ModelState.IsValid)
            {
                _context.Add(chamCong);
                await _context.SaveChangesAsync();
                _notyfService.Success("Bạn đã hoàn thành chấm công.");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _notyfService.Error("Bạn chấm công thất bại,Vui lòng kiểm tra lại thông tin!!");
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", chamCong.IdNhanVien);
            return View(chamCong);
        }

        // GET: ChamCong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (id == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCongs.FindAsync(id);
            if (chamCong == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", chamCong.IdNhanVien);
            return View(chamCong);
        }

        // POST: ChamCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCong,ThoiGian,TrangThai,GhiChu,IdNhanVien")] ChamCong chamCong)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (id != chamCong.IdCong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamCong);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Bạn đã chỉnh sửa chấm công thành công.");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamCongExists(chamCong.IdCong))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _notyfService.Error("Bạn đã chỉnh sửa chấm công thất bại.");
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", chamCong.IdNhanVien);
            return View(chamCong);
        }

        // GET: ChamCong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var chamCong = await _context.ChamCongs
                .Include(c => c.NhanViens)
                .FirstOrDefaultAsync(m => m.IdCong == id);
            if (chamCong == null)
            {
                return NotFound();
            }

            return View(chamCong);
        }

        // POST: ChamCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            var chamCong = await _context.ChamCongs.FindAsync(id);
            _context.ChamCongs.Remove(chamCong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamCongExists(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            return _context.ChamCongs.Any(e => e.IdCong == id);
        }
    }
}
