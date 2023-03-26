using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MucLuongs",
                columns: table => new
                {
                    TenMucLuong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoTien = table.Column<float>(type: "real", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucLuongs", x => x.TenMucLuong);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaPhongBan = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenMucLuong = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_MucLuongs_TenMucLuong",
                        column: x => x.TenMucLuong,
                        principalTable: "MucLuongs",
                        principalColumn: "TenMucLuong");
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    MaPhongBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaNguoiTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTruongMaNV = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.MaPhongBan);
                    table.ForeignKey(
                        name: "FK_PhongBans_NhanViens_NguoiTruongMaNV",
                        column: x => x.NguoiTruongMaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaPhongBan",
                table: "NhanViens",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_TenMucLuong",
                table: "NhanViens",
                column: "TenMucLuong");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_NguoiTruongMaNV",
                table: "PhongBans",
                column: "NguoiTruongMaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanViens_PhongBans_MaPhongBan",
                table: "NhanViens",
                column: "MaPhongBan",
                principalTable: "PhongBans",
                principalColumn: "MaPhongBan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_MucLuongs_TenMucLuong",
                table: "NhanViens");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanViens_PhongBans_MaPhongBan",
                table: "NhanViens");

            migrationBuilder.DropTable(
                name: "MucLuongs");

            migrationBuilder.DropTable(
                name: "PhongBans");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
