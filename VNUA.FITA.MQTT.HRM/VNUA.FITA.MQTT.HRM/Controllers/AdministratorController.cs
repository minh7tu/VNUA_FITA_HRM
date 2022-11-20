using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class AdministratorController : Controller
    {
        //khai báo
        private SqlServerDbContext db = new SqlServerDbContext();
       
        public IActionResult instergiayto()
        {
           
            return View();
        }
       
       public IActionResult Danhsachgiayto()
        {

            var giaytos = db.GiayTos.Where(g => g.IdNhanVien == 8);
            return View(giaytos);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trangthailuong()
        {
            return View();
        }

        public IActionResult BosungGT()
        {
            return View();
        }
    }
}
