using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.Phong
{
    public class Filter
    {
        [StringLength(10)]
        public string MaP { get; set; }
    }
}
