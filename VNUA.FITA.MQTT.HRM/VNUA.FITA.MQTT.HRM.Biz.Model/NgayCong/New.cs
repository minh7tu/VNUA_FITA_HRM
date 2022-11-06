using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NgayCong
{
    public class New
    {
        public int SoCong { get; set; }

        public int SoCgDiMuon { get; set; }

        public int SoCVang { get; set; }

        public int SoCThucTe { get; set; }

        public DateTime ThoiGianBD { get; set; }

        public DateTime ThoiGianKT { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }
    }
}
