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

        [StringLength(100)]
        public string Anh { get; set; }

        public DateTime ThoiGian { get; set; }

        public int IdNhanVien { get; set; }
    }
}
