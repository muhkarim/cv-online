using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class edit_model_request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_UserRequest");

            migrationBuilder.DropTable(
                name: "TB_T_RequestApplication");

            migrationBuilder.CreateTable(
                name: "TB_T_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Applicants_Id = table.Column<int>(nullable: false),
                    Jobs_Id = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Request_TB_M_Applicants_Applicants_Id",
                        column: x => x.Applicants_Id,
                        principalTable: "TB_M_Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_Request_TB_M_Jobs_Jobs_Id",
                        column: x => x.Jobs_Id,
                        principalTable: "TB_M_Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Request_Applicants_Id",
                table: "TB_T_Request",
                column: "Applicants_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Request_Jobs_Id",
                table: "TB_T_Request",
                column: "Jobs_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_T_Request");

            migrationBuilder.CreateTable(
                name: "TB_T_RequestApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    JobsId = table.Column<int>(nullable: true),
                    Jobs_Id = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TB_T_UserRequest",
                columns: table => new
                {
                    Applicants_Id = table.Column<int>(nullable: false),
                    RequestApplication_Id = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_UserRequest", x => new { x.Applicants_Id, x.RequestApplication_Id });
                    table.UniqueConstraint("AK_TB_T_UserRequest_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_UserRequest_TB_M_Applicants_Applicants_Id",
                        column: x => x.Applicants_Id,
                        principalTable: "TB_M_Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_UserRequest_TB_T_RequestApplication_RequestApplication_Id",
                        column: x => x.RequestApplication_Id,
                        principalTable: "TB_T_RequestApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_RequestApplication_JobsId",
                table: "TB_T_RequestApplication",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UserRequest_RequestApplication_Id",
                table: "TB_T_UserRequest",
                column: "RequestApplication_Id");
        }
    }
}
