using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.KhenThuongKyLuat;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.KhenThuongKyLuat
{
    public class Repository : IRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly ILogger<RepositoryWrapper> _logger;
        private readonly IMapper _mapper;

        public Repository(SqlServerDbContext context, ILogger<RepositoryWrapper> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<View> CreateAsync(New model)
        {
            Data.Model.KhenThuongKyLuat result = _mapper.Map<Model.KhenThuongKyLuat.New, Data.Model.KhenThuongKyLuat>(model);
            await _context.KhenThuongKyLuats.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.KhenThuongKyLuat, View>(result);
        }

        public async Task DeleteAsync(int id)
        {
            Data.Model.KhenThuongKyLuat resutl = new Data.Model.KhenThuongKyLuat() { Id = id };
            _context.KhenThuongKyLuats.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.KhenThuongKyLuat resutl = await _context.KhenThuongKyLuats.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<Data.Model.KhenThuongKyLuat, Biz.Model.KhenThuongKyLuat.View>(resutl);
        }

        public async Task<View> UpdateAsync(Edit model)
        {
            Data.Model.KhenThuongKyLuat resutl = _mapper.Map<Model.KhenThuongKyLuat.Edit, Data.Model.KhenThuongKyLuat>(model);
            _context.KhenThuongKyLuats.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.KhenThuongKyLuat, View>(resutl);
        }
    }
}
