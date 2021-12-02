using Microsoft.EntityFrameworkCore.Migrations;

namespace Integrator.Migrations
{
    public partial class addedCascadingDeleteOnWorkspaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceWidgets_Workspaces_WorkspaceId",
                table: "WorkspaceWidgets");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceWidgets_Workspaces_WorkspaceId",
                table: "WorkspaceWidgets",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkspaceWidgets_Workspaces_WorkspaceId",
                table: "WorkspaceWidgets");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkspaceWidgets_Workspaces_WorkspaceId",
                table: "WorkspaceWidgets",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
