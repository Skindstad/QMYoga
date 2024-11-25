using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QMYoga.Migrations
{
    /// <inheritdoc />
    public partial class videoWithTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_VideoId",
                table: "Tags",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Videos_VideoId",
                table: "Tags",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Videos_VideoId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_VideoId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Tags");
        }
    }
}
