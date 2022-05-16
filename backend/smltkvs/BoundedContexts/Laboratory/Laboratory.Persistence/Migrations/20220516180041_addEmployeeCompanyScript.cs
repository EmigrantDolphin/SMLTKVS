using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    public partial class addEmployeeCompanyScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO dbo.Companies(CompanyId, Name, Address, CompanyCode)
VALUES('00000000-0000-0000-0000-000000000000', N'Statybinių medžiagų ir konstrukcijų tyrimų centras, Vilniaus pagrindinis filijalas', N'Lvovo g-vė, 5', '253258686')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
