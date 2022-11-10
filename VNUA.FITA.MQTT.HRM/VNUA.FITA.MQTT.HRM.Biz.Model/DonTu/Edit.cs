using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.DonTu
{
    public class Edit
    {
        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }
        [StringLength(20)]
        public string NguoiNhan { get; set; }

        public int PhanLoai { get; set; }

        public DateTime ThoiGian { get; set; }

        public int IdNhanVien { get; set; }
    }

    public class EditByManager
    {
        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

    }
}
