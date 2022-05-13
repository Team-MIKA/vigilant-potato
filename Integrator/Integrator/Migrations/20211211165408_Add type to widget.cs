using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class Addtypetowidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Widgets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                column: "Type",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Widgets");
        }
    }
}
