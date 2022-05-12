using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class changedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTests_ConcreteCubeStrengthTestId",
                table: "ConcreteCubeStrengthTestData");

            migrationBuilder.DropForeignKey(
                name: "FK_CrossSectionalDimensions_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestDataId",
                table: "CrossSectionalDimensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcreteCubeStrengthTests",
                table: "ConcreteCubeStrengthTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConcreteCubeStrengthTestData",
                table: "ConcreteCubeStrengthTestData");

            migrationBuilder.EnsureSchema(
                name: "ConcreteCube");

            migrationBuilder.RenameTable(
                name: "CrossSectionalDimensions",
                newName: "CrossSectionalDimensions",
                newSchema: "ConcreteCube");

            migrationBuilder.RenameTable(
                name: "ConcreteCubeStrengthTests",
                newName: "StrengthTest",
                newSchema: "ConcreteCube");

            migrationBuilder.RenameTable(
                name: "ConcreteCubeStrengthTestData",
                newName: "StrengthTestData",
                newSchema: "ConcreteCube");

            migrationBuilder.RenameIndex(
                name: "IX_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestId",
                schema: "ConcreteCube",
                table: "StrengthTestData",
                newName: "IX_StrengthTestData_ConcreteCubeStrengthTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrengthTest",
                schema: "ConcreteCube",
                table: "StrengthTest",
                column: "ConcreteCubeStrengthTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrengthTestData",
                schema: "ConcreteCube",
                table: "StrengthTestData",
                column: "ConcreteCubeStrengthTestDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrossSectionalDimensions_StrengthTestData_ConcreteCubeStrengthTestDataId",
                schema: "ConcreteCube",
                table: "CrossSectionalDimensions",
                column: "ConcreteCubeStrengthTestDataId",
                principalSchema: "ConcreteCube",
                principalTable: "StrengthTestData",
                principalColumn: "ConcreteCubeStrengthTestDataId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrengthTestData_StrengthTest_ConcreteCubeStrengthTestId",
                schema: "ConcreteCube",
                table: "StrengthTestData",
                column: "ConcreteCubeStrengthTestId",
                principalSchema: "ConcreteCube",
                principalTable: "StrengthTest",
                principalColumn: "ConcreteCubeStrengthTestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrossSectionalDimensions_StrengthTestData_ConcreteCubeStrengthTestDataId",
                schema: "ConcreteCube",
                table: "CrossSectionalDimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_StrengthTestData_StrengthTest_ConcreteCubeStrengthTestId",
                schema: "ConcreteCube",
                table: "StrengthTestData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrengthTestData",
                schema: "ConcreteCube",
                table: "StrengthTestData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StrengthTest",
                schema: "ConcreteCube",
                table: "StrengthTest");

            migrationBuilder.RenameTable(
                name: "CrossSectionalDimensions",
                schema: "ConcreteCube",
                newName: "CrossSectionalDimensions");

            migrationBuilder.RenameTable(
                name: "StrengthTestData",
                schema: "ConcreteCube",
                newName: "ConcreteCubeStrengthTestData");

            migrationBuilder.RenameTable(
                name: "StrengthTest",
                schema: "ConcreteCube",
                newName: "ConcreteCubeStrengthTests");

            migrationBuilder.RenameIndex(
                name: "IX_StrengthTestData_ConcreteCubeStrengthTestId",
                table: "ConcreteCubeStrengthTestData",
                newName: "IX_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcreteCubeStrengthTestData",
                table: "ConcreteCubeStrengthTestData",
                column: "ConcreteCubeStrengthTestDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConcreteCubeStrengthTests",
                table: "ConcreteCubeStrengthTests",
                column: "ConcreteCubeStrengthTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTests_ConcreteCubeStrengthTestId",
                table: "ConcreteCubeStrengthTestData",
                column: "ConcreteCubeStrengthTestId",
                principalTable: "ConcreteCubeStrengthTests",
                principalColumn: "ConcreteCubeStrengthTestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrossSectionalDimensions_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestDataId",
                table: "CrossSectionalDimensions",
                column: "ConcreteCubeStrengthTestDataId",
                principalTable: "ConcreteCubeStrengthTestData",
                principalColumn: "ConcreteCubeStrengthTestDataId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
