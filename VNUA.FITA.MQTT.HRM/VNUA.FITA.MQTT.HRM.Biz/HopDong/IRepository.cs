using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.HopDong
{
    public interface IRepository
    {
        Task<Model.HopDong.View> GetAsync(int id);
        Task<Model.HopDong.View> UpdateAsync(Model.HopDong.Edit model);
        Task<Model.HopDong.View> CreatAsync(Model.HopDong.New model);
        Task DeleteAsync(int id);
    }
}
