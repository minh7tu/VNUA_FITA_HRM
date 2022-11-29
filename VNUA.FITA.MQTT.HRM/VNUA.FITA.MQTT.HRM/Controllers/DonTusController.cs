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
    
    public class DonTusController : Controller
    {
        private readonly SqlServerDbContext _context;

        public DonTusController(SqlServerDbContext context)
        {
            _context = context;
        }
            
        // GET: DonTus
        public async Task<IActionResult> Danhsachdontu(string searchString)
        {
            string accconut = HttpContext.Session.GetString("SessionUser");

            var sqlServerDbContext = _context.DonTus.Where(g => g.NhanViens.TenTaiKhoan == accconut);
            ViewData["CurrentFilter"] = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                 sqlServerDbContext = _context.DonTus.Where(g => g.NhanViens.TenTaiKhoan == accconut && g.TieuDe.Contains(searchString));
            }
            return View(await sqlServerDbContext.ToListAsync());
        }

        
        // GET: DonTus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donTu = await _context.DonTus
                .Include(d => d.NhanViens)
                .FirstOrDefaultAsync(m => m.IdDonTu == id);
            if (donTu == null)
            {
                return NotFound();
            }

            return View(donTu);
        }

        // GET: DonTus/Create
        public IActionResult Create()
        {
            NhanVien nhanVien = new NhanVien();
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == 3),"HoTen","HoTen");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien");
            return View();
        }

        // POST: DonTus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonTu,TieuDe,NoiDung,TrangThai,GhiChu,NguoiNhan,PhanLoai,ThoiGian,IdNhanVien")] DonTu donTu)
        {
            NhanVien nhanVien = new NhanVien();
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (ModelState.IsValid)
            {
                _context.Add(donTu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Danhsachdontu));
            }
            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == 3),"HoTen","HoTen",nhanVien.HoTen);
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", donTu.IdNhanVien);
            return View(donTu);
        }

        // GET: DonTus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donTu = await _context.DonTus.FindAsync(id);
            if (donTu == null)
            {
                return NotFound();
            }
            NhanVien nhanVien = new NhanVien();
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == 3), "HoTen", "HoTen");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", donTu.IdNhanVien);
            return View(donTu);
        }

        // POST: DonTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonTu,TieuDe,NoiDung,TrangThai,GhiChu,NguoiNhan,PhanLoai,ThoiGian,IdNhanVien")] DonTu donTu)
        {

            if (id != donTu.IdDonTu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donTu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonTuExists(donTu.IdDonTu))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Danhsachdontu));
            }
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", donTu.IdNhanVien);
            return View(donTu);
        }

        // GET: DonTus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donTu = await _context.DonTus
                .Include(d => d.NhanViens)
                .FirstOrDefaultAsync(m => m.IdDonTu == id);
            if (donTu == null)
            {
                return NotFound();
            }

            return View(donTu);
        }

        // POST: DonTus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("IdDonTu,TieuDe,NoiDung,TrangThai,GhiChu,NguoiNhan,PhanLoai,ThoiGian,IdNhanVien")] DonTu donTu)
        {
            var dontu1 = _context.DonTus.Find(id);
            donTu = dontu1;
            string status = "Đã Hủy";
            donTu.TrangThai = status;
            _context.DonTus.Update(donTu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Danhsachdontu));
        }

        private bool DonTuExists(int id)
        {
            return _context.DonTus.Any(e => e.IdDonTu == id);
        }
    }
}
