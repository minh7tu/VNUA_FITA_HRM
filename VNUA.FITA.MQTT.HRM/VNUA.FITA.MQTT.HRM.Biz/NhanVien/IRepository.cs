using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.NhanVien
{
    public interface IRepository
    {
        Task<Model.NhanVien.View> GetAsync(long id);
        Task DeleteAsync(int id);
        Task<Model.NhanVien.View> UpdateAsync(Model.NhanVien.Edit model);
        Task<Model.NhanVien.View> UpdateAsync(Model.NhanVien.EditByAdmin model);
        Task<Model.NhanVien.View> UpdateAsync(Model.NhanVien.EditByStaff model);
        Task<Model.NhanVien.View> CreateAsync(Model.NhanVien.New model);
        Task<Model.NhanVien.View> CreateAsync(Model.NhanVien.NewByAdmin model);
    }
}
