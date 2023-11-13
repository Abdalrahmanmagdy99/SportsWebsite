using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsWebsite.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoUrlToTournaments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Tournaments");
        }
    }
}
