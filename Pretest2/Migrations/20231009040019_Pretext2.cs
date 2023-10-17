using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pretext2.Migrations
{
    /// <inheritdoc />
    public partial class Pretext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_Info",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Info", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "TBL_News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadLines = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContentOfNews = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_News", x => x.NewsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_Info");

            migrationBuilder.DropTable(
                name: "TBL_News");
        }
    }
}
