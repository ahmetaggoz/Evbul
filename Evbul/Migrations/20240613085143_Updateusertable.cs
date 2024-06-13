using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evbul.Migrations
{
    /// <inheritdoc />
    public partial class Updateusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Kullanicilar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eposta",
                table: "Kullanicilar",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parola",
                table: "Kullanicilar",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Eposta",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Parola",
                table: "Kullanicilar");
        }
    }
}
