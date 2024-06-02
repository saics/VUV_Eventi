using Microsoft.EntityFrameworkCore.Migrations;

namespace PIS.WebAPI.Migrations
{
    public partial class AddImageUrlToAktivnosti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Aktivnosti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Aktivnosti");
        }
    }

}
