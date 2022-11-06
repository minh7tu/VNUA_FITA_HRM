using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.BoPhan
{
    public class Filter
    {
        [StringLength(10)]
        public string MaBP { get; set; }
    }
}
