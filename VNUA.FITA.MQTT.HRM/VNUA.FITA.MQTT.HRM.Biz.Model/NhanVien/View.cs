﻿using System;
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

        [StringLength(100)]
        public string Anh { get; set; }

        [StringLength(12)]
        public string SoCCCD { get; set; }

        [StringLength(100)]
        public string TrinhDo { get; set; }

        public int IdBP { get; set; }
    }
}
