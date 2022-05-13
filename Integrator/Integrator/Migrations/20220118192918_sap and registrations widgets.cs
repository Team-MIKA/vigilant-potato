using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class sapandregistrationswidgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                column: "Url",
                value: "https://api.aaen.cloud/TimeSmart/InsertRegistration");

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type", "Url" },
                values: new object[] { "hy67214b-2067-47fc-9eaa-d3ac4b4f0351", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAP List", 0, "https://app.aaen.cloud/api/sap" });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type", "Url" },
                values: new object[] { "78iu214b-2067-47fc-9eaa-d3ac4b4f0352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart Registrations", 2, "https://api.aaen.cloud/TimeSmart/GetCategories" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Created", "Key", "Modified", "Value", "WidgetId" },
                values: new object[] { "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "username", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", "78iu214b-2067-47fc-9eaa-d3ac4b4f0352" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Created", "Key", "Modified", "Value", "WidgetId" },
                values: new object[] { "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "password", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VeryGoodPassword", "78iu214b-2067-47fc-9eaa-d3ac4b4f0352" });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Created", "Key", "Modified", "Value", "WidgetId" },
                values: new object[] { "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "api-key", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a4db08b7-5729-4ba9-8c08-f2df493465a", "hy67214b-2067-47fc-9eaa-d3ac4b4f0351" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "78iu214b-2067-47fc-9eaa-d3ac4b4f0352");

            migrationBuilder.DeleteData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "hy67214b-2067-47fc-9eaa-d3ac4b4f0351");

            migrationBuilder.UpdateData(
                table: "Widgets",
                keyColumn: "Id",
                keyValue: "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353",
                column: "Url",
                value: "https://app.aaen.cloud/TimeSmart/InsertRegistration");
        }
    }
}
