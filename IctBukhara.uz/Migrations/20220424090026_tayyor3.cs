using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IctBukhara.uz.Migrations
{
    public partial class tayyor3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Vaqt",
                table: "KursgaYozilganlar",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: DateTime.Now
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vaqt",
                table: "KursgaYozilganlar");
        }
    }
}
