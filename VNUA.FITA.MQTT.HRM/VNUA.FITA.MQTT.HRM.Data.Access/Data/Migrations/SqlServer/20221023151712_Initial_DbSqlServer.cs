using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VNUA.FITA.MQTT.HRM.Data.Access.Data.Migrations.SqlServer
{
    public partial class Initial_DbSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoHiem",
                columns: table => new
                {
                    MaBaoHiem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaoHiem = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDungBH = table.Column<string>(maxLength: 255, nullable: true),
                    DonViCungCap = table.Column<string>(maxLength: 100, nullable: true),
                    ThoiGianBD = table.Column<DateTime>(nullable: false),
                    ThoiGianKT = table.Column<DateTime>(nullable: false),
                    ChiPhi = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiem", x => x.MaBaoHiem);
                });

            migrationBuilder.CreateTable(
                name: "LichLamViec",
                columns: table => new
                {
                    MaLLV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SangBD = table.Column<DateTime>(nullable: false),
                    SangKT = table.Column<DateTime>(nullable: false),
                    ChieuBD = table.Column<DateTime>(nullable: false),
                    ChieuKT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichLamViec", x => x.MaLLV);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaP = table.Column<string>(maxLength: 10, nullable: false),
                    TenP = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SDT = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.MaP);
                });

            migrationBuilder.CreateTable(
                name: "BoPhan",
                columns: table => new
                {
                    MaBP = table.Column<string>(maxLength: 10, nullable: false),
                    TenBP = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SDT = table.Column<string>(maxLength: 12, nullable: true),
                    MaP = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhan", x => x.MaBP);
                    table.ForeignKey(
                        name: "FK_BoPhan_Phong_MaP",
                        column: x => x.MaP,
                        principalTable: "Phong",
                        principalColumn: "MaP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    TenTaiKhoan = table.Column<string>(maxLength: 20, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<string>(maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: true),
                    SDT = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(maxLength: 20, nullable: true),
                    PhanLoai = table.Column<int>(nullable: false),
                    ChucVu = table.Column<string>(maxLength: 100, nullable: true),
                    HangXe = table.Column<string>(maxLength: 100, nullable: true),
                    MauXe = table.Column<string>(maxLength: 100, nullable: true),
                    BienSoXe = table.Column<string>(maxLength: 12, nullable: true),
                    Anh = table.Column<byte>(nullable: false),
                    SoCCCD = table.Column<string>(maxLength: 12, nullable: true),
                    MaBP = table.Column<string>(maxLength: 10, nullable: true),
                    MaLLV = table.Column<int>(nullable: false),
                    MaBaoHiem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_BoPhan_MaBP",
                        column: x => x.MaBP,
                        principalTable: "BoPhan",
                        principalColumn: "MaBP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_BaoHiem_MaBaoHiem",
                        column: x => x.MaBaoHiem,
                        principalTable: "BaoHiem",
                        principalColumn: "MaBaoHiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_LichLamViec_MaLLV",
                        column: x => x.MaLLV,
                        principalTable: "LichLamViec",
                        principalColumn: "MaLLV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    MaBaiViet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.MaBaiViet);
                    table.ForeignKey(
                        name: "FK_BaiViet_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonTu",
                columns: table => new
                {
                    MaDonTu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    NguoiNhan = table.Column<string>(maxLength: 20, nullable: true),
                    PhanLoai = table.Column<int>(nullable: false),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonTu", x => x.MaDonTu);
                    table.ForeignKey(
                        name: "FK_DonTu_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiayTo",
                columns: table => new
                {
                    MaGT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGT = table.Column<string>(maxLength: 100, nullable: true),
                    Anh = table.Column<byte[]>(nullable: true),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayTo", x => x.MaGT);
                    table.ForeignKey(
                        name: "FK_GiayTo_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    SoHD = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHD = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDungHD = table.Column<string>(maxLength: 255, nullable: true),
                    ThoiGianBD = table.Column<DateTime>(nullable: false),
                    ThoiGianKT = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    PhanLoai = table.Column<int>(nullable: false),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.SoHD);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LCoBan = table.Column<double>(nullable: false),
                    HeSo = table.Column<int>(nullable: false),
                    PhiPhat = table.Column<double>(nullable: false),
                    PhiThue = table.Column<double>(nullable: false),
                    LThucNhan = table.Column<double>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NgayCong",
                columns: table => new
                {
                    MaCong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoCong = table.Column<int>(nullable: false),
                    SoCgDiMuon = table.Column<int>(nullable: false),
                    SoCVang = table.Column<int>(nullable: false),
                    SoCThucTe = table.Column<int>(nullable: false),
                    ThoiGianBD = table.Column<DateTime>(nullable: false),
                    ThoiGianKT = table.Column<DateTime>(nullable: false),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgayCong", x => x.MaCong);
                    table.ForeignKey(
                        name: "FK_NgayCong_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_MaNhanVien",
                table: "BaiViet",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhan_MaP",
                table: "BoPhan",
                column: "MaP");

            migrationBuilder.CreateIndex(
                name: "IX_DonTu_MaNhanVien",
                table: "DonTu",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiayTo_MaNhanVien",
                table: "GiayTo",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_MaNhanVien",
                table: "HopDong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_MaNhanVien",
                table: "Luong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NgayCong_MaNhanVien",
                table: "NgayCong",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaBP",
                table: "NhanVien",
                column: "MaBP");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaBaoHiem",
                table: "NhanVien",
                column: "MaBaoHiem");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaLLV",
                table: "NhanVien",
                column: "MaLLV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "DonTu");

            migrationBuilder.DropTable(
                name: "GiayTo");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NgayCong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "BoPhan");

            migrationBuilder.DropTable(
                name: "BaoHiem");

            migrationBuilder.DropTable(
                name: "LichLamViec");

            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}
