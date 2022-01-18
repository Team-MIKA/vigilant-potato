using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class timesmartwidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Option",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type", "Url" },
                values: new object[] { "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart", 1, "https://app.aaen.cloud/TimeSmart/InsertRegistration" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Created", "Key", "Modified", "Value", "WidgetId" },
                values: new object[] { "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "username", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Created", "Key", "Modified", "Value", "WidgetId" },
                values: new object[] { "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VeryGoodPassword", "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Option",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
