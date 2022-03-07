using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallenge.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imagen",
                table: "Personajes",
                newName: "Imagen");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Generos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Generos");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Personajes",
                newName: "imagen");
        }
    }
}
