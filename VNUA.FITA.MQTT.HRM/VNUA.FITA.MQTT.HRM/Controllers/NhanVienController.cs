using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyfService;

        public NhanVienController(INotyfService notyfService, SqlServerDbContext context)
        {
            _context = context;
            _notyfService = notyfService;

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
        // GET: NhanVien
        public async Task<IActionResult> Index(string sortOder, string searchString, string currentFilter, int?  pageNumber)
        {



            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

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
            ViewData["nv"]= (from s in _context.NhanViens
                            select s.IdNhanVien).Count();

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

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

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
            if (KiemTranChucNang(2) == false & KiemTranChucNang(3) == false)
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            ViewData["IdBP"] = new SelectList(_context.BoPhans, "IdBoPhan", "IdBoPhan");
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("IdNhanVien,MaNhanVien,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,Email,ChucVu,Anh,SoCCCD,TrinhDo,IdBP")] NhanVien nhanVien,IFormFile formFile,string maNhanVien)
        {
            if (KiemTranChucNang(2) == false & KiemTranChucNang(3) == false)
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            if (ModelState.IsValid)
            {
                if (!KiemTraNhanVien(nhanVien.MaNhanVien))
                {
                    string filename = formFile.FileName;
                    nhanVien.Anh = filename.ToString(); // tên ảnh
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);
                    formFile.CopyTo(new FileStream(imagePath, FileMode.Create));
                    _context.Add(nhanVien);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Bạn đã thêm thông tin nhân viên thành công.");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _notyfService.Warning("Thông tin nhân viên đã có trong hệ thống");
                }
            }
            else{
                _notyfService.Error("Vui lòng nhập thông tin");
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

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

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

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

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
                    _notyfService.Success("Bạn đã cập nhật thông tin nhân viên thành công.");
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

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

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

            if (!KiemTranChucNang(2))
            {
                return RedirectToAction("BaoLoi", "BaoLoi");
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            _context.NhanViens.Remove(nhanVien);
            await _context.SaveChangesAsync();
            _notyfService.Success("Bạn đã xóa thông tin của nhân viên thành công.");
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(int id)
        {
            ViewBag.SessionUser = HttpContext.Session.GetString("SessionUser");
            ViewBag.SessionImage = HttpContext.Session.GetString("SessionImage");
            ViewBag.ChucVu = HttpContext.Session.GetString("SessionChucVu");
            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
        public bool KiemTraNhanVien(string ma)
        {
            return _context.NhanViens.Any(e => e.MaNhanVien == ma);
        }
      
        
        //public IActionResult XuatExcel()
        //{
        //    GridView gv = new GridView();
        //    var data = _context.NhanViens.Include(w => w.IdNhanVien).Include(w => w.MaNhanVien).Include(w => w.).Include(w => w.web_kategori3).Include(w => w.web_kategori4).ToList();

        //    gv.AutoGenerateColumns = false;
        //    gv.Columns.Add(new ImageField { HeaderText = "IMG", DataImageUrlField = "Imagepath", DataImageUrlFormatString = "https://localhost:44353/img/{0}.jpeg", });
        //    gv.Columns.Add(new BoundField { HeaderText = "ID", DataField = "ID" });
        //    gv.Columns.Add(new BoundField { HeaderText = "Email", DataField = "emailid" });
        //    gv.Columns.Add(new BoundField { HeaderText = "Date", DataField = "date" });
        //    gv.Columns.Add(new BoundField { HeaderText = "Task 1", DataField = "task1" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "t1kategoriid" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "task2" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "t2kategoriid" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "task3" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "t3kategoriid" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "task4" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "t4kategoriid" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "task5" });
        //    gv.Columns.Add(new BoundField { HeaderText = "", DataField = "t5kategoriid" });

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Imagepath");
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("emailid");
        //    dt.Columns.Add("date");
        //    dt.Columns.Add("task1");
        //    dt.Columns.Add("t1kategoriid");
        //    dt.Columns.Add("task2");
        //    dt.Columns.Add("t2kategoriid");
        //    dt.Columns.Add("task3");
        //    dt.Columns.Add("t3kategoriid");
        //    dt.Columns.Add("task4");
        //    dt.Columns.Add("t4kategoriid");
        //    dt.Columns.Add("task5");
        //    dt.Columns.Add("t5kategoriid");

        //    foreach (var item in data)
        //    {
        //        dt.Rows.Add(item.emailid, item.ID, item.emailid, item.date, item.task1, item.t1kategoriid, item.task2, item.t2kategoriid, item.task3, item.t3kategoriid, item.task4, item.t4kategoriid, item.task5, item.t5kategoriid);
        //    }

        //    gv.DataSource = dt;
        //    gv.DataBind();

        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        gv.Rows[i].Height = 40;
        //    }

        //    Response.ClearContent();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment; filename=WeeklyReports.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    gv.RenderControl(htw);
        //    Response.Output.Write(sw.ToString());
        //    Response.Flush();
        //    Response.End();

        //    return RedirectToAction("adminreports");
        //}
    }
}
