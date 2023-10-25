using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineBlog.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prices",
                table: "Posts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "catename",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prices",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "catename",
                table: "Categorys");
        }
    }
}
