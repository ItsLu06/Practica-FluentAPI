using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesFluent.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNivelPeligro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NivelPeligro",
                table: "Misiones",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "NivelPeligro",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "NivelPeligro",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 3,
                column: "NivelPeligro",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelPeligro",
                table: "Misiones");
        }
    }
}
