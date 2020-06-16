using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIOUI.Site.Migrations
{
    public partial class RemoveCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Alunos",
                nullable: true);
        }
    }
}
