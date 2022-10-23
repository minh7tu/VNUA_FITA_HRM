using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    [Table("BaoHiem")]
    public class BaoHiem
    {
        public int MaBaoHiem { get; set; }

        [StringLength(100)]
        public string TenBaoHiem { get; set; }

        [StringLength(255)]
        public string NoiDungBH { get; set; }

        [StringLength(100)]
        public string DonViCungCap { get; set; }

        public DateTime ThoiGianBD { get; set; }

        public DateTime ThoiGianKT { get; set; }

        public double ChiPhi { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
