using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QMYoga.Migrations
{
    /// <inheritdoc />
    public partial class playlistHasSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_SubCategoryId",
                table: "Playlists",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_SubCategories_SubCategoryId",
                table: "Playlists",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_SubCategories_SubCategoryId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_SubCategoryId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Playlists");
        }
    }
}
