using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    /// <summary>
    /// Nguyễn Đình Thuyết - K64CNPM - 646372
    /// </summary>
    [Table("BoPhan")]
    public class BoPhan
    {
        [Key]
        public int IdBoPhan { get; set; }

        [StringLength(10)]
        public string MaBP { get; set; }

        [StringLength(100)]
        public string TenBP { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public int SoLuong { get; set; }

        public int IdPhong { get; set; }

        [ForeignKey("IdPhong")]
        public Phong Phongs { get; set; }
       
        public IList<NhanVien> NhanViens { get; set; }
    }
}
