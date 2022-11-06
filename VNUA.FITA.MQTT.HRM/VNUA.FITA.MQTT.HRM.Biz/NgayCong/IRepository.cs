using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.NgayCong
{
    public interface IRepository
    {
        Task<Model.NgayCong.View> GetAsync(int id);
        Task<Model.NgayCong.View> UpdateAsync(Model.NgayCong.Edit model);
        Task<Model.NgayCong.View> CreatAsync(Model.NgayCong.New model);
        Task DeleteAsync(int id);
    }
}
