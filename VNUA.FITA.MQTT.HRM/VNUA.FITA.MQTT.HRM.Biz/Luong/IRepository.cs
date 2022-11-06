using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.Luong
{
    public interface IRepository
    {
        Task<Model.Luong.View> GetAsync(int id);
        Task<Model.Luong.View> UpdateAsync(Model.Luong.Edit model);
        Task<Model.Luong.View> CreatAsync(Model.Luong.New model);
        Task DeleteAsync(int id);
    }
}
