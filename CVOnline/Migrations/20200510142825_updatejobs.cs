using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class updatejobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "TB_M_Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "TB_M_Jobs");
        }
    }
}
