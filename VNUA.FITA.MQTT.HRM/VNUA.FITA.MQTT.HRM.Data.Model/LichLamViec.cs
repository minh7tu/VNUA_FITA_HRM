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
    [Table("LichLamViec")]
    public class LichLamViec
    {
        [Key]
        public int MaLLV { get; set; }

        public DateTime SangBD { get; set; }

        public DateTime SangKT { get; set; }

        public DateTime ChieuBD { get; set; }

        public DateTime ChieuKT { get; set; }

        public IList<NhanVien> NhanVien { get; set; }
    }
}
