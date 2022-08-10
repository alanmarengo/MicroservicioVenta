using Microsoft.EntityFrameworkCore.Migrations;

namespace CapaAccesoDatos.Migrations
{
    public partial class AddColumnApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprobada",
                table: "Ventas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprobada",
                table: "Ventas");
        }
    }
}
