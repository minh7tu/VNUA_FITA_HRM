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
    public class QuanLyGiayToController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QuanLyGiayToController(SqlServerDbContext context)
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
        // GET: QLgiayto
        public async Task<IActionResult> Index(string sortOder, string searchString, string currentFilter, int? pageNumber)
        {
            if (!KiemTranChucNang(3))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
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
            var sqlServerDbContext = from s in _context.GiayTos.Include(n => n.NhanViens)
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sqlServerDbContext = sqlServerDbContext.Where(s => s.TrangThai.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<GiayTo>.CreateAsync(sqlServerDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: QLgiayto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var giayTo = await _context.GiayTos
                .Include(g => g.NhanViens)
                .FirstOrDefaultAsync(m => m.MaGT == id);
            if (giayTo == null)
            {
                return NotFound();
            }

            return View(giayTo);
        }

        // GET: QLgiayto/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien");
            return View();
        }

        // POST: QLgiayto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGT,TenGT,Anh,ThoiGian,TrangThai,IdNhanVien")] GiayTo giayTo)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (ModelState.IsValid)
            {
                _context.Add(giayTo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }

        // GET: QLgiayto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var giayTo = await _context.GiayTos.FindAsync(id);
            if (giayTo == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }

        // POST: QLgiayto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGT,TenGT,Anh,ThoiGian,TrangThai,IdNhanVien")] GiayTo giayTo)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id != giayTo.MaGT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giayTo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiayToExists(giayTo.MaGT))
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
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }

        // GET: QLgiayto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (id == null)
            {
                return NotFound();
            }

            var giayTo = await _context.GiayTos
                .Include(g => g.NhanViens)
                .FirstOrDefaultAsync(m => m.MaGT == id);
            if (giayTo == null)
            {
                return NotFound();
            }

            return View(giayTo);
        }

        // POST: QLgiayto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giayTo = await _context.GiayTos.FindAsync(id);
            _context.GiayTos.Remove(giayTo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiayToExists(int id)
        {
            return _context.GiayTos.Any(e => e.MaGT == id);
        }
    }
}
