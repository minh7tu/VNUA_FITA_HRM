using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.BaiViet
{
    /// <summary>
    /// Thuyết - Hiển thị các thông tin tiêu đề, nội dung, thời gian
    /// </summary>
    public class View
    {
        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }
    }
}
