using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class Addtypetoinitialwidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                columns: new[] { "Title", "Type" },
                values: new object[] { "Timesmart Registrations", 2 });

            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                column: "Title",
                value: "Timesmart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "78iu214b-2067-47fc-9eaa-d3ac4b4f0352",
                columns: new[] { "Title", "Type" },
                values: new object[] { "Timesmart List", 1 });

            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                column: "Title",
                value: "Timesmart Registration");
        }
    }
}
