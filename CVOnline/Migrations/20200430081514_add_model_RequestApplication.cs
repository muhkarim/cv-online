using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_RequestApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_UserRequest",
                table: "TB_T_UserRequest");

            migrationBuilder.AddColumn<int>(
                name: "RequestApplication_Id",
                table: "TB_T_UserRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_UserRequest",
                table: "TB_T_UserRequest",
                columns: new[] { "Applicants_Id", "RequestApplication_Id" });

            migrationBuilder.CreateTable(
                name: "TB_T_RequestApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Jobs_Id = table.Column<int>(nullable: false),
                    JobsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_RequestApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_RequestApplication_TB_M_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "TB_M_Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UserRequest_RequestApplication_Id",
                table: "TB_T_UserRequest",
                column: "RequestApplication_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_RequestApplication_JobsId",
                table: "TB_T_RequestApplication",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_UserRequest_TB_T_RequestApplication_RequestApplication_Id",
                table: "TB_T_UserRequest",
                column: "RequestApplication_Id",
                principalTable: "TB_T_RequestApplication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_UserRequest_TB_T_RequestApplication_RequestApplication_Id",
                table: "TB_T_UserRequest");

            migrationBuilder.DropTable(
                name: "TB_T_RequestApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_UserRequest",
                table: "TB_T_UserRequest");

            migrationBuilder.DropIndex(
                name: "IX_TB_T_UserRequest_RequestApplication_Id",
                table: "TB_T_UserRequest");

            migrationBuilder.DropColumn(
                name: "RequestApplication_Id",
                table: "TB_T_UserRequest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_UserRequest",
                table: "TB_T_UserRequest",
                column: "Applicants_Id");
        }
    }
}
