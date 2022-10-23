using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    [Table("DonTu")]
    public class DonTu
    {
        [Key]
        public int MaDonTu { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(20)]
        public string NguoiNhan { get; set; }

        public int PhanLoai { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public ICollection<NhanVien> NhanViens { get; set; }


    }
}
