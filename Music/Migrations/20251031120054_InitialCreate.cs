using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Singers");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Movies",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Movies",
                newName: "ReleaseYear");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Singers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
