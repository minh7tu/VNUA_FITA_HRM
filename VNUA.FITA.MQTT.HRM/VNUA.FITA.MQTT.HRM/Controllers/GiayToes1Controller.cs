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
    public class GiayToes1Controller : Controller
    {
        private readonly SqlServerDbContext _context;

        public GiayToes1Controller(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: GiayToes1
        public async Task<IActionResult> Index()
        {
            var sqlServerDbContext = _context.GiayTos.Include(g => g.NhanViens);
            return View(await sqlServerDbContext.ToListAsync());
        }

        // GET: GiayToes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: GiayToes1/Create
        public IActionResult Create()
        {
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien");
            return View();
        }

        // POST: GiayToes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGT,TenGT,Anh,ThoiGian,TrangThai,IdNhanVien")] GiayTo giayTo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giayTo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }

        // GET: GiayToes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: GiayToes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGT,TenGT,Anh,ThoiGian,TrangThai,IdNhanVien")] GiayTo giayTo)
        {
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

        // GET: GiayToes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: GiayToes1/Delete/5
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
