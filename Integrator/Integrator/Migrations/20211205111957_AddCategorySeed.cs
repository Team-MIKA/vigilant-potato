using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class AddCategorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RegistrationCategories",
                columns: new[] { "Id", "Created", "Modified", "Text" },
                values: new object[,]
                {
                    { "a6cd214b-2067-47fc-9eaa-d3ac4b4f0353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quality" },
                    { "a6iu214b-2067-47fc-9eaa-d3ac4b4f0352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Error" },
                    { "a667214b-2067-47fc-9eaa-d3ac4b4f0351", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Break" },
                    { "abb7214b-2067-47fc-9ebb-d3ac4b4f0351", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meeting" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: "a667214b-2067-47fc-9eaa-d3ac4b4f0351");

            migrationBuilder.DeleteData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: "a6cd214b-2067-47fc-9eaa-d3ac4b4f0353");

            migrationBuilder.DeleteData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: "a6iu214b-2067-47fc-9eaa-d3ac4b4f0352");

            migrationBuilder.DeleteData(
                table: "RegistrationCategories",
                keyColumn: "Id",
                keyValue: "abb7214b-2067-47fc-9ebb-d3ac4b4f0351");
        }
    }
}
