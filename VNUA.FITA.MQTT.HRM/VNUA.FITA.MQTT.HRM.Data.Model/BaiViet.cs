﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Data.Model
{
    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        public int MaBaiViet { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime ThoiGian { get; set; }

        [StringLength(20)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public ICollection<NhanVien> NhanViens { get; set; }

    }
}
