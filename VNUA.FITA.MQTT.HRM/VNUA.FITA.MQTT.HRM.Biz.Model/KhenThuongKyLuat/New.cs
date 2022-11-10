using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.KhenThuongKyLuat
{
    public class New
    {
        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public double GiaTri { get; set; }

        public int PhanLoai { get; set; }

        public DateTime ThoiGian { get; set; }

        public int IdNhanVien { get; set; }
    }
}
