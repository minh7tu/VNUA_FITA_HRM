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
    [Table("KhenThuongKyLuat")]
    public class KhenThuongKyLuat
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public double GiaTri { get; set; }

        public int PhanLoai { get; set; }

        public DateTime ThoiGian { get; set; }

        public int IdNhanVien { get; set; }

        [ForeignKey("IdNhanVien")]
        public NhanVien NhanViens{ get; set; }
    }
}
