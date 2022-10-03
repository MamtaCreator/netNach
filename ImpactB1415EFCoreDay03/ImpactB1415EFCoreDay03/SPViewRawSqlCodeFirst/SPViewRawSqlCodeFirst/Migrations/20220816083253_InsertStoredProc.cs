using Microsoft.EntityFrameworkCore.Migrations;

namespace SPViewRawSqlCodeFirst.Migrations
{
    public partial class InsertStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[InsertEmployee]
                      @FirstName nvarchar(20),
                      @LastName nvarchar(20),
                      @Salary decimal(10,2),
                      @DepartmentId int
                    AS
                    BEGIN
                        INSERT INTO Employees
                        VALUES(@FirstName, @LastName, @Salary, @DepartmentId)
                    END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
