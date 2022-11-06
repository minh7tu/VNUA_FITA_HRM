using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.LichLamViec
{
    public interface IRepository
    {
        Task<Model.LichLamViec.View> GetAsync(int id);
        Task<Model.LichLamViec.View> UpdateAsync(Model.LichLamViec.Edit model);
        Task<Model.LichLamViec.View> CreatAsync(Model.LichLamViec.New model);
        Task DeleteAsync(int id);
    }
}
