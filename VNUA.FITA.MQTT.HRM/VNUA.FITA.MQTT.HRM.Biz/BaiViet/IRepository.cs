using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.BaiViet
{
    public interface IRepository
    {
        Task<Model.BaiViet.View> GetAsync(int id);
        Task<Model.BaiViet.View> UpdateAsync(Model.BaiViet.Edit model);
        Task<Model.BaiViet.View> CreatAsync(Model.BaiViet.New model);
        Task DeleteAsync(int id);
    }
}
