using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evbul.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrlTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Ozellikler",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Evler",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Ozellikler");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Evler");
        }
    }
}
