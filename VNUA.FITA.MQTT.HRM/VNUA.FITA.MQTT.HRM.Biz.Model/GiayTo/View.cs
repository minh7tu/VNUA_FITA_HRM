using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.GiayTo
{
    public class View
    {
        [StringLength(100)]
        public string TenGT { get; set; }
        public byte[] Anh { get; set; }
    }
}
