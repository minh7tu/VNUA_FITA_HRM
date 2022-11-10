using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VNUA.FITA.MQTT.HRM.Data.Access.Data.Migrations.SqlServer
{
    public partial class inital_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    IdPhong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaP = table.Column<string>(maxLength: 10, nullable: true),
                    TenP = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    SDT = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.IdPhong);
                });

            migrationBuilder.CreateTable(
                name: "BoPhan",
                columns: table => new
                {
                    IdBoPhan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBP = table.Column<string>(maxLength: 10, nullable: true),
                    TenBP = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SDT = table.Column<string>(maxLength: 12, nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    IdPhong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhan", x => x.IdBoPhan);
                    table.ForeignKey(
                        name: "FK_BoPhan_Phong_IdPhong",
                        column: x => x.IdPhong,
                        principalTable: "Phong",
                        principalColumn: "IdPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    IdNhanVien = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(maxLength: 20, nullable: true),
                    HoTen = table.Column<string>(maxLength: 100, nullable: true),
                    TenTaiKhoan = table.Column<string>(maxLength: 20, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    GioiTinh = table.Column<string>(maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 100, nullable: true),
                    SDT = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(maxLength: 20, nullable: true),
                    PhanQuyen = table.Column<int>(nullable: false),
                    ChucVu = table.Column<string>(maxLength: 100, nullable: true),
                    Anh = table.Column<string>(maxLength: 100, nullable: true),
                    SoCCCD = table.Column<string>(maxLength: 12, nullable: true),
                    TrinhDo = table.Column<string>(maxLength: 100, nullable: true),
                    IdBP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.IdNhanVien);
                    table.ForeignKey(
                        name: "FK_NhanVien_BoPhan_IdBP",
                        column: x => x.IdBP,
                        principalTable: "BoPhan",
                        principalColumn: "IdBoPhan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    IdCong = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    IdNhanVien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.IdCong);
                    table.ForeignKey(
                        name: "FK_ChamCong_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonTu",
                columns: table => new
                {
                    IdDonTu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    NguoiNhan = table.Column<string>(maxLength: 20, nullable: true),
                    PhanLoai = table.Column<int>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    IdNhanVien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonTu", x => x.IdDonTu);
                    table.ForeignKey(
                        name: "FK_DonTu_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiayTo",
                columns: table => new
                {
                    MaGT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGT = table.Column<string>(maxLength: 100, nullable: true),
                    Anh = table.Column<string>(maxLength: 100, nullable: true),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    IdNhanVien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayTo", x => x.MaGT);
                    table.ForeignKey(
                        name: "FK_GiayTo_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuongKyLuat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 100, nullable: true),
                    NoiDung = table.Column<string>(maxLength: 255, nullable: true),
                    GiaTri = table.Column<double>(nullable: false),
                    PhanLoai = table.Column<int>(nullable: false),
                    ThoiGian = table.Column<DateTime>(nullable: false),
                    IdNhanVien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuongKyLuat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhenThuongKyLuat_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
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
                    TrangThai = table.Column<string>(maxLength: 100, nullable: true),
                    IdNhanVien = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_Luong_NhanVien_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoPhan_IdPhong",
                table: "BoPhan",
                column: "IdPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_IdNhanVien",
                table: "ChamCong",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DonTu_IdNhanVien",
                table: "DonTu",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_GiayTo_IdNhanVien",
                table: "GiayTo",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuongKyLuat_IdNhanVien",
                table: "KhenThuongKyLuat",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_IdNhanVien",
                table: "Luong",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IdBP",
                table: "NhanVien",
                column: "IdBP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "DonTu");

            migrationBuilder.DropTable(
                name: "GiayTo");

            migrationBuilder.DropTable(
                name: "KhenThuongKyLuat");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "BoPhan");

            migrationBuilder.DropTable(
                name: "Phong");
        }
    }
}
