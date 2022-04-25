using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IctBukhara.uz.Migrations
{
    public partial class tayyor4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Vaqt",
                table: "KursgaYozilganlar",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: DateTime.Now,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Vaqt",
                table: "KursgaYozilganlar",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: DateTime.Now);
        }
    }
}
