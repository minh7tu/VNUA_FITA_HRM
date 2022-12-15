using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class QuanLyLuongController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QuanLyLuongController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: QLLuong
        public async Task<IActionResult> Index()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            var sqlServerDbContext = _context.Luongs.Include(l => l.NhanViens);
            return View(await sqlServerDbContext.ToListAsync());
        }

        // GET: QLLuong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var luong = await _context.Luongs
                .Include(l => l.NhanViens)
                .FirstOrDefaultAsync(m => m.MaLuong == id);
            if (luong == null)
            {
                return NotFound();
            }

            return View(luong);
        }

        // GET: QLLuong/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien");
            return View();
        }

        // POST: QLLuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLuong,LCoBan,HeSo,PhiPhat,PhiThue,LThucNhan,ThoiGian,TrangThai,IdNhanVien")] Luong luong)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (ModelState.IsValid)
            {
                _context.Add(luong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", luong.IdNhanVien);
            return View(luong);
        }

        // GET: QLLuong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var luong = await _context.Luongs.FindAsync(id);
            if (luong == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", luong.IdNhanVien);
            return View(luong);
        }

        // POST: QLLuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLuong,LCoBan,HeSo,PhiPhat,PhiThue,LThucNhan,ThoiGian,TrangThai,IdNhanVien")] Luong luong)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id != luong.MaLuong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuongExists(luong.MaLuong))
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
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", luong.IdNhanVien);
            return View(luong);
        }

        // GET: QLLuong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var luong = await _context.Luongs
                .Include(l => l.NhanViens)
                .FirstOrDefaultAsync(m => m.MaLuong == id);
            if (luong == null)
            {
                return NotFound();
            }

            return View(luong);
        }

        // POST: QLLuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var luong = await _context.Luongs.FindAsync(id);
            _context.Luongs.Remove(luong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuongExists(int id)
        {
            return _context.Luongs.Any(e => e.MaLuong == id);
        }
    }
}
