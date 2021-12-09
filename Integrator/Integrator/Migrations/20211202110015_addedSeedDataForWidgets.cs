using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class addedSeedDataForWidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title" },
                values: new object[] { "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart Registration" });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title" },
                values: new object[] { "78iu214b-2067-47fc-9eaa-d3ac4b4f0352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart List" });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title" },
                values: new object[] { "hy67214b-2067-47fc-9eaa-d3ac4b4f0351", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAP List" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "78iu214b-2067-47fc-9eaa-d3ac4b4f0352");

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353");

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "hy67214b-2067-47fc-9eaa-d3ac4b4f0351");
        }
    }
}
