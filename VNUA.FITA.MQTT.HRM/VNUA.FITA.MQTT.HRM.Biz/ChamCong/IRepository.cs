using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.ChamCong
{
    public interface IRepository
    {
        Task<Model.ChamCong.View> GetAsync(int id);
        Task Delete(int id);
        Task<Model.ChamCong.View> UpdateAsync(Model.ChamCong.Edit model);
        Task<Model.ChamCong.View> CreateAsync(Model.ChamCong.New model);
    }
}
