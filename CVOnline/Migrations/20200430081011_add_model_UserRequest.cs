using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_UserRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_T_UserRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Applicants_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_UserRequest", x => x.Applicants_Id);
                    table.UniqueConstraint("AK_TB_T_UserRequest_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                        column: x => x.Applicants_Id,
                        principalTable: "TB_M_Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_UserRequest");
        }
    }
}
