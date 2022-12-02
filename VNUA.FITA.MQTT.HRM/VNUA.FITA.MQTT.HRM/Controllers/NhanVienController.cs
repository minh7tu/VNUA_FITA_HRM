using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;


namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly SqlServerDbContext _context;
        

        public NhanVienController(SqlServerDbContext context)
        {
            _context = context;
            
        }
        public bool KiemTranChucNang(int? idChucNang)
        {
            string tk = HttpContext.Session.GetString("SessionUser");
            var count = _context.NhanViens.Count(m => m.TenTaiKhoan == tk & m.PhanQuyen == idChucNang);
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // GET: NhanVien
        public async Task<IActionResult> Index(string sortOder, string searchString, string currentFilter, int?  pageNumber)
        {

            if (KiemTranChucNang(2) == false)
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["MaNhanVien"] = String.IsNullOrEmpty(sortOder) ? "id_desc" : "";
            ViewData["HoTen"] = sortOder == "HoTen" ? "HoTen_desc" : "HoTen";
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
            var sqlServerDbContext = from s in _context.NhanViens.Include(n=>n.BoPhans)
                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sqlServerDbContext = sqlServerDbContext.Where(s => s.MaNhanVien.Contains(searchString)
                                       || s.HoTen.Contains(searchString));
            }
            switch (sortOder)
            {
                case "id_desc":
                    sqlServerDbContext = sqlServerDbContext.OrderByDescending(s => s.MaNhanVien);
                    break;
                case "HoTen":
                    sqlServerDbContext = sqlServerDbContext.OrderBy(s => s.HoTen);
                    break;
                case "HoTen_desc":
                    sqlServerDbContext = sqlServerDbContext.OrderByDescending(s => s.HoTen);
                    break;
                default:
                    sqlServerDbContext = sqlServerDbContext.OrderBy(s => s.MaNhanVien);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<NhanVien>.CreateAsync(sqlServerDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: NhanVien/Details/5
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

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("IdNhanVien,MaNhanVien,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,Email,ChucVu,Anh,SoCCCD,TrinhDo,IdBP")] NhanVien nhanVien,IFormFile formFile,int ?id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            if (ModelState.IsValid)
            {
                
                 
                    if(nhanVien.IdNhanVien!=id)
                    {
                        string filename = formFile.FileName;
                        nhanVien.Anh = filename.ToString(); // tên ảnh
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);
                        formFile.CopyTo(new FileStream(imagePath, FileMode.Create));
                        _context.Add(nhanVien);
                        await _context.SaveChangesAsync();
                        TempData["Message"] = "Thêm nhân viên thành công!";
                    }
                    else
                    {
                        TempData["Message"] = "Nhân Viên đã có trong danh sách";
                    }
            }
            else {
                TempData["Message"] = "Thêm nhân viên thất bại!";
            }
     
            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan", nhanVien.IdBP);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
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

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhanVien,MaNhanVien,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,Email,ChucVu,Anh,SoCCCD,TrinhDo,IdBP")] NhanVien nhanVien, IFormFile formFile)
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
                    string filename = formFile.FileName;
                    nhanVien.Anh = filename.ToString(); // tên ảnh
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);
                    formFile.CopyTo(new FileStream(imagePath, FileMode.Create));
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

        // GET: NhanVien/Delete/5
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

        // POST: NhanVien/Delete/5
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
        public bool KiemTraNhanVien(int id)
        {
            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
    }
}
