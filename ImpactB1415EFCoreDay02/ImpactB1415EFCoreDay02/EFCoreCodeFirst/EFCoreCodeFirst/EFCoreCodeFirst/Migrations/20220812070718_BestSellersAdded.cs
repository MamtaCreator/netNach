using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirst.Migrations
{
    public partial class BestSellersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfBestsellers",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfBestsellers",
                table: "Authors");
        }
    }
}
