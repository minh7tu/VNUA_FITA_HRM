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

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "hãy nhập tối thiểu 3 kí tự và tối đa 60 kí tự")]

        public string TenGT { get; set; }

        
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
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
