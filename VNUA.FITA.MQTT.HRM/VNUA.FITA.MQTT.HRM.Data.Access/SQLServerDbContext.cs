using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Data.Access
{
    /// <summary>
    /// Nguyễn Đình Thuyết - K64CNPM - 646372
    /// </summary>
    class SQLServerDbContext:DbContext
    {
        public SQLServerDbContext() : base() { }

        #region DbSet
        DbSet<Phong> Phongs { get; set; }
        DbSet<BoPhan> BoPhans { get; set; }
        DbSet<DonTu> DonTus { get; set; }
        DbSet<Luong> Luongs { get; set; }
        DbSet<NhanVien> NhanViens { get; set; }
        DbSet<BaiViet> BaiViets { get; set; }
        DbSet<HopDong> HopDongs { get; set; }
        DbSet<GiayTo> GiayTos { get; set; }
        DbSet<NgayCong> NgayCongs { get; set; }
        DbSet<LichLamViec> LichLamViecs { get; set; }
        DbSet<BaoHiem> BaoHiems { get; set; }
        #endregion


        /// <summary>
        /// Config path SqlServer
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Path local Sql Nguyễn Đình Thuyết
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\TTCN\Code\VNUA_FITA_HRM\VNUA.FITA.MQTT.HRM\VNUA.FITA.MQTT.HRM.Data.Access\Data\Database\HRM.mdf;Integrated Security=True");
        }
    }
}
