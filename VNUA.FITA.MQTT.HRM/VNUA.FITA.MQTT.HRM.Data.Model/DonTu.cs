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
    [Table("DonTu")]
    public class DonTu
    {
        [Key]
        public int IdDonTu { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "hãy nhập tối thiểu 3 kí tự và tối đa 100 kí tự")]
        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        public string TieuDe { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "nội dung không được bỏ trống")]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(20)]
        public string NguoiNhan { get; set; }

        public int PhanLoai { get; set; }

        public DateTime ThoiGian { get; set; }

        public int IdNhanVien { get; set; }

        [ForeignKey("IdNhanVien")]
        public NhanVien NhanViens { get; set; }


    }
}
