using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirst.Migrations
{
    public partial class AuthorEmailRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);
        }
    }
}
