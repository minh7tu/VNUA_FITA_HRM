using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace VNUA.FITA.MQTT.HRM.Biz.AutoMapper
{
    class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Data.Model.BaiViet, Biz.Model.BaiViet.Edit>().ReverseMap();
            CreateMap<Data.Model.BaiViet, Biz.Model.BaiViet.Filter>().ReverseMap();
            CreateMap<Data.Model.BaiViet, Biz.Model.BaiViet.New>().ReverseMap();
            CreateMap<Data.Model.BaiViet, Biz.Model.BaiViet.View>().ReverseMap();

            CreateMap<Data.Model.BaoHiem, Biz.Model.BaoHiem.Edit>().ReverseMap();
            CreateMap<Data.Model.BaoHiem, Biz.Model.BaoHiem.Filter>().ReverseMap();
            CreateMap<Data.Model.BaiViet, Biz.Model.BaoHiem.New>().ReverseMap();
            CreateMap<Data.Model.BaoHiem, Biz.Model.BaoHiem.View>().ReverseMap();

            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.Edit>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.Filter>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.New>().ReverseMap();
            CreateMap<Data.Model.BoPhan, Biz.Model.BoPhan.View>().ReverseMap();

            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.Edit>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.EditByOther>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.Filter>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.New>().ReverseMap();
            CreateMap<Data.Model.DonTu, Biz.Model.DonTu.View>().ReverseMap();

            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.Edit>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.Filter>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.New>().ReverseMap();
            CreateMap<Data.Model.GiayTo, Biz.Model.GiayTo.View>().ReverseMap();

            CreateMap<Data.Model.HopDong, Biz.Model.HopDong.Edit>().ReverseMap();
            CreateMap<Data.Model.HopDong, Biz.Model.HopDong.Filter>().ReverseMap();
            CreateMap<Data.Model.HopDong, Biz.Model.HopDong.New>().ReverseMap();
            CreateMap<Data.Model.HopDong, Biz.Model.HopDong.View>().ReverseMap();

            CreateMap<Data.Model.LichLamViec, Biz.Model.LichLamViec.Edit>().ReverseMap();
            CreateMap<Data.Model.LichLamViec, Biz.Model.LichLamViec.Filter>().ReverseMap();
            CreateMap<Data.Model.LichLamViec, Biz.Model.LichLamViec.New>().ReverseMap();
            CreateMap<Data.Model.LichLamViec, Biz.Model.LichLamViec.View>().ReverseMap();

            CreateMap<Data.Model.Luong, Biz.Model.Luong.Edit>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.Filter>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.New>().ReverseMap();
            CreateMap<Data.Model.Luong, Biz.Model.Luong.View>().ReverseMap();

            CreateMap<Data.Model.NgayCong, Biz.Model.NgayCong.Edit>().ReverseMap();
            CreateMap<Data.Model.NgayCong, Biz.Model.NgayCong.Filter>().ReverseMap();
            CreateMap<Data.Model.NgayCong, Biz.Model.NgayCong.New>().ReverseMap();
            CreateMap<Data.Model.NgayCong, Biz.Model.NgayCong.View>().ReverseMap();

            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.Edit>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.EditByCalendar>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.EditByEnsua>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.EditByPassword>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.EditByVahicle>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.Filter>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.New>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.NewByCalendar>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.NewByEnsua>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.NewByVahicle>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.View>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.ViewByCalendar>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.ViewByEnsua>().ReverseMap();
            CreateMap<Data.Model.NhanVien, Biz.Model.NhanVien.ViewByVehicle>().ReverseMap();

            CreateMap<Data.Model.Phong, Biz.Model.Phong.Edit>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.Filter>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.New>().ReverseMap();
            CreateMap<Data.Model.Phong, Biz.Model.Phong.View>().ReverseMap();
        }
    }
}
