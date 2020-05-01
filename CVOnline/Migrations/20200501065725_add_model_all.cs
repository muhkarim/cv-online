using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TB_M_Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCard = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    CV = table.Column<string>(nullable: true),
                    FamilyCard = table.Column<string>(nullable: true),
                    Transcripts = table.Column<string>(nullable: true),
                    Diploma = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Document", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TB_M_Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobName = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    DueDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Users", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TB_M_Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Admin_TB_M_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_UserRole",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_UserRole", x => new { x.User_Id, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_TB_M_UserRole_TB_M_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "TB_M_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_UserRole_TB_M_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document_Id = table.Column<int>(nullable: false),
                    EducationalDetails_Id = table.Column<int>(nullable: false),
                    Biodata_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    WorkExperience_Id = table.Column<int>(nullable: false),
                    WorkExperienceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_Biodata_Biodata_Id",
                        column: x => x.Biodata_Id,
                        principalTable: "TB_M_Biodata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "TB_M_Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_EducationalDetails_EducationalDetails_Id",
                        column: x => x.EducationalDetails_Id,
                        principalTable: "TB_M_EducationalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperienceId1",
                        column: x => x.WorkExperienceId1,
                        principalTable: "TB_M_WorkExperience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_WorkExperience_WorkExperience_Id",
                        column: x => x.WorkExperience_Id,
                        principalTable: "TB_M_WorkExperience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_UserRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Applicants_Id = table.Column<int>(nullable: false),
                    RequestApplication_Id = table.Column<int>(nullable: false)
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
                name: "IX_TB_M_Admin_User_Id",
                table: "TB_M_Admin",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_Biodata_Id",
                table: "TB_M_Applicants",
                column: "Biodata_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_Document_Id",
                table: "TB_M_Applicants",
                column: "Document_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_EducationalDetails_Id",
                table: "TB_M_Applicants",
                column: "EducationalDetails_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_User_Id",
                table: "TB_M_Applicants",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_WorkExperienceId1",
                table: "TB_M_Applicants",
                column: "WorkExperienceId1");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_WorkExperience_Id",
                table: "TB_M_Applicants",
                column: "WorkExperience_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_UserRole_Role_Id",
                table: "TB_M_UserRole",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_RequestApplication_JobsId",
                table: "TB_T_RequestApplication",
                column: "JobsId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_UserRequest_RequestApplication_Id",
                table: "TB_T_UserRequest",
                column: "RequestApplication_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Admin");

            migrationBuilder.DropTable(
                name: "TB_M_UserRole");

            migrationBuilder.DropTable(
                name: "TB_T_UserRequest");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");

            migrationBuilder.DropTable(
                name: "TB_M_Applicants");

            migrationBuilder.DropTable(
                name: "TB_T_RequestApplication");

            migrationBuilder.DropTable(
                name: "TB_M_Biodata");

            migrationBuilder.DropTable(
                name: "TB_M_Document");

            migrationBuilder.DropTable(
                name: "TB_M_EducationalDetails");

            migrationBuilder.DropTable(
                name: "TB_M_Users");

            migrationBuilder.DropTable(
                name: "TB_M_WorkExperience");

            migrationBuilder.DropTable(
                name: "TB_M_Jobs");
        }
    }
}
