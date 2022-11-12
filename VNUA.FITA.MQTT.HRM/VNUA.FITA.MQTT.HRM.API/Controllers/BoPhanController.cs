using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz;

namespace VNUA.FITA.MQTT.HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoPhanController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BoPhanController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var item = await _repository.BoPhan.GetAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Biz.Model.BoPhan.New model)
        {
            var item = await _repository.BoPhan.CreateAsync(model);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _repository.BoPhan.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(Biz.Model.BoPhan.Edit model)
        {
            var item = await _repository.BoPhan.UpdateAsync(model);
            return Ok(item);
        }
    }
}
