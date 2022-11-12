using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.GiayTo
{
    public interface IRepository
    {
        Task<Model.GiayTo.View> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Model.GiayTo.View> UpdateAsync(Model.GiayTo.Edit model);
        Task<Model.GiayTo.View> UpdateAsync(Model.GiayTo.EditByManager model);
        Task<Model.GiayTo.View> CreatAsync(Model.GiayTo.New model);

    }
}
