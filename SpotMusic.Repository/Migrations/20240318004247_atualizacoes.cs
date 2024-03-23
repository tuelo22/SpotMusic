using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMusic.Repository.Migrations
{
    /// <inheritdoc />
    public partial class atualizacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Transacao");

            migrationBuilder.AddColumn<string>(
                name: "Backdrop",
                table: "Autor",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Autor",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Backdrop",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Autor");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hora",
                table: "Transacao",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
