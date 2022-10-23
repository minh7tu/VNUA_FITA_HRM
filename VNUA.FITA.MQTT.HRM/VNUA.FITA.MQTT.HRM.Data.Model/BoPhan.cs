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
        [StringLength(10)]
        public string MaBP { get; set; }

        [StringLength(100)]
        public string TenBP { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(10)]
        public string MaP { get; set; }

        [ForeignKey("MaP")]
        public Phong Phongs { get; set; }
       
        public IList<NhanVien> NhanViens { get; set; }
    }
}
