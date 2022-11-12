using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.ChamCong
{
    public class Edit
    {
        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }
    }
}
