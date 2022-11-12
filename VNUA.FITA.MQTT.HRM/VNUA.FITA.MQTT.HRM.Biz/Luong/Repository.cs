using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.Luong;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.Luong
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
            Data.Model.Luong result = _mapper.Map<Model.Luong.New, Data.Model.Luong>(model);
            await _context.Luongs.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Luong, View>(result);
        }

        public async Task DeleteAsync(int id)
        {
            Data.Model.Luong resutl = new Data.Model.Luong() { MaLuong = id };
            _context.Luongs.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.Luong resutl = await _context.Luongs.FirstOrDefaultAsync(c => c.MaLuong == id);
            return _mapper.Map<Data.Model.Luong, Biz.Model.Luong.View>(resutl);
        }

        public async  Task<View> UpdateAsync(Edit model)
        {
            Data.Model.Luong resutl = _mapper.Map<Model.Luong.Edit, Data.Model.Luong>(model);
            _context.Luongs.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Luong, View>(resutl);
        }
    }
}
