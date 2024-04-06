using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMusic.Repository.Migrations
{
    /// <inheritdoc />
    public partial class musica_interprete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interprete_Musica_MusicaId",
                table: "Interprete");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicaPlaylist_Musica_MusicasId",
                table: "MusicaPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicaPlaylist_Playlist_PlaylistsId",
                table: "MusicaPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_Interprete_MusicaId",
                table: "Interprete");

            migrationBuilder.DropColumn(
                name: "MusicaId",
                table: "Interprete");

            migrationBuilder.RenameColumn(
                name: "PlaylistsId",
                table: "MusicaPlaylist",
                newName: "PlaylistId");

            migrationBuilder.RenameColumn(
                name: "MusicasId",
                table: "MusicaPlaylist",
                newName: "MusicaId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicaPlaylist_PlaylistsId",
                table: "MusicaPlaylist",
                newName: "IX_MusicaPlaylist_PlaylistId");

            migrationBuilder.CreateTable(
                name: "MusicaInterprete",
                columns: table => new
                {
                    MusicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterpreteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaInterprete", x => new { x.MusicaId, x.InterpreteId });
                    table.ForeignKey(
                        name: "FK_MusicaInterprete_Interprete_InterpreteId",
                        column: x => x.InterpreteId,
                        principalTable: "Interprete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicaInterprete_Musica_MusicaId",
                        column: x => x.MusicaId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicaInterprete_InterpreteId",
                table: "MusicaInterprete",
                column: "InterpreteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaPlaylist_Musica_MusicaId",
                table: "MusicaPlaylist",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaPlaylist_Playlist_PlaylistId",
                table: "MusicaPlaylist",
                column: "PlaylistId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicaPlaylist_Musica_MusicaId",
                table: "MusicaPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicaPlaylist_Playlist_PlaylistId",
                table: "MusicaPlaylist");

            migrationBuilder.DropTable(
                name: "MusicaInterprete");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "MusicaPlaylist",
                newName: "PlaylistsId");

            migrationBuilder.RenameColumn(
                name: "MusicaId",
                table: "MusicaPlaylist",
                newName: "MusicasId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicaPlaylist_PlaylistId",
                table: "MusicaPlaylist",
                newName: "IX_MusicaPlaylist_PlaylistsId");

            migrationBuilder.AddColumn<Guid>(
                name: "MusicaId",
                table: "Interprete",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interprete_MusicaId",
                table: "Interprete",
                column: "MusicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interprete_Musica_MusicaId",
                table: "Interprete",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaPlaylist_Musica_MusicasId",
                table: "MusicaPlaylist",
                column: "MusicasId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaPlaylist_Playlist_PlaylistsId",
                table: "MusicaPlaylist",
                column: "PlaylistsId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
