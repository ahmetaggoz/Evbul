using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evbul.Migrations
{
    /// <inheritdoc />
    public partial class IkinciMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Kullanicilar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Evler",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Evler");
        }
    }
}
