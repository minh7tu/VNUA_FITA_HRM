using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoPhanController : ControllerBase
    {
        private readonly SqlServerDbContext _context;

        public BoPhanController(SqlServerDbContext contetx)
        {
            _context = contetx;
        }

        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var item = _context.BoPhans.ToList();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateDepartment(Biz.Model.BoPhan.New model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
            return Ok(id);
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Biz.Model.BoPhan.Edit model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return Ok(model);
        }
    }
}
