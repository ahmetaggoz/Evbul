using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evbul.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciAd = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Ozellikler",
                columns: table => new
                {
                    OzellikId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Yazi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozellikler", x => x.OzellikId);
                });

            migrationBuilder.CreateTable(
                name: "Evler",
                columns: table => new
                {
                    EvId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: true),
                    Kapasite = table.Column<int>(type: "INTEGER", nullable: false),
                    YatakOdasi = table.Column<int>(type: "INTEGER", nullable: false),
                    YatakSayisi = table.Column<int>(type: "INTEGER", nullable: false),
                    Banyo = table.Column<int>(type: "INTEGER", nullable: false),
                    Fiyat = table.Column<int>(type: "INTEGER", nullable: false),
                    AktifMi = table.Column<bool>(type: "INTEGER", nullable: false),
                    YayinlamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evler", x => x.EvId);
                    table.ForeignKey(
                        name: "FK_Evler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvOzellik",
                columns: table => new
                {
                    EvlerEvId = table.Column<int>(type: "INTEGER", nullable: false),
                    OzelliklerOzellikId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvOzellik", x => new { x.EvlerEvId, x.OzelliklerOzellikId });
                    table.ForeignKey(
                        name: "FK_EvOzellik_Evler_EvlerEvId",
                        column: x => x.EvlerEvId,
                        principalTable: "Evler",
                        principalColumn: "EvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvOzellik_Ozellikler_OzelliklerOzellikId",
                        column: x => x.OzelliklerOzellikId,
                        principalTable: "Ozellikler",
                        principalColumn: "OzellikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Yazi = table.Column<string>(type: "TEXT", nullable: true),
                    Tarih = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    EvId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Evler_EvId",
                        column: x => x.EvId,
                        principalTable: "Evler",
                        principalColumn: "EvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evler_KullaniciId",
                table: "Evler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_EvOzellik_OzelliklerOzellikId",
                table: "EvOzellik",
                column: "OzelliklerOzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_EvId",
                table: "Yorumlar",
                column: "EvId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_KullaniciId",
                table: "Yorumlar",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvOzellik");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Ozellikler");

            migrationBuilder.DropTable(
                name: "Evler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
