using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class addedConcreteCubeConstructionSiteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClientConstructionSiteId",
                schema: "ConcreteCube",
                table: "StrengthTest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientConstructionSiteId",
                schema: "ConcreteCube",
                table: "StrengthTest");
        }
    }
}
