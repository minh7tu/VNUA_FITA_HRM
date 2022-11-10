using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.Luong
{
    public class New
    {
        public double LCoBan { get; set; }

        public int HeSo { get; set; }

        public double PhiPhat { get; set; }

        public double PhiThue { get; set; }

        public double LThucNhan { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        public int IdNhanVien { get; set; }
    }
}
