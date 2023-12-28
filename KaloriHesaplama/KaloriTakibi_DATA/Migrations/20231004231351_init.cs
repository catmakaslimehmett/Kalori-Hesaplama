using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kalori_DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boy = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullanıcıTipi = table.Column<bool>(type: "bit", nullable: false),
                    SifremiHatirla = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Mail);
                });

            migrationBuilder.CreateTable(
                name: "Ogunler",
                columns: table => new
                {
                    OgunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogunler", x => x.OgunId);
                });

            migrationBuilder.CreateTable(
                name: "Yemekler",
                columns: table => new
                {
                    YemekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kalori = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    YemekResmi = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yemekler", x => x.YemekId);
                    table.ForeignKey(
                        name: "FK_Yemekler_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İslemler",
                columns: table => new
                {
                    IslemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OgunId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İslemler", x => x.IslemId);
                    table.ForeignKey(
                        name: "FK_İslemler_Kullanicilar_KullaniciMail",
                        column: x => x.KullaniciMail,
                        principalTable: "Kullanicilar",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_İslemler_Ogunler_OgunId",
                        column: x => x.OgunId,
                        principalTable: "Ogunler",
                        principalColumn: "OgunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ogun-Yemek Tablosu",
                columns: table => new
                {
                    IslemId = table.Column<int>(type: "int", nullable: false),
                    YemekId = table.Column<int>(type: "int", nullable: false),
                    Kalori = table.Column<int>(type: "int", nullable: false),
                    Porsiyon = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogun-Yemek Tablosu", x => new { x.IslemId, x.YemekId });
                    table.ForeignKey(
                        name: "FK_Ogun-Yemek Tablosu_Yemekler_YemekId",
                        column: x => x.YemekId,
                        principalTable: "Yemekler",
                        principalColumn: "YemekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ogun-Yemek Tablosu_İslemler_IslemId",
                        column: x => x.IslemId,
                        principalTable: "İslemler",
                        principalColumn: "IslemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İslemler_KullaniciMail",
                table: "İslemler",
                column: "KullaniciMail");

            migrationBuilder.CreateIndex(
                name: "IX_İslemler_OgunId",
                table: "İslemler",
                column: "OgunId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogun-Yemek Tablosu_YemekId",
                table: "Ogun-Yemek Tablosu",
                column: "YemekId");

            migrationBuilder.CreateIndex(
                name: "IX_Yemekler_KategoriId",
                table: "Yemekler",
                column: "KategoriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogun-Yemek Tablosu");

            migrationBuilder.DropTable(
                name: "Yemekler");

            migrationBuilder.DropTable(
                name: "İslemler");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Ogunler");
        }
    }
}
