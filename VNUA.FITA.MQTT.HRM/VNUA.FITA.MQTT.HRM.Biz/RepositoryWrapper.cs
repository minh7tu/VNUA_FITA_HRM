using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using VNUA.FITA.MQTT.HRM.Biz.BoPhan;
using VNUA.FITA.MQTT.HRM.Biz.ChamCong;
using VNUA.FITA.MQTT.HRM.Biz.DonTu;
using VNUA.FITA.MQTT.HRM.Biz.GiayTo;
using VNUA.FITA.MQTT.HRM.Biz.KhenThuongKyLuat;
using VNUA.FITA.MQTT.HRM.Biz.Luong;
using VNUA.FITA.MQTT.HRM.Biz.NhanVien;
using VNUA.FITA.MQTT.HRM.Biz.Phong;
using VNUA.FITA.MQTT.HRM.Data.Access;
using VNUA.FITA.MQTT.HRM.Data.Model;

namespace VNUA.FITA.MQTT.HRM.Biz
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private readonly SqlServerDbContext _context;
        private readonly ILogger<RepositoryWrapper> _logger;
        private readonly IMapper _mapper;

        public RepositoryWrapper(SqlServerDbContext context, ILogger<RepositoryWrapper> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        private BoPhan.IRepository _boPhan;
        public BoPhan.IRepository BoPhan => _boPhan ?? (_boPhan = new BoPhan.Repository(_context, _logger, _mapper));

        private ChamCong.IRepository _chamCong;
        public ChamCong.IRepository ChamCong => _chamCong ?? (_chamCong = new ChamCong.Repository(_context, _logger, _mapper));

        private DonTu.IRepository _donTu;
        public DonTu.IRepository DonTu => _donTu ?? (_donTu = new DonTu.Repository(_context, _logger, _mapper));

        private GiayTo.IRepository _giayTo;
        public GiayTo.IRepository GiayTo => _giayTo ?? (_giayTo = new GiayTo.Repository(_context, _logger, _mapper));

        private KhenThuongKyLuat.IRepository _khenThuongKyLuat;
        public KhenThuongKyLuat.IRepository KhenThuongKyLuat => _khenThuongKyLuat ?? (_khenThuongKyLuat = new KhenThuongKyLuat.Repository(_context, _logger, _mapper));

        private Luong.IRepository _luong;
        public Luong.IRepository Luong => _luong ?? (_luong = new Luong.Repository(_context, _logger, _mapper));

        private NhanVien.IRepository _nhanVien;
        public NhanVien.IRepository NhanVien => _nhanVien ?? (_nhanVien = new NhanVien.Repository(_context, _logger, _mapper));

        private Phong.IRepository _phong;
        public Phong.IRepository Phong => _phong ?? (_phong = new Phong.Repository(_context, _logger, _mapper));
    }
}
