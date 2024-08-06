using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.DBLayer.Migrations
{
    public partial class addSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClsEmpCountBaseDep",
                columns: table => new
                {
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClsEmpCountBaseDep");
        }
    }
}
