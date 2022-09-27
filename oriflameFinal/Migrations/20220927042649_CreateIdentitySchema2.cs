using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oriflameFinal.Migrations
{
    public partial class CreateIdentitySchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pruebaCampo",
                table: "departamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pruebaCampo",
                table: "departamentos");
        }
    }
}
