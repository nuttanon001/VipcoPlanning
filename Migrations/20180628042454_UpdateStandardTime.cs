using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class UpdateStandardTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StandardTimeForId",
                table: "StandardTime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StandardTimeForWorkGroup",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    StandardTimeForId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTimeForWorkGroup", x => x.StandardTimeForId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardTime_StandardTimeForId",
                table: "StandardTime",
                column: "StandardTimeForId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTimeForWorkGroup_Name",
                table: "StandardTimeForWorkGroup",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardTime_StandardTimeForWorkGroup_StandardTimeForId",
                table: "StandardTime",
                column: "StandardTimeForId",
                principalTable: "StandardTimeForWorkGroup",
                principalColumn: "StandardTimeForId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardTime_StandardTimeForWorkGroup_StandardTimeForId",
                table: "StandardTime");

            migrationBuilder.DropTable(
                name: "StandardTimeForWorkGroup");

            migrationBuilder.DropIndex(
                name: "IX_StandardTime_StandardTimeForId",
                table: "StandardTime");

            migrationBuilder.DropColumn(
                name: "StandardTimeForId",
                table: "StandardTime");
        }
    }
}
