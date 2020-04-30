using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "TB_M_Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_User_Id",
                table: "TB_M_Applicants",
                column: "User_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicants_TB_M_Users_User_Id",
                table: "TB_M_Applicants",
                column: "User_Id",
                principalTable: "TB_M_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicants_TB_M_Users_User_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicants_User_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "TB_M_Applicants");
        }
    }
}
