using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Controllers
{
    public class BaoLoiController : Controller
    {
        public IActionResult BaoLoi()
        {
            return View();
        }
    }
}
