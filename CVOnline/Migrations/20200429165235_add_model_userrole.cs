using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_userrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_UserRole_Role_Id",
                table: "TB_M_UserRole",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_UserRole");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");

            migrationBuilder.DropTable(
                name: "TB_M_Users");
        }
    }
}
