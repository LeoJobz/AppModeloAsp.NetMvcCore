using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIOUI.Site.Migrations
{
    public partial class CPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Alunos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Alunos");
        }
    }
}
