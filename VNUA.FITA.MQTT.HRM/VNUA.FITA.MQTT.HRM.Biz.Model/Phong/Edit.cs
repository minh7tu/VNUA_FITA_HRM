using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.Phong
{
    public class Edit
    {
        [StringLength(10)]
        public string MaP { get; set; }
        [StringLength(100)]
        public string TenP { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        public int SoLuong { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }
    }
}
