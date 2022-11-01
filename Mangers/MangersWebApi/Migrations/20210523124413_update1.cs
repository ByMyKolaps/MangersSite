using Microsoft.EntityFrameworkCore.Migrations;

namespace MangersWebApi.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Pages",
                newName: "MangaId");

            migrationBuilder.AddColumn<int>(
                name: "ChapterNumber",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterNumber",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "MangaId",
                table: "Pages",
                newName: "ChapterId");
        }
    }
}
