using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Model;
using VNUA.FITA.MQTT.HRM.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class ThongTinNhanVienController : Controller
    {
        public readonly SqlServerDbContext _context;
        public ThongTinNhanVienController(SqlServerDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
       
        public IActionResult DanhSachNhanVien(string SearchText = "", int pg = 1, int pageSize = 5)
        {

            List<NhanVien> nhanViens=_context.NhanViens.ToList();
            //if (SearchText != "" && SearchText != null)
            //{
            //    nhanViens = _context.NhanViens.Where(p => p.MaNhanVien.Contains(SearchText)).ToList();

            //}
            //else
            //    nhanViens = _context.NhanViens.DefaultIfEmpty().ToList();
            //// const int pageSize = 10;
            //if (pg < 1)
            //    pg = 1;
            //int recsCount = _context.NhanViens.Count();

            //var pager = new Pager(recsCount, pg, pageSize);

            //int recSkip = (pg - 1) * pageSize;

            //var data = nhanViens.Skip(recSkip).Take(pager.PageSize).ToList();
            //this.ViewBag.Pager = pager;
            //ViewBag.SearchText = SearchText;
            //this.ViewBag.PageSize = GetPageSizes(pageSize);
            //return View(data);
            return View(nhanViens);
        }
        private List<SelectListItem> GetPageSizes(int selectedPageSize = 10)
        {
            var pagesSizes = new List<SelectListItem>();
            if (selectedPageSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true));
            else
                pagesSizes.Add(new SelectListItem("5", "5"));
            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPageSize)
                { pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true)); }
                else
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
            }
            return pagesSizes;
        }
        public IActionResult Create()
        {
            NhanVien nv = new NhanVien();
            return View(nv);
        }
        [HttpPost]
        public IActionResult Create(NhanVien nhanVien)
        {
            _context.Add(nhanVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(DanhSachNhanVien));
        }
        public IActionResult Details(string maNhanVien)
        {
            NhanVien nv = _context.NhanViens.Where(p => p.MaNhanVien == maNhanVien).FirstOrDefault();
            return View(nv);
        }
        [HttpGet]
        public IActionResult Delete(string maNhanVien)
        {
            NhanVien nv = _context.NhanViens.Where(p => p.MaNhanVien == maNhanVien).FirstOrDefault();
            return View(nv);
        }
        [HttpPost]
        public IActionResult Delete(NhanVien nhanVien)
        {
            _context.Attach(nhanVien);
            _context.Entry(nhanVien).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("DanhSachNhanVien");
        }
        [HttpGet]
        public IActionResult Edit(string maNhanVien)
        {
            NhanVien nv = _context.NhanViens.Where(p => p.MaNhanVien == maNhanVien).FirstOrDefault();
            return View(nv);
        }
        [HttpPost]
        public IActionResult Edit(NhanVien nhanVien)
        {
            _context.Attach(nhanVien);
            _context.Entry(nhanVien).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(DanhSachNhanVien));
        }
    }
}
