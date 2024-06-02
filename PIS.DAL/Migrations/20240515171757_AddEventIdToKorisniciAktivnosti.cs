using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIS.DAL.Migrations
{
    public partial class AddEventIdToKorisniciAktivnosti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Eventi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Opis = table.Column<string>(unicode: false, nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    Lokacija = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DatumPocetka = table.Column<DateTime>(type: "date", nullable: true),
                    VrijemePocetka = table.Column<TimeSpan>(nullable: true),
                    DatumZavrsetka = table.Column<DateTime>(type: "date", nullable: true),
                    VrijemeZavrsetka = table.Column<TimeSpan>(nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventi", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Eventi__StatusID__403A8C7D",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Lozinka = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    UlogaID = table.Column<int>(nullable: true),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Korisnici__Uloga__3B75D760",
                        column: x => x.UlogaID,
                        principalTable: "Uloge",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aktivnosti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Opis = table.Column<string>(unicode: false, nullable: true),
                    StatusID = table.Column<int>(nullable: true),
                    EventID = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(type: "date", nullable: true),
                    VrijemePocetka = table.Column<TimeSpan>(nullable: true),
                    VrijemeZavrsetka = table.Column<TimeSpan>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivnosti", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Aktivnost__Event__4316F928",
                        column: x => x.EventID,
                        principalTable: "Eventi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Aktivnost__Statu__440B1D61",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici_Aktivnosti",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: true),
                    AktivnostID = table.Column<int>(nullable: true),
                    EventID = table.Column<int>(nullable: true),
                    QRKod = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici_Aktivnosti", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Korisnici__Aktiv__47DBAE45",
                        column: x => x.AktivnostID,
                        principalTable: "Aktivnosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Korisnici__Event__48CFD27E",
                        column: x => x.EventID,
                        principalTable: "Eventi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Korisnici__Koris__46E78A0C",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktivnosti_EventID",
                table: "Aktivnosti",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Aktivnosti_StatusID",
                table: "Aktivnosti",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_StatusID",
                table: "Eventi",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "UQ__Korisnic__A9D1053480DD87CB",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaID",
                table: "Korisnici",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Aktivnosti_AktivnostID",
                table: "Korisnici_Aktivnosti",
                column: "AktivnostID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Aktivnosti_EventID",
                table: "Korisnici_Aktivnosti",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Aktivnosti_KorisnikID",
                table: "Korisnici_Aktivnosti",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnici_Aktivnosti");

            migrationBuilder.DropTable(
                name: "Aktivnosti");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Eventi");

            migrationBuilder.DropTable(
                name: "Uloge");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
