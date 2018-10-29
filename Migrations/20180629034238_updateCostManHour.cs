using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class updateCostManHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMaster");

            migrationBuilder.CreateTable(
                name: "RateManHour",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    RateManHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    RateBathPerManHour = table.Column<double>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    StandardTimeForId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateManHour", x => x.RateManHourId);
                    table.ForeignKey(
                        name: "FK_RateManHour_StandardTimeForWorkGroup_StandardTimeForId",
                        column: x => x.StandardTimeForId,
                        principalTable: "StandardTimeForWorkGroup",
                        principalColumn: "StandardTimeForId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMaster",
                column: "PlanMasterId",
                unique: true,
                filter: "[PlanMasterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RateManHour_StandardTimeForId",
                table: "RateManHour",
                column: "StandardTimeForId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateManHour");

            migrationBuilder.DropIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMaster");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMaster",
                column: "PlanMasterId");
        }
    }
}
