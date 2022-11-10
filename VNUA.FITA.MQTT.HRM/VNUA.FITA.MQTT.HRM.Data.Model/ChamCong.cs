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
    [Table("ChamCong")]
    public class ChamCong
    {
        [Key]
        public int IdCong { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set;}

        [StringLength(100)]
        public string GhiChu { get; set; }

        public int IdNhanVien { get; set; }

        [ForeignKey("IdNhanVien")]
        public NhanVien NhanViens { get; set; }

    }
}
