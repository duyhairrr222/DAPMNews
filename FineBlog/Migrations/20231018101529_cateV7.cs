using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FineBlog.Migrations
{
    public partial class cateV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CateID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CateID",
                table: "Posts",
                column: "CateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categorys_CateID",
                table: "Posts",
                column: "CateID",
                principalTable: "Categorys",
                principalColumn: "CateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categorys_CateID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CateID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CateID",
                table: "Posts");
        }
    }
}
