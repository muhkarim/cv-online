using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class add_model_document : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TB_M_Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Applicants_TB_M_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "TB_M_Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Applicants_Document_Id",
                table: "TB_M_Applicants",
                column: "Document_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Applicants");

            migrationBuilder.DropTable(
                name: "TB_M_Document");
        }
    }
}
