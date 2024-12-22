using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KT.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocPhan",
                columns: table => new
                {
                    MaHP = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false),
                    TenHP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SoTinChi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HocPhan__2725A6EC674C9B0B", x => x.MaHP);
                });

            migrationBuilder.CreateTable(
                name: "NganhHoc",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NganhHoc__A2CEF50DEA666229", x => x.MaNganh);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    Hinh = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaNganh = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SinhVien__2725081ACCA00EBA", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK__SinhVien__MaNgan__398D8EEE",
                        column: x => x.MaNganh,
                        principalTable: "NganhHoc",
                        principalColumn: "MaNganh");
                });

            migrationBuilder.CreateTable(
                name: "DangKy",
                columns: table => new
                {
                    MaDK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDK = table.Column<DateOnly>(type: "date", nullable: true),
                    MaSV = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DangKy__2725866C5E56A861", x => x.MaDK);
                    table.ForeignKey(
                        name: "FK__DangKy__MaSV__3E52440B",
                        column: x => x.MaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDangKy",
                columns: table => new
                {
                    MaDK = table.Column<int>(type: "int", nullable: false),
                    MaHP = table.Column<string>(type: "char(6)", unicode: false, fixedLength: true, maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietD__F557DC0284907DC5", x => new { x.MaDK, x.MaHP });
                    table.ForeignKey(
                        name: "FK__ChiTietDan__MaDK__412EB0B6",
                        column: x => x.MaDK,
                        principalTable: "DangKy",
                        principalColumn: "MaDK");
                    table.ForeignKey(
                        name: "FK__ChiTietDan__MaHP__4222D4EF",
                        column: x => x.MaHP,
                        principalTable: "HocPhan",
                        principalColumn: "MaHP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangKy_MaHP",
                table: "ChiTietDangKy",
                column: "MaHP");

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_MaSV",
                table: "DangKy",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaNganh",
                table: "SinhVien",
                column: "MaNganh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDangKy");

            migrationBuilder.DropTable(
                name: "DangKy");

            migrationBuilder.DropTable(
                name: "HocPhan");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "NganhHoc");
        }
    }
}
