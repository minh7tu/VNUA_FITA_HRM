using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class QuanLyChucVuController : Controller
    {
        private readonly SqlServerDbContext _context;

        public QuanLyChucVuController(SqlServerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var displayData = _context.NhanViens.ToList();
            return View(displayData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Data.Model.NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetListCV");
            }
            return View(nhanVien);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string maNV)
        {
            ViewData["GetMNV"] = maNV;

            var maNhanVien = from x in _context.NhanViens select x;

            if (!string.IsNullOrEmpty(maNV))
            {
                maNhanVien = maNhanVien.Where(x => x.MaNhanVien.Contains(maNV));
            }

            return View(await maNhanVien.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getData = await _context.NhanViens.FindAsync(id);

            return View(getData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Data.Model.NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Update(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        public IActionResult GetListNV()
        {
            var displayData = _context.NhanViens.ToList();
            return View(displayData);
        }
    }
}
