using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien
{
    public class Edit
    {
        [StringLength(100)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }
        [StringLength(100)]
        public string ChucVu { get; set; }
        public byte Anh { get; set; }

        [StringLength(12)]
        public string SoCCCD { get; set; }
        [StringLength(10)]
        public string MaBP { get; set; }
    }

    public class EditByPassword
    {

        [StringLength(20)]
        public string MatKhau { get; set; }
    }

    public class EditByVahicle
    {
        [StringLength(100)]
        public string HangXe { get; set; }

        [StringLength(100)]
        public string MauXe { get; set; }

        [StringLength(12)]
        public string BienSoXe { get; set; }
    }

    public class EditByCalendar
    {
        public int MaLLV { get; set; }
    }

    public class EditByEnsua
    {
        public int MaBaoHiem { get; set; }
    }
}
