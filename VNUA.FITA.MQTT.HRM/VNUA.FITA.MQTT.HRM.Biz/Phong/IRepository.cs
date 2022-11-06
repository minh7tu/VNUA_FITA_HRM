using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.Phong
{
    public interface IRepository
    {
        Task<Model.Phong.View> GetAsync(int id);
        Task<Model.Phong.View> UpdateAsync(Model.Phong.Edit model);
        Task<Model.Phong.View> CreatAsync(Model.Phong.New model);
        Task DeleteAsync(int id);
    }
}
