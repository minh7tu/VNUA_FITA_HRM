using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly SqlServerDbContext _context;

        public TaiKhoanController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: TaiKhoan
        public async Task<IActionResult> Index()
        {
            var sqlServerDbContext = _context.NhanViens.Include(n => n.BoPhans);
            return View(await sqlServerDbContext.ToListAsync());
        }

        // GET: TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.BoPhans)
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: TaiKhoan/Create
        public IActionResult Create()
        {
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan");
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhanVien,MaNhanVien,HoTen,TenTaiKhoan,SDT,Email,MatKhau,PhanQuyen")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan", nhanVien.IdBP);
            return View(nhanVien);
        }

        // GET: TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan", nhanVien.IdBP);
            return View(nhanVien);
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhanVien,MaNhanVien,HoTen,TenTaiKhoan,SDT,Email,MatKhau,PhanQuyen")] NhanVien nhanVien)
        {
            if (id != nhanVien.IdNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.IdNhanVien))
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
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan", nhanVien.IdBP);
            return View(nhanVien);
        }

        // GET: TaiKhoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .Include(n => n.BoPhans)
                .FirstOrDefaultAsync(m => m.IdNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
    }
}
