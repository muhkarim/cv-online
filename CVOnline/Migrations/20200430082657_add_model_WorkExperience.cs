using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_WorkExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                table: "TB_T_UserRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Applicants",
                table: "TB_M_Applicants");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_M_Applicants",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "WorkExperience_Id",
                table: "TB_M_Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Applicants",
                table: "TB_M_Applicants",
                column: "WorkExperience_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperience_Id",
                table: "TB_M_Applicants",
                column: "WorkExperience_Id",
                principalTable: "TB_M_WorkExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                table: "TB_T_UserRequest",
                column: "Applicants_Id",
                principalTable: "TB_M_Applicants",
                principalColumn: "WorkExperience_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperience_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                table: "TB_T_UserRequest");

            migrationBuilder.DropTable(
                name: "TB_M_WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Applicants",
                table: "TB_M_Applicants");

            migrationBuilder.DropColumn(
                name: "WorkExperience_Id",
                table: "TB_M_Applicants");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_M_Applicants",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Applicants",
                table: "TB_M_Applicants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                table: "TB_T_UserRequest",
                column: "Applicants_Id",
                principalTable: "TB_M_Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
