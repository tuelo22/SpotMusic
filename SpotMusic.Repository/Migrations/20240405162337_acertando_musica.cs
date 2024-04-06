using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMusic.Repository.Migrations
{
    /// <inheritdoc />
    public partial class acertando_musica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicaAlbum_Albuns_Id",
                table: "MusicaAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicaAlbum_Musica_Id",
                table: "MusicaAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicaAlbum",
                table: "MusicaAlbum");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MusicaAlbum",
                newName: "AlbumId");

            migrationBuilder.AddColumn<Guid>(
                name: "MusicaId",
                table: "MusicaAlbum",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicaAlbum",
                table: "MusicaAlbum",
                columns: new[] { "MusicaId", "AlbumId" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicaAlbum_AlbumId",
                table: "MusicaAlbum",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaAlbum_Albuns_AlbumId",
                table: "MusicaAlbum",
                column: "AlbumId",
                principalTable: "Albuns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaAlbum_Musica_MusicaId",
                table: "MusicaAlbum",
                column: "MusicaId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicaAlbum_Albuns_AlbumId",
                table: "MusicaAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicaAlbum_Musica_MusicaId",
                table: "MusicaAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicaAlbum",
                table: "MusicaAlbum");

            migrationBuilder.DropIndex(
                name: "IX_MusicaAlbum_AlbumId",
                table: "MusicaAlbum");

            migrationBuilder.DropColumn(
                name: "MusicaId",
                table: "MusicaAlbum");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "MusicaAlbum",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicaAlbum",
                table: "MusicaAlbum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaAlbum_Albuns_Id",
                table: "MusicaAlbum",
                column: "Id",
                principalTable: "Albuns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicaAlbum_Musica_Id",
                table: "MusicaAlbum",
                column: "Id",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
