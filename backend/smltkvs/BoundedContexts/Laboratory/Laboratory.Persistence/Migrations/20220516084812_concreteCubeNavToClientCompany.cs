using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class concreteCubeNavToClientCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StrengthTest_ClientCompanyId",
                schema: "ConcreteCube",
                table: "StrengthTest",
                column: "ClientCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrengthTest_Companies_ClientCompanyId",
                schema: "ConcreteCube",
                table: "StrengthTest",
                column: "ClientCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrengthTest_Companies_ClientCompanyId",
                schema: "ConcreteCube",
                table: "StrengthTest");

            migrationBuilder.DropIndex(
                name: "IX_StrengthTest_ClientCompanyId",
                schema: "ConcreteCube",
                table: "StrengthTest");
        }
    }
}
