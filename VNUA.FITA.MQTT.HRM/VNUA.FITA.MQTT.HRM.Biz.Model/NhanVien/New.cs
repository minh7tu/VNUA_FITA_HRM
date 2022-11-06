using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien
{
    public class New
    {
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

        [StringLength(20)]
        public string MatKhau { get; set; }

        public int PhanLoai { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }
    }

    public class NewByVahicle
    {
        [StringLength(100)]
        public string HangXe { get; set; }

        [StringLength(100)]
        public string MauXe { get; set; }

        [StringLength(12)]
        public string BienSoXe { get; set; }
    }

    public class NewByCalendar
    {
        public int MaLLV { get; set; }
    }

    public class NewByEnsua
    {
        public int MaBaoHiem { get; set; }
    }

}
