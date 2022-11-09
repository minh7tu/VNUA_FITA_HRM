using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.BaiViet;
using Microsoft.EntityFrameworkCore;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.BaiViet
{
    public class Repository : IRepository
    {
        private readonly SQLServerDbContext _context;
        private readonly IMapper _mapper;

        public Task<View> CreatAsync(New model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<View> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<View> UpdateAsync(Edit model)
        {
            throw new NotImplementedException();
        }
    }
}
