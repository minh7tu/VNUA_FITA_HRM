using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class GiayToesController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
       
       
        public GiayToesController(SqlServerDbContext context,IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this._hostingEnvironment = hostingEnvironment;
           
        }

        // GET: GiayToes
        public async Task<IActionResult> Index()
        {
            string accconut = HttpContext.Session.GetString("SessionUser");

            var sqlServerDbContext = _context.GiayTos.Where(g => g.NhanViens.TenTaiKhoan == accconut);
            return View(await sqlServerDbContext.ToListAsync());
        }

        // GET: GiayToes/Details/5
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

        // GET: GiayToes/Create
        public IActionResult Create()
        {
            GiayTo giayTo = new GiayTo();
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien",giayTo.IdNhanVien);
            return View();
        }

        // POST: GiayToes/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]     
        public async Task<IActionResult> Create(GiayTo giayTo, IFormFile formFile)
        {
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (ModelState.IsValid)
            {
                string filename = formFile.FileName;
                giayTo.Anh = filename.ToString(); // tên ảnh
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);
                formFile.CopyTo(new FileStream(imagePath, FileMode.Create));
                _context.Add(giayTo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }
        
        // GET: GiayToes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (id == null)
            {
                return NotFound();
            }

            var giayTo = await _context.GiayTos.FindAsync(id);
            if (giayTo == null)
            {
                return NotFound();
            }
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", giayTo.IdNhanVien);
            return View(giayTo);
        }

        // POST: GiayToes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGT,TenGT,Anh,ThoiGian,TrangThai,IdNhanVien")] GiayTo giayTo,IFormFile formFile)
        {
            if (id != giayTo.MaGT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string filename = formFile.FileName;
                    giayTo.Anh = filename.ToString(); // tên ảnh
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);
                    formFile.CopyTo(new FileStream(imagePath, FileMode.Create));
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

        // GET: GiayToes/Delete/5
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

        // POST: GiayToes/Delete/5
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
