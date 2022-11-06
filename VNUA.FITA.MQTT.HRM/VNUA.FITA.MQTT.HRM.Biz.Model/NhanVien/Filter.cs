using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.NhanVien
{
    public class Filter
    {
        [StringLength(20)]
        public string MaNhanVien { get; set; }
    }
}
