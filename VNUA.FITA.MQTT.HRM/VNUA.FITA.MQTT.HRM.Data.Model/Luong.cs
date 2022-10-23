using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    /// <summary>
    /// Nguyễn Đình Thuyết - K64CNPM - 646372
    /// </summary>
    [Table("Luong")]
    public class Luong
    {
        [Key]
        public int MaLuong { get; set; }

        public double LCoBan { get; set; }

        public int HeSo { get; set; }

        public double PhiPhat { get; set; }

        public double PhiThue { get; set; }

        public double LThucNhan { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanViens { get; set; }
    }
}
