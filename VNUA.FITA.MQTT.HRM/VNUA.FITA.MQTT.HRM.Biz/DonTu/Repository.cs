using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.DonTu;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.DonTu
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
            Data.Model.DonTu result = _mapper.Map<Model.DonTu.New, Data.Model.DonTu>(model);
            await _context.DonTus.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.DonTu, View>(result);
        }

        public async Task DeleteAsync(int id)
        {
            Data.Model.DonTu resutl = new Data.Model.DonTu() { IdDonTu = id };
            _context.DonTus.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.DonTu resutl = await _context.DonTus.FirstOrDefaultAsync(c => c.IdDonTu == id);
            return _mapper.Map<Data.Model.DonTu, Biz.Model.DonTu.View>(resutl);
        }

        public async Task<View> UpdateAsync(EditByManager model)
        {
            Data.Model.DonTu resutl = _mapper.Map<Model.DonTu.EditByManager, Data.Model.DonTu>(model);
            _context.DonTus.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.DonTu, View>(resutl);
        }

        public async Task<View> UpdateAsync(Edit model)
        {
            Data.Model.DonTu resutl = _mapper.Map<Model.DonTu.Edit, Data.Model.DonTu>(model);
            _context.DonTus.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.DonTu, View>(resutl);
        }
    }
}
