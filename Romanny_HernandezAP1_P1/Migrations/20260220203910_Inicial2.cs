using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Romanny_HernandezAP1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Costo",
                table: "EntradasHuacales",
                newName: "Precio");

            migrationBuilder.AddColumn<double>(
                name: "Cantidad",
                table: "EntradasHuacales",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "EntradasHuacales");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "EntradasHuacales",
                newName: "Costo");
        }
    }
}
