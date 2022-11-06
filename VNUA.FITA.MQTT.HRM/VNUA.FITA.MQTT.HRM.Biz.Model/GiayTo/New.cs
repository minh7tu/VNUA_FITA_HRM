using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz.Model.GiayTo
{
    public class New
    {
        [StringLength(100)]
        public string TenGT { get; set; }
        public byte[] Anh { get; set; }
        [StringLength(20)]
        public string MaNhanVien { get; set; }
    }
}
