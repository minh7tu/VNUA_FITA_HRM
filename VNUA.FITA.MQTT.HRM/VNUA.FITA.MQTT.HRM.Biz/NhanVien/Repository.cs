using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.NhanVien
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
            Data.Model.NhanVien result = _mapper.Map<Model.NhanVien.New, Data.Model.NhanVien>(model);
            await _context.NhanViens.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.NhanVien, View>(result);
        }

        public async  Task<View> CreateAsync(NewByAdmin model)
        {
            Data.Model.NhanVien result = _mapper.Map<Model.NhanVien.NewByAdmin, Data.Model.NhanVien>(model);
            await _context.NhanViens.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.NhanVien, View>(result);
        }

        public async  Task DeleteAsync(int id)
        {
            Data.Model.NhanVien resutl = new Data.Model.NhanVien() { IdNhanVien = id };
            _context.NhanViens.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public  async Task<View> GetAsync(long id)
        {
            Data.Model.NhanVien resutl = await _context.NhanViens.FirstOrDefaultAsync(c => c.IdNhanVien == id);
            return _mapper.Map<Data.Model.NhanVien, Biz.Model.NhanVien.View>(resutl);
        }

        public async  Task<View> UpdateAsync(Edit model)
        {
            Data.Model.NhanVien resutl = _mapper.Map<Model.NhanVien.Edit, Data.Model.NhanVien>(model);
            _context.NhanViens.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.NhanVien, View>(resutl);
        }

        public async Task<View> UpdateAsync(EditByAdmin model)
        {
            Data.Model.NhanVien resutl = _mapper.Map<Model.NhanVien.EditByAdmin, Data.Model.NhanVien>(model);
            _context.NhanViens.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.NhanVien, View>(resutl);
        }

        public async Task<View> UpdateAsync(EditByStaff model)
        {
            Data.Model.NhanVien resutl = _mapper.Map<Model.NhanVien.EditByStaff, Data.Model.NhanVien>(model);
            _context.NhanViens.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.NhanVien, View>(resutl);
        }
    }
}
