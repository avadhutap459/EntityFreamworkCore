using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.DBLayer.Migrations
{
    public partial class SP_GetEmployeeCountBaseOnDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE SP_GetEmployeeCountBaseOnDepartment
	
AS
BEGIN
	select e.EmployeeName,COUNT(d.departmentid) from mstEmployee e left join mstDepartment d
on e.departmentid = d.departmentid
group by e.EmployeeName
having count(d.departmentid) > 1
END
";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE SP_GetEmployeeCountBaseOnDepartment";

            migrationBuilder.Sql(procedure);
        }
    }
}
