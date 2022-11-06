using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.BoPhan
{
    public interface IRepository
    {
        Task<Model.BoPhan.View> GetAsync(string id);
        Task<Model.BoPhan.View> UpdateAsync(Model.BoPhan.Edit model);
        Task<Model.BoPhan.View> CreatAsync(Model.BoPhan.New model);
        Task DeleteAsync(string id);
    }
}
