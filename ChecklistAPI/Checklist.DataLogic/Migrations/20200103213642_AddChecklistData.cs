using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checklist.DataLogic.Migrations
{
    public partial class AddChecklistData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChecklists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChecklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChecklists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Completed = table.Column<bool>(nullable: false),
                    UserChecklistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistFields_UserChecklists_UserChecklistId",
                        column: x => x.UserChecklistId,
                        principalTable: "UserChecklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ChecklistFieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistImages_ChecklistFields_ChecklistFieldId",
                        column: x => x.ChecklistFieldId,
                        principalTable: "ChecklistFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistFields_UserChecklistId",
                table: "ChecklistFields",
                column: "UserChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistImages_ChecklistFieldId",
                table: "ChecklistImages",
                column: "ChecklistFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChecklists_UserId",
                table: "UserChecklists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistImages");

            migrationBuilder.DropTable(
                name: "ChecklistFields");

            migrationBuilder.DropTable(
                name: "UserChecklists");
        }
    }
}
