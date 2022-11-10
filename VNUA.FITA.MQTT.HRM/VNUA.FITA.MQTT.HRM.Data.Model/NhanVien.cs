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
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int IdNhanVien { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string TenTaiKhoan { get; set; }

        public DateTime NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        public int PhanQuyen { get; set; }

        [StringLength(100)]
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [StringLength(12)]
        public string SoCCCD { get; set; }

        [StringLength(100)]
        public string TrinhDo{ get; set; }

        public int IdBP { get; set; }

        [ForeignKey("IdBP")]
        public BoPhan BoPhans { get; set; }
 
        public IList<DonTu> DonTus { get; set; }
        public IList<GiayTo> GiayTos { get; set; }
        public IList<Luong> Luongs { get; set; }
        public IList<ChamCong> ChamCongs { get; set; }
        public IList<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }
    }
}
