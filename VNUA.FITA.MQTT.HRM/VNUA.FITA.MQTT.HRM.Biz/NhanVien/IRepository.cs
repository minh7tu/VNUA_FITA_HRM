using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VNUA.FITA.MQTT.HRM.Biz.NhanVien
{
    public interface IRepository
    {
        Task<Model.NhanVien.View> GetAsync(int id);
        Task<Model.NhanVien.View> UpdateAsync(Model.NhanVien.Edit model);
        Task<Model.NhanVien.ViewByCalendar> UpdateByCalendarAsync(Model.NhanVien.EditByCalendar model);
        Task<Model.NhanVien.ViewByEnsua> UpdateByEnsuaAsync(Model.NhanVien.EditByEnsua model);
        Task<Model.NhanVien.View> UpdateByPasswordAsync(Model.NhanVien.EditByPassword model);
        Task<Model.NhanVien.ViewByVehicle> UpdateByVahicleAsync(Model.NhanVien.EditByVahicle model);
        Task<Model.NhanVien.View> CreatAsync(Model.NhanVien.New model);
        Task<Model.NhanVien.ViewByCalendar> CreatByCalendarAsync(Model.NhanVien.NewByCalendar model);
        Task<Model.NhanVien.ViewByEnsua> CreatByEnsuaAsync(Model.NhanVien.NewByEnsua model);
        Task<Model.NhanVien.ViewByVehicle> CreatByVahicleAsync(Model.NhanVien.NewByVahicle model);
        Task DeleteAsync(int id);
    }
}
