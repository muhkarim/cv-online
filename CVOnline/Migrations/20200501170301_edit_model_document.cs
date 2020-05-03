using Microsoft.EntityFrameworkCore.Migrations;

namespace CVOnline.Migrations
{
    public partial class edit_model_document : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transcripts",
                table: "TB_M_Document",
                newName: "fTranscripts");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "TB_M_Document",
                newName: "fResume");

            migrationBuilder.RenameColumn(
                name: "IdCard",
                table: "TB_M_Document",
                newName: "fIdCard");

            migrationBuilder.RenameColumn(
                name: "FamilyCard",
                table: "TB_M_Document",
                newName: "fFamilyCard");

            migrationBuilder.RenameColumn(
                name: "Diploma",
                table: "TB_M_Document",
                newName: "fDiploma");

            migrationBuilder.RenameColumn(
                name: "Certificate",
                table: "TB_M_Document",
                newName: "fCertificate");

            migrationBuilder.RenameColumn(
                name: "CV",
                table: "TB_M_Document",
                newName: "fCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fTranscripts",
                table: "TB_M_Document",
                newName: "Transcripts");

            migrationBuilder.RenameColumn(
                name: "fResume",
                table: "TB_M_Document",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "fIdCard",
                table: "TB_M_Document",
                newName: "IdCard");

            migrationBuilder.RenameColumn(
                name: "fFamilyCard",
                table: "TB_M_Document",
                newName: "FamilyCard");

            migrationBuilder.RenameColumn(
                name: "fDiploma",
                table: "TB_M_Document",
                newName: "Diploma");

            migrationBuilder.RenameColumn(
                name: "fCertificate",
                table: "TB_M_Document",
                newName: "Certificate");

            migrationBuilder.RenameColumn(
                name: "fCV",
                table: "TB_M_Document",
                newName: "CV");
        }
    }
}
