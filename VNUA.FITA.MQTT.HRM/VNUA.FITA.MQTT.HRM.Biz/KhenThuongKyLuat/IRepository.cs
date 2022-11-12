using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.KhenThuongKyLuat
{
    public interface IRepository
    {
        Task<Model.KhenThuongKyLuat.View> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Model.KhenThuongKyLuat.View> UpdateAsync(Model.KhenThuongKyLuat.Edit model);
        Task<Model.KhenThuongKyLuat.View> CreateAsync(Model.KhenThuongKyLuat.New model);
    }
}
