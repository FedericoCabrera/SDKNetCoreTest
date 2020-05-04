using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDKTest.Data.DataAccess.Migrations
{
    public partial class AddTrajectsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trajects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InitialLatitude = table.Column<double>(nullable: false),
                    InitialLongitude = table.Column<double>(nullable: false),
                    FinalLatitude = table.Column<double>(nullable: false),
                    FinalLongitude = table.Column<double>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trajects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trajects_EmployeeId",
                table: "Trajects",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trajects");
        }
    }
}
