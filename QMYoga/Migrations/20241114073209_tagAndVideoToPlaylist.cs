using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QMYoga.Migrations
{
    /// <inheritdoc />
    public partial class tagAndVideoToPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_PlayListID",
                table: "Videos",
                column: "PlayListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Playlists_PlayListID",
                table: "Videos",
                column: "PlayListID",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Playlists_PlayListID",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Videos_PlayListID",
                table: "Videos");
        }
    }
}
