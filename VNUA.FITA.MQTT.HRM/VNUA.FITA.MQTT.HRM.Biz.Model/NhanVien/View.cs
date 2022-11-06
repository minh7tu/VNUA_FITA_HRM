using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien
{
    public class View
    {
        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string TenTaiKhoan { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string ChucVu { get; set; }
        public byte Anh { get; set; }

        [StringLength(12)]
        public string SoCCCD { get; set; }

        [StringLength(10)]
        public string MaBP { get; set; }
    }

    public class ViewByVehicle
    {
        [StringLength(100)]
        public string HangXe { get; set; }

        [StringLength(100)]
        public string MauXe { get; set; }

        [StringLength(12)]
        public string BienSoXe { get; set; }
    }

    public class ViewByEnsua
    {
        public int MaBaoHiem { get; set; }
    }

    public class ViewByCalendar
    {
        public int MaLLV { get; set; }
    }
}
