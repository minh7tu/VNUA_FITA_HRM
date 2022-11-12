using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien
{
    public class Edit
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
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [StringLength(12)]
        public string SoCCCD { get; set; }

        [StringLength(100)]
        public string TrinhDo { get; set; }

        public int IdBP { get; set; }
    }

    public class EditByAdmin
    {
        [StringLength(20)]
        public string MatKhau { get; set; }

        public int PhanQuyen { get; set; }
    }

    public class EditByStaff
    {
        [StringLength(20)]
        public string MatKhau { get; set; }
    }
}
