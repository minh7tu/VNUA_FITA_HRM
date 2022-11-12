using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.GiayTo;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.GiayTo
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

        public async Task<View> CreatAsync(New model)
        {
            Data.Model.GiayTo result = _mapper.Map<Model.GiayTo.New, Data.Model.GiayTo>(model);
            await _context.GiayTos.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.GiayTo, View>(result);
        }

        public async  Task DeleteAsync(int id)
        {
            Data.Model.GiayTo resutl = new Data.Model.GiayTo() { MaGT = id };
            _context.GiayTos.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.GiayTo resutl = await _context.GiayTos.FirstOrDefaultAsync(c => c.MaGT == id);
            return _mapper.Map<Data.Model.GiayTo, Biz.Model.GiayTo.View>(resutl);
        }

        public async Task<View> UpdateAsync(EditByManager model)
        {
            Data.Model.GiayTo resutl = _mapper.Map<Model.GiayTo.EditByManager, Data.Model.GiayTo>(model);
            _context.GiayTos.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.GiayTo, View>(resutl);
        }

        public async  Task<View> UpdateAsync(Edit model)
        {
            Data.Model.GiayTo resutl = _mapper.Map<Model.GiayTo.Edit, Data.Model.GiayTo>(model);
            _context.GiayTos.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.GiayTo, View>(resutl);
        }
    }
}
