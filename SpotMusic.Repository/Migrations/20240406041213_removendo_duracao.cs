using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMusic.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removendo_duracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracao_Valor",
                table: "Musica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duracao_Valor",
                table: "Musica",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }
    }
}
