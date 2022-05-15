using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class renamedToSamplesDeliveredBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestSamplesReceivedBy",
                schema: "ConcreteCube",
                table: "StrengthTest",
                newName: "TestSamplesDeliveredBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestSamplesDeliveredBy",
                schema: "ConcreteCube",
                table: "StrengthTest",
                newName: "TestSamplesReceivedBy");
        }
    }
}
