using System;
using System.Collections.Generic;
using System.Text;

namespace VNUA.FITA.MQTT.HRM.Biz
{
    public interface IRepositoryWrapper
    {
        public BoPhan.IRepository BoPhan { get; }
        public ChamCong.IRepository ChamCong { get; }
        public DonTu.IRepository DonTu { get; }
        public GiayTo.IRepository GiayTo { get; }
        public KhenThuongKyLuat.IRepository KhenThuongKyLuat { get; }
        public Luong.IRepository Luong { get; }
        public NhanVien.IRepository NhanVien { get; }
        public Phong.IRepository Phong { get; }
    }
}
