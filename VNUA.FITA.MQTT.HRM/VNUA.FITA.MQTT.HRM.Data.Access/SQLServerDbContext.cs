using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Data.Access
{
    public class SqlServerDbContext:DbContext
    {
        public SqlServerDbContext() : base() { }

        #region DbSet
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<DonTu> DonTus { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<GiayTo> GiayTos { get; set; }
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<KhenThuongKyLuat> KhenThuongKyLuats { get; set; }

        #endregion

        /// <summary>
        /// Config path SqlServer
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Path local Sql Nguyễn Đình Thuyết
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VNUA_FITA_HRM\VNUA.FITA.MQTT.HRM\VNUA.FITA.MQTT.HRM.Data.Access\Data\Database\HRM.mdf;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-PVP2JP42;Initial Catalog=D:\VNUA_FITA_HRM\VNUA.FITA.MQTT.HRM\VNUA.FITA.MQTT.HRM.DATA.ACCESS\DATA\DATABASE\HRM.MDF;User ID=sa;Password=quyet9x1");
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Le Manh\OneDrive\Máy tính\VNUA_FITA_HRM\VNUA.FITA.MQTT.HRM\VNUA.FITA.MQTT.HRM.Data.Access\Data\Database\HRM.mdf;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VNUA_FITA_HRM\VNUA.FITA.MQTT.HRM\VNUA.FITA.MQTT.HRM.Data.Access\Data\Database\HRM.mdf;Integrated Security=True");

        }
    }
}
