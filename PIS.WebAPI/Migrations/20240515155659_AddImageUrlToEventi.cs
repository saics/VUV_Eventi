using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIS.WebAPI.Migrations
{
    public partial class AddImageUrlToEventi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Eventi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Eventi");
        }
    }

}
