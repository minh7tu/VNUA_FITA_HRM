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
    [Table("HopDong")]
    public class HopDong
    {
        [Key]
        public long SoHD { get; set; }

        [StringLength(100)]
        public string TenHD { get; set; }

        [StringLength(255)]
        public string NoiDungHD { get; set; }

        public DateTime ThoiGianBD { get; set; }

        public DateTime ThoiGianKT { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        public int PhanLoai { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanViens { get; set; }

    }
}
