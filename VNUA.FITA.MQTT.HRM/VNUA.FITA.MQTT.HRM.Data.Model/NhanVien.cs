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
        [Display(Name ="STT")]
        public int IdNhanVien { get; set; }
        [Display(Name = "Mã Nhân Viên")]
        [StringLength(20, ErrorMessage = "Vui lòng nhập mã nhân viên")]
        public string MaNhanVien { get; set; }
        [Display(Name = "Họ Tên")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập họ tên nhân viên")]
        public string HoTen { get; set; }
        
        [StringLength(20, ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string TenTaiKhoan { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Giới Tính")]
        [StringLength(10, ErrorMessage = "Vui lòng nhập giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Địa Chỉ")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [StringLength(12, ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string MatKhau { get; set; }

        public int PhanQuyen { get; set; }
        [Display(Name = "Chức Vụ")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập chức vụ")]
        public string ChucVu { get; set; }
        [Display(Name = "Hình Ảnh")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập hình ảnh")]
        public string Anh { get; set; }
        [Display(Name = "Số Căn Cước")]
        [StringLength(12, ErrorMessage = "Vui lòng nhập số căn cước")]
        public string SoCCCD { get; set; }
        [Display(Name = "Trình Độ")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập trình độ học vấn")]
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
