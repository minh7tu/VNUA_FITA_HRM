using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Model.Phong, Biz.Model.Phong.Edit>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.Filter>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.New>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.View>().ReverseMap();

            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.Edit>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.Filter>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.New>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.View>().ReverseMap();

            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.Edit>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.Filter>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.New>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.View>().ReverseMap();

            CreateMap<Data.Model.Luong, Biz.Model.Luong.Edit>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.Filter>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.New>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.View>().ReverseMap();

            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.Edit>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.Filter>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.New>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.View>().ReverseMap();

            CreateMap<Data.Model.ChamCong, Biz.Model.ChamCong.Edit>().ReverseMap();
            CreateMap<Data.Model.ChamCong, Biz.Model.ChamCong.Filter>().ReverseMap();
            CreateMap<Data.Model.ChamCong, Biz.Model.ChamCong.New>().ReverseMap();
            CreateMap<Data.Model.ChamCong, Biz.Model.ChamCong.View>().ReverseMap();

            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.Edit>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.Filter>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.New>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.View>().ReverseMap();

            CreateMap<Data.Model.KhenThuongKyLuat, Biz.Model.KhenThuongKyLuat.Edit>().ReverseMap();
            CreateMap<Data.Model.KhenThuongKyLuat, Biz.Model.KhenThuongKyLuat.Filter>().ReverseMap();
            CreateMap<Data.Model.KhenThuongKyLuat, Biz.Model.KhenThuongKyLuat.New>().ReverseMap();
            CreateMap<Data.Model.KhenThuongKyLuat, Biz.Model.KhenThuongKyLuat.View>().ReverseMap();
        }
    }
}
