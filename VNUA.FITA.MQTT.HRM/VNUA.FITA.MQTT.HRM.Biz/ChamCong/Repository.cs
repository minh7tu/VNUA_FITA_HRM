using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.ChamCong;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.ChamCong
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
            Data.Model.ChamCong result = _mapper.Map<Model.ChamCong.New, Data.Model.ChamCong>(model);
            await _context.ChamCongs.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.ChamCong, View>(result);
        }

        public async Task Delete(int id)
        {
            Data.Model.ChamCong resutl = new Data.Model.ChamCong() { IdCong = id };
            _context.ChamCongs.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.ChamCong resutl = await _context.ChamCongs.FirstOrDefaultAsync(c => c.IdCong == id);
            return _mapper.Map<Data.Model.ChamCong, Biz.Model.ChamCong.View>(resutl);
        }

        public async Task<View> UpdateAsync(Edit model)
        {
            Data.Model.ChamCong resutl = _mapper.Map<Model.ChamCong.Edit, Data.Model.ChamCong>(model);
            _context.ChamCongs.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.ChamCong, View>(resutl);
        }
    }
}
