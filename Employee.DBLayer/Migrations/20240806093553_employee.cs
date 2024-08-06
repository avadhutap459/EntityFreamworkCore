using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.DBLayer.Migrations
{
    public partial class employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mstDepartment",
                columns: table => new
                {
                    departmentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstDepartment", x => x.departmentid);
                });

            migrationBuilder.CreateTable(
                name: "mstEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstEmployee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_mstEmployee_mstDepartment_departmentid",
                        column: x => x.departmentid,
                        principalTable: "mstDepartment",
                        principalColumn: "departmentid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_mstEmployee_departmentid",
                table: "mstEmployee",
                column: "departmentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstEmployee");

            migrationBuilder.DropTable(
                name: "mstDepartment");
        }
    }
}
