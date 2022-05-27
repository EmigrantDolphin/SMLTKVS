using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class changedParamsToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StandardUncertainty",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "StandardDeviation",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExtendedUncertainty",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StandardUncertainty",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "StandardDeviation",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExtendedUncertainty",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "decimal(15,5)",
                precision: 15,
                scale: 5,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,5)",
                oldPrecision: 15,
                oldScale: 5,
                oldNullable: true);
        }
    }
}
