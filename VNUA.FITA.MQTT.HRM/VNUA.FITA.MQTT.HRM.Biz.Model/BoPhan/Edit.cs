using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.BoPhan
{
    public class Edit
    {
        [StringLength(100)]
        public string TenBP { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }
        [StringLength(10)]
        public string MaP { get; set; }
    }
}
