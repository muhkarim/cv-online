using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_educationaldetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationalDetails_Id",
                table: "TB_M_Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_EducationalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Majors = table.Column<string>(nullable: true),
                    YearOfEntry = table.Column<string>(nullable: true),
                    GraduationYear = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    FinalValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_EducationalDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_EducationalDetails_Id",
                table: "TB_M_Applicants",
                column: "EducationalDetails_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicants_TB_M_EducationalDetails_EducationalDetails_Id",
                table: "TB_M_Applicants",
                column: "EducationalDetails_Id",
                principalTable: "TB_M_EducationalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicants_TB_M_EducationalDetails_EducationalDetails_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropTable(
                name: "TB_M_EducationalDetails");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicants_EducationalDetails_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropColumn(
                name: "EducationalDetails_Id",
                table: "TB_M_Applicants");
        }
    }
}
