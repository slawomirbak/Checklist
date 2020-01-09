using Microsoft.EntityFrameworkCore.Migrations;

namespace Checklist.DataLogic.Migrations
{
    public partial class chnageChecklistImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistImages_ChecklistFields_ChecklistFieldId",
                table: "ChecklistImages");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistImages_ChecklistFieldId",
                table: "ChecklistImages");

            migrationBuilder.DropColumn(
                name: "ChecklistFieldId",
                table: "ChecklistImages");

            migrationBuilder.AddColumn<int>(
                name: "UserChecklistId",
                table: "ChecklistImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistImages_UserChecklistId",
                table: "ChecklistImages",
                column: "UserChecklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistImages_UserChecklists_UserChecklistId",
                table: "ChecklistImages",
                column: "UserChecklistId",
                principalTable: "UserChecklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistImages_UserChecklists_UserChecklistId",
                table: "ChecklistImages");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistImages_UserChecklistId",
                table: "ChecklistImages");

            migrationBuilder.DropColumn(
                name: "UserChecklistId",
                table: "ChecklistImages");

            migrationBuilder.AddColumn<int>(
                name: "ChecklistFieldId",
                table: "ChecklistImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistImages_ChecklistFieldId",
                table: "ChecklistImages",
                column: "ChecklistFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistImages_ChecklistFields_ChecklistFieldId",
                table: "ChecklistImages",
                column: "ChecklistFieldId",
                principalTable: "ChecklistFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
