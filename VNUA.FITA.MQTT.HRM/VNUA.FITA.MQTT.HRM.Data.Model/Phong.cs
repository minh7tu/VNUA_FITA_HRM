﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    [Table("Phong")]
    public class Phong
    {
        [Key]
        [StringLength(10)]
        public string MaP { get; set; }

        [StringLength(100)]
        public string TenP { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public BoPhan BoPhan { get; set; }
    }
}
