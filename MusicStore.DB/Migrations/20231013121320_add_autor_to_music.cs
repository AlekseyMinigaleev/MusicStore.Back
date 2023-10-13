using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class add_autor_to_music : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Music",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Music");
        }
    }
}
