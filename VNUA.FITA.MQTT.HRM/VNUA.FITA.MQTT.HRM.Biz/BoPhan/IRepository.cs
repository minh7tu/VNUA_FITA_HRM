using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.BoPhan
{
    public interface IRepository
    {
        Task<Model.BoPhan.View> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Model.BoPhan.View> CreateAsync(Model.BoPhan.New model);
        Task<Model.BoPhan.View> UpdateAsync(Model.BoPhan.Edit model);

    }
}
