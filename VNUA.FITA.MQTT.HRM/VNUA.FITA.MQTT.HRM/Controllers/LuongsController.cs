using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class LuongsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public LuongsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Luongs
        public async Task<IActionResult> Index( DateTime searchString)
        {
            
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["CurrentFilter"] = searchString;
            var sqlServerDbContext = _context.Luongs.Where(g => g.NhanViens.TenTaiKhoan == accconut);
            if (searchString != null)
            {
                sqlServerDbContext = sqlServerDbContext.Where(g => g.NhanViens.TenTaiKhoan == accconut
                                       && g.ThoiGian.Date == searchString.Date);
            }
            return View(await sqlServerDbContext.ToListAsync());
        }

        // GET: Luongs/Details/5
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

        // GET: Luongs/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien");
            return View();
        }

        // POST: Luongs/Create
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

        // GET: Luongs/Edit/5
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

        // POST: Luongs/Edit/5
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

        // GET: Luongs/Delete/5
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

        // POST: Luongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            var luong = await _context.Luongs.FindAsync(id);
            _context.Luongs.Remove(luong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuongExists(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            return _context.Luongs.Any(e => e.MaLuong == id);
        }
    }
}
