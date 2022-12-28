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
using PagedList;
namespace VNUA.FITA.MQTT.HRM.Controllers
{
    
    public class QLDonTusController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QLDonTusController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: DonTus
        public async Task<IActionResult> QLDanhsachdontu(string searchString, string currentFilter, int? pageNumber,string status)
        {
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            ViewData["CurrentFilter"] = searchString;
           
            var nhanVien = _context.NhanViens.Where(n => n.TenTaiKhoan.Equals(accconut)).SingleOrDefault();
            int count = _context.DonTus.Where(d => d.GhiChu == null && d.NguoiNhan == nhanVien.HoTen).Count();
            TempData["donmoi"] = count;
            var sqlServerDbContext = _context.DonTus.Where(g=>g.NguoiNhan == nhanVien.HoTen).OrderByDescending(d => d.ThoiGian);
          
            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(status))
            {
                sqlServerDbContext = sqlServerDbContext.Where(g => g.NhanViens.TenTaiKhoan == accconut
                                       && g.IdDonTu.ToString() == searchString || g.TieuDe.Contains(searchString) && g.TrangThai == status).OrderByDescending(d => d.ThoiGian);
                
            }
            if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(status))
            {
                sqlServerDbContext = sqlServerDbContext.Where(g => g.NhanViens.TenTaiKhoan == accconut
                                       && g.IdDonTu.ToString() == searchString || g.TieuDe.Contains(searchString)).OrderByDescending(d => d.ThoiGian);
                
            }
            else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(status))
            {
                sqlServerDbContext = sqlServerDbContext.Where(g => g.NhanViens.TenTaiKhoan == accconut
                                       && g.TrangThai == status).OrderByDescending(d => d.ThoiGian);
                
            }

            int pageSize = 3;
            return View(await PaginatedList<DonTu>.CreateAsync(sqlServerDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: DonTus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (id == null)
            {
                return NotFound();
            }
            var dontu1 = _context.DonTus.Find(id);
            int idnhanvien = dontu1.IdNhanVien;
            if (dontu1.TrangThai.Equals("Chờ duyệt"))
            {
                dontu1.GhiChu = " Đã được Xem lúc :" + DateTime.Now;
            }        
            _context.DonTus.Update(dontu1);
            await _context.SaveChangesAsync();
            var nhanVien = _context.NhanViens.Where(n=>n.IdNhanVien == idnhanvien).SingleOrDefault();
            int idbophan = nhanVien.IdBP;
            var Bophan = _context.BoPhans.Where(n => n.IdBoPhan == idbophan).SingleOrDefault();
            TempData["HoTen"] = nhanVien.HoTen;
            TempData["ChucVu"] = nhanVien.ChucVu;
            TempData["Bophan"] = Bophan.TenBP;

           
            var donTu = await _context.DonTus
                .Include(d => d.NhanViens)
                .FirstOrDefaultAsync(m => m.IdDonTu == id);
            var nhanVien2 = _context.NhanViens.Where(n => n.HoTen.Equals(donTu.NguoiNhan)).SingleOrDefault();
            int idbophan2 = nhanVien2.IdBP;
            var Bophan2 = _context.BoPhans.Where(n => n.IdBoPhan == idbophan2).SingleOrDefault();
            TempData["HoTen2"] = nhanVien2.HoTen;
            TempData["ChucVu2"] = nhanVien2.ChucVu;
            TempData["Bophan2"] = Bophan2.TenBP;
            if (donTu == null)
            {
                return NotFound();
            }

            return View(donTu);
        }

        // GET: DonTus/Create
        public IActionResult Create()
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            var nhanVien = _context.NhanViens.Where(n => n.TenTaiKhoan.Equals(accconut)).SingleOrDefault();

            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == nhanVien.IdBP && g.ChucVu.Equals("Trưởng phòng")), "HoTen", "HoTen");
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
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (ModelState.IsValid)
            {
                _context.Add(donTu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(QLDanhsachdontu));
            }
            var nhanVien = _context.NhanViens.Where(n => n.TenTaiKhoan.Equals(accconut)).SingleOrDefault();

            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == nhanVien.IdBP && g.ChucVu.Equals("Trưởng Phòng")), "HoTen", "HoTen");
            ViewData["IdNhanVien"] = new SelectList(_context.NhanViens.Where(g => g.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien",nhanVien.IdNhanVien );
            return View(donTu);
        }

        // GET: DonTus/Edit/5
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

            var donTu = await _context.DonTus.FindAsync(id);
            if (donTu == null)
            {
                return NotFound();
            }
            var nhanVien = _context.NhanViens.Where(n => n.TenTaiKhoan.Equals(accconut)).SingleOrDefault();

            ViewData["HoTen"] = new SelectList(_context.NhanViens.Where(g => g.IdBP == nhanVien.IdBP && g.ChucVu.Equals("Trưởng Phòng")), "HoTen", "HoTen");
            ViewData["IdNhanVien"] = new SelectList(_context.DonTus.Where(g => g.NhanViens.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", donTu.IdNhanVien);
            return View(donTu);
        }

        // POST: DonTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonTu,TieuDe,NoiDung,TrangThai,GhiChu,NguoiNhan,PhanLoai,ThoiGian,IdNhanVien")] DonTu donTu)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            string accconut = HttpContext.Session.GetString("SessionUser");
            if (id != donTu.IdDonTu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["AlertMessage"] = "Cập nhật thành công!,Mã đơn :"+ donTu.IdDonTu;
                    TempData["IDdontu"] = donTu.IdDonTu;
                    donTu.GhiChu = "Được duyệt  vào lúc :" + DateTime.Now;
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
                return RedirectToAction(nameof(QLDanhsachdontu));
            }

            ViewData["IdNhanVien"] = new SelectList(_context.DonTus.Where(g => g.NhanViens.TenTaiKhoan == accconut), "IdNhanVien", "IdNhanVien", donTu.IdNhanVien);
            return View(donTu);
        }

        // GET: DonTus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
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
        public async Task<IActionResult> HuyDontu(int? id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
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
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            var dontu1 = _context.DonTus.Find(id);
            donTu = dontu1;
            string status = "Đã được duyệt";
            donTu.TrangThai = status;
            donTu.GhiChu = "Đã được duyệt lúc :" + DateTime.Now;
            _context.DonTus.Update(donTu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(QLDanhsachdontu));
        }
        // POST: DonTus/Delete/5
        [HttpPost, ActionName("HuyDontu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id, [Bind("IdDonTu,TieuDe,NoiDung,TrangThai,GhiChu,NguoiNhan,PhanLoai,ThoiGian,IdNhanVien")] DonTu donTu)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            var dontu1 = _context.DonTus.Find(id);
            donTu = dontu1;
            string status = "Đã hủy";
            donTu.TrangThai = status;
            donTu.GhiChu = "Đã bị từ chối lúc lúc :" + DateTime.Now;
            _context.DonTus.Update(donTu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(QLDanhsachdontu));
        }

        private bool DonTuExists(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            return _context.DonTus.Any(e => e.IdDonTu == id);
        }
    }
}
