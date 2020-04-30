using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_WorkExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkExperience_Id",
                table: "TB_M_Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_WorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    LastPosition = table.Column<string>(nullable: true),
                    TypeOfBussiness = table.Column<string>(nullable: true),
                    YearStartedWorking = table.Column<string>(nullable: true),
                    YearOfResign = table.Column<string>(nullable: true),
                    LastSalary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_WorkExperience", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_WorkExperience_Id",
                table: "TB_M_Applicants",
                column: "WorkExperience_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperience_Id",
                table: "TB_M_Applicants",
                column: "WorkExperience_Id",
                principalTable: "TB_M_WorkExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperience_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropTable(
                name: "TB_M_WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicants_WorkExperience_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropColumn(
                name: "WorkExperience_Id",
                table: "TB_M_Applicants");
        }
    }
}
