using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_biodata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Biodata_Id",
                table: "TB_M_Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_M_Biodata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCard = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PlaceOfDate = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Religion = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Biodata", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_Biodata_Id",
                table: "TB_M_Applicants",
                column: "Biodata_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Applicants_TB_M_Biodata_Biodata_Id",
                table: "TB_M_Applicants",
                column: "Biodata_Id",
                principalTable: "TB_M_Biodata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Applicants_TB_M_Biodata_Biodata_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropTable(
                name: "TB_M_Biodata");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Applicants_Biodata_Id",
                table: "TB_M_Applicants");

            migrationBuilder.DropColumn(
                name: "Biodata_Id",
                table: "TB_M_Applicants");
        }
    }
}
