using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.BaoHiem
{
    public interface IRepository
    {
        Task<Model.BaoHiem.View> GetAsync(int id);
        Task<Model.BaoHiem.View> UpdateAsync(Model.BaoHiem.Edit model);
        Task<Model.BaoHiem.View> CreatAsync(Model.BaoHiem.New model);
        Task DeleteAsync(int id);
    }
}
