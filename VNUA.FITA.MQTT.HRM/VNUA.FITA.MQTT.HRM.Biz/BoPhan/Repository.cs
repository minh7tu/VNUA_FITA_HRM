using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VNUA.FITA.MQTT.HRM.Biz.Model.BoPhan;
using VNUA.FITA.MQTT.HRM.Data.Access;

namespace VNUA.FITA.MQTT.HRM.Biz.BoPhan
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
            Data.Model.BoPhan result = _mapper.Map<New, Data.Model.BoPhan>(model);
            await _context.BoPhans.AddAsync(result);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.BoPhan, View>(result);
        }

        public async Task DeleteAsync(int id)
        {
            Data.Model.BoPhan resutl = new Data.Model.BoPhan() { IdBoPhan = id };
            _context.BoPhans.Remove(resutl);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetAsync(int id)
        {
            Data.Model.BoPhan resutl = await _context.BoPhans.FirstOrDefaultAsync(c => c.IdBoPhan == id);
            return _mapper.Map<Data.Model.BoPhan, View>(resutl);
        }

        public async Task<View> UpdateAsync(Edit model)
        {
            Data.Model.BoPhan resutl = _mapper.Map<Edit, Data.Model.BoPhan>(model);
            _context.BoPhans.Update(resutl);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.BoPhan, View>(resutl);
        }
    }
}
