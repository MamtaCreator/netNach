using Microsoft.EntityFrameworkCore.Migrations;

namespace SPViewRawSqlCodeFirst.Migrations
{
    public partial class EmployeeView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var employees = "CREATE VIEW EmployeesInfo AS SELECT EmployeeId, FirstName, LastName FROM Employees";
            migrationBuilder.Sql(employees);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
