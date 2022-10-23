using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    [Table("LichLamViec")]
    public class LichLamViec
    {
        public int MaLLV { get; set; }

        public DateTime SangBD { get; set; }

        public DateTime SangKT { get; set; }

        public DateTime ChieuBD { get; set; }

        public DateTime ChieuKT { get; set; }

        public NhanVien NhanVien { get; set; }
    }
}
