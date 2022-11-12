using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.Phong;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.Phong
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
            Data.Model.Phong result = _mapper.Map<Model.Phong.New, Data.Model.Phong>(model);
            await _context.Phongs.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Phong, View>(result);
        }

        public async Task DeleteAsync(int id)
        {
            Data.Model.Phong resutl = new Data.Model.Phong() { IdPhong = id };
            _context.Phongs.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.Phong resutl = await _context.Phongs.FirstOrDefaultAsync(c => c.IdPhong == id);
            return _mapper.Map<Data.Model.Phong, Biz.Model.Phong.View>(resutl);
        }

        public async Task<View> UpdateAsync(Edit model)
        {
            Data.Model.Phong resutl = _mapper.Map<Model.Phong.Edit, Data.Model.Phong>(model);
            _context.Phongs.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Phong, View>(resutl);
        }
    }
}
