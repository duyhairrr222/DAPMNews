using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineBlog.Migrations
{
    public partial class CategoryV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Categorys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_ApplicationUserId",
                table: "Categorys",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_AspNetUsers_ApplicationUserId",
                table: "Categorys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_AspNetUsers_ApplicationUserId",
                table: "Categorys");

            migrationBuilder.DropIndex(
                name: "IX_Categorys_ApplicationUserId",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Categorys");
        }
    }
}
