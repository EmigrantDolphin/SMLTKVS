using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Persistence.Migrations
{
    public partial class addAdminScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO dbo.Users(UserId, Username, Password, Name, Email, [Role], CompanyId)
VALUES ('00000000-0000-0000-0000-000000000000', 'admin', 'admin', 'System Admin', 'nomail', 'Admin', '00000000-0000-0000-0000-000000000000')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
