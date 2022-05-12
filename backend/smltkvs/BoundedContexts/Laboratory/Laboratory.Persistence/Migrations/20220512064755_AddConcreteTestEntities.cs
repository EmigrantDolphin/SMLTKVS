using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class AddConcreteTestEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcreteCubeStrengthTests",
                columns: table => new
                {
                    ConcreteCubeStrengthTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestProtocolNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestExecutionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TestSamplesReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TestSamplesReceivedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TestSamplesReceivedComment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    TestSamplesReceivedCount = table.Column<int>(type: "int", nullable: false),
                    TestExecutedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProtocolCreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConcreteType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AcceptedSampleCount = table.Column<int>(type: "int", nullable: false),
                    RejectedSampleCount = table.Column<int>(type: "int", nullable: false),
                    AverageCrushForce = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    StandardUncertainty = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    ExtendedUncertainty = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    StandardDeviation = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    CharacteristicDeviation = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    ConcreteRating = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteCubeStrengthTests", x => x.ConcreteCubeStrengthTestId);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteCubeStrengthTestData",
                columns: table => new
                {
                    ConcreteCubeStrengthTestDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcreteCubeStrengthTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DestructivePower = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false),
                    CrushingStrength = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteCubeStrengthTestData", x => x.ConcreteCubeStrengthTestDataId);
                    table.ForeignKey(
                        name: "FK_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTests_ConcreteCubeStrengthTestId",
                        column: x => x.ConcreteCubeStrengthTestId,
                        principalTable: "ConcreteCubeStrengthTests",
                        principalColumn: "ConcreteCubeStrengthTestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrossSectionalDimensions",
                columns: table => new
                {
                    CrossSectionalDimensionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcreteCubeStrengthTestDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(15,5)", precision: 15, scale: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossSectionalDimensions", x => x.CrossSectionalDimensionsId);
                    table.ForeignKey(
                        name: "FK_CrossSectionalDimensions_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestDataId",
                        column: x => x.ConcreteCubeStrengthTestDataId,
                        principalTable: "ConcreteCubeStrengthTestData",
                        principalColumn: "ConcreteCubeStrengthTestDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteCubeStrengthTestData_ConcreteCubeStrengthTestId",
                table: "ConcreteCubeStrengthTestData",
                column: "ConcreteCubeStrengthTestId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossSectionalDimensions_ConcreteCubeStrengthTestDataId",
                table: "CrossSectionalDimensions",
                column: "ConcreteCubeStrengthTestDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrossSectionalDimensions");

            migrationBuilder.DropTable(
                name: "ConcreteCubeStrengthTestData");

            migrationBuilder.DropTable(
                name: "ConcreteCubeStrengthTests");
        }
    }
}
