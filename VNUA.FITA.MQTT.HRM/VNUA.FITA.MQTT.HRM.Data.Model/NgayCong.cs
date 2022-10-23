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
    [Table("NgayCong")]
    public class NgayCong
    {
        [Key]
        public int MaCong { get; set; }

        public int SoCong { get; set; }

        public int SoCgDiMuon { get; set;}

        public int SoCVang { get; set; }

        public int SoCThucTe { get; set; }

        public DateTime ThoiGianBD { get; set; }

        public DateTime ThoiGianKT { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanViens { get; set; }

    }
}
