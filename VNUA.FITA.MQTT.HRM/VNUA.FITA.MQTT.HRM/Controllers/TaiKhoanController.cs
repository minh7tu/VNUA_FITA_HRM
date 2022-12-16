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
    public class TaiKhoanController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly INotyfService _notyfService;
        public TaiKhoanController(INotyfService notyfService, SqlServerDbContext context)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public bool KiemTranChucNang(int ? phanQuyen)
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
        // GET: TaiKhoan
        public async Task<IActionResult> Index(string sortOder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu"); 
             
            if(!KiemTranChucNang(4))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }    

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
            var sqlServerDbContext = from s in _context.NhanViens.Include(n => n.BoPhans)
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sqlServerDbContext = sqlServerDbContext.Where(s => s.TenTaiKhoan.Contains(searchString)
                                       || s.MatKhau.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<NhanVien>.CreateAsync(sqlServerDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {

           

            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            

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
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(4))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan");
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhanVien,MaNhanVien,HoTen,TenTaiKhoan,SDT,Email,MatKhau,PhanQuyen,ChucVu,IdBP")] NhanVien nhanVien,string ma)
        {

           

            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(4))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                _notyfService.Success("Bạn đã tạo tài khoản thành công.");
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhanVien"] = new SelectList(_context.NhanViens, "MaNhanVien", "MaNhanVien", nhanVien.MaNhanVien);
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan", nhanVien.IdBP);
            return View(nhanVien);
        }

        // GET: TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

           

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
        public async Task<IActionResult> Edit(int id, [Bind("IdNhanVien,MaNhanVien,HoTen,TenTaiKhoan,NgaySinh,GioiTinh,DiaChi,SDT,Email,MatKhau,PhanQuyen,ChucVu,Anh,SoCCCD,TrinhDo,IdBP")] NhanVien nhanVien)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

           

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
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            

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
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

           

            var nhanVien = await _context.NhanViens.FindAsync(id);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            

            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
      

    }
}
