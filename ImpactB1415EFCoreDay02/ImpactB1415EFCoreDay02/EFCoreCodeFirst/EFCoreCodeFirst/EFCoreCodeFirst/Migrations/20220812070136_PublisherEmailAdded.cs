using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirst.Migrations
{
    public partial class PublisherEmailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Publishers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Publishers");
        }
    }
}
