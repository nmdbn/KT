using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KT.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableChiTietDangKy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaHP",
                table: "ChiTietDangKy",
                newName: "MaHp");

            migrationBuilder.RenameColumn(
                name: "MaDK",
                table: "ChiTietDangKy",
                newName: "MaDk");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDangKy_MaHP",
                table: "ChiTietDangKy",
                newName: "IX_ChiTietDangKy_MaHp");

            migrationBuilder.AlterColumn<string>(
                name: "MaHp",
                table: "ChiTietDangKy",
                type: "char(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(6)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 6)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "MaDk",
                table: "ChiTietDangKy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateTable(
                name: "DangKyHocPhan",
                columns: table => new
                {
                    MaDksMaDk = table.Column<int>(type: "int", nullable: false),
                    MaHpsMaHp = table.Column<string>(type: "char(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHocPhan", x => new { x.MaDksMaDk, x.MaHpsMaHp });
                    table.ForeignKey(
                        name: "FK_DangKyHocPhan_DangKy_MaDksMaDk",
                        column: x => x.MaDksMaDk,
                        principalTable: "DangKy",
                        principalColumn: "MaDK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHocPhan_HocPhan_MaHpsMaHp",
                        column: x => x.MaHpsMaHp,
                        principalTable: "HocPhan",
                        principalColumn: "MaHP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHocPhan_MaHpsMaHp",
                table: "DangKyHocPhan",
                column: "MaHpsMaHp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKyHocPhan");

            migrationBuilder.RenameColumn(
                name: "MaHp",
                table: "ChiTietDangKy",
                newName: "MaHP");

            migrationBuilder.RenameColumn(
                name: "MaDk",
                table: "ChiTietDangKy",
                newName: "MaDK");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDangKy_MaHp",
                table: "ChiTietDangKy",
                newName: "IX_ChiTietDangKy_MaHP");

            migrationBuilder.AlterColumn<string>(
                name: "MaHP",
                table: "ChiTietDangKy",
                type: "char(6)",
                unicode: false,
                fixedLength: true,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(6)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "MaDK",
                table: "ChiTietDangKy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
