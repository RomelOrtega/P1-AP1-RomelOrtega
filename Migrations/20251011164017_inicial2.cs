using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_AP1_RomelOrtega.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 1,
                column: "Existencia",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 2,
                column: "Existencia",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 3,
                column: "Existencia",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 4,
                column: "Existencia",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 5,
                column: "Existencia",
                value: 10);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 6,
                column: "Existencia",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 1,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 2,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 3,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 4,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 5,
                column: "Existencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TiposHuacales",
                keyColumn: "IdTipo",
                keyValue: 6,
                column: "Existencia",
                value: 0);
        }
    }
}
