using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.DonTu
{
    public interface IRepository
    {
        Task<Model.DonTu.View> GetAsync(int id);
        Task<Model.DonTu.View> UpdateAsync(Model.DonTu.Edit model);
        Task<Model.DonTu.View> UpdateByOtherAsync(Model.DonTu.EditByOther model);
        Task<Model.DonTu.View> CreatAsync(Model.DonTu.New model);
        Task DeleteAsync(int id);
    }
}
