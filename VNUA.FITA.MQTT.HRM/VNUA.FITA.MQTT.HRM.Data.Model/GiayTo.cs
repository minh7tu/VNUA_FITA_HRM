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
    [Table("GiayTo")]
    public class GiayTo
    {
        [Key]
        public int MaGT { get; set; }

        [StringLength(100)]
        public string TenGT { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        public int IdNhanVien { get; set; }

        [ForeignKey("IdNhanVien")]
        public NhanVien NhanViens { get; set; }
    }
}
