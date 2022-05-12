using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class RenameToCharacteristicStrength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharacteristicDeviation",
                table: "ConcreteCubeStrengthTests",
                newName: "CharacteristicStrength");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharacteristicStrength",
                table: "ConcreteCubeStrengthTests",
                newName: "CharacteristicDeviation");
        }
    }
}
