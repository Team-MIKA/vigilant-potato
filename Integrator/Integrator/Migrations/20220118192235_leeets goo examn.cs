using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class leeetsgooexamn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Widgets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WidgetId = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_Widgets_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Option_WidgetId",
                table: "Option",
                column: "WidgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Widgets");

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type" },
                values: new object[] { "a0cd214b-2067-47fc-9eaa-d3ac4b4f0353", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart", 1 });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type" },
                values: new object[] { "78iu214b-2067-47fc-9eaa-d3ac4b4f0352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Timesmart Registrations", 2 });

            migrationBuilder.InsertData(
                table: "Widgets",
                columns: new[] { "Id", "Created", "Modified", "Title", "Type" },
                values: new object[] { "hy67214b-2067-47fc-9eaa-d3ac4b4f0351", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAP List", 0 });
        }
    }
}
