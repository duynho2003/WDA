using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab06Domain.Migrations
{
    /// <inheritdoc />
    public partial class Lab06Domain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCustomer",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    role = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCustomer", x => x.code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCustomer");
        }
    }
}
