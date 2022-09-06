using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeightControl.Persistence.Migrations
{
    public partial class Db_Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                schema: "dbo",
                table: "Users",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "Users",
                newName: "Login");
        }
    }
}
