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
        public byte[] Anh { get; set; }
        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanViens { get; set; }
    }
}
