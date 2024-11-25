using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QMYoga.Migrations
{
    /// <inheritdoc />
    public partial class mtm_video_playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Playlists_PlayListId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_PlayListId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "PlayListId",
                table: "Videos");

            migrationBuilder.CreateTable(
                name: "PlaylistVideo",
                columns: table => new
                {
                    PlayListsId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistVideo", x => new { x.PlayListsId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_PlaylistVideo_Playlists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistVideo_VideosId",
                table: "PlaylistVideo",
                column: "VideosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistVideo");

            migrationBuilder.AddColumn<int>(
                name: "PlayListId",
                table: "Videos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PlayListId",
                table: "Videos",
                column: "PlayListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Playlists_PlayListId",
                table: "Videos",
                column: "PlayListId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }
    }
}
