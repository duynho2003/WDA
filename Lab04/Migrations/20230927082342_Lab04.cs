using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab04.Migrations
{
    /// <inheritdoc />
    public partial class Lab04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbDepartment",
                columns: table => new
                {
                    No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDepartment", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "tbEmployee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Department_Employee",
                        column: x => x.No,
                        principalTable: "tbDepartment",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbEmployee_No",
                table: "tbEmployee",
                column: "No");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbEmployee");

            migrationBuilder.DropTable(
                name: "tbDepartment");
        }
    }
}
