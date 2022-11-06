using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.BaiViet
{
    /// <summary>
    /// Thuyết - Tạo mới bằng các thuộc tính
    /// </summary>
    public class New
    {

        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }
    }
}
