using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QMYoga.Migrations
{
    /// <inheritdoc />
    public partial class video_playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Playlists_PlayListID",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "PlayListID",
                table: "Videos",
                newName: "PlayListId");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_PlayListID",
                table: "Videos",
                newName: "IX_Videos_PlayListId");

            migrationBuilder.AlterColumn<int>(
                name: "PlayListId",
                table: "Videos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Playlists_PlayListId",
                table: "Videos",
                column: "PlayListId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Playlists_PlayListId",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "PlayListId",
                table: "Videos",
                newName: "PlayListID");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_PlayListId",
                table: "Videos",
                newName: "IX_Videos_PlayListID");

            migrationBuilder.AlterColumn<int>(
                name: "PlayListID",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Playlists_PlayListID",
                table: "Videos",
                column: "PlayListID",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
