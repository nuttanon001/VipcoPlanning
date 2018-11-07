using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class addPlanshipment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagementName",
                table: "PlanMasters",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlanShipments",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PlanShipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateShipment = table.Column<DateTime>(nullable: true),
                    SequenceNo = table.Column<int>(nullable: true),
                    PlanMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanShipments", x => x.PlanShipmentId);
                    table.ForeignKey(
                        name: "FK_PlanShipments_PlanMasters_PlanMasterId",
                        column: x => x.PlanMasterId,
                        principalTable: "PlanMasters",
                        principalColumn: "PlanMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_PlanShipments_PlanMasterId",
                table: "PlanShipments",
                column: "PlanMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanShipments");

            migrationBuilder.DropColumn(
                name: "ManagementName",
                table: "PlanMasters");

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 10, 29, 14, 12, 52, 271, DateTimeKind.Local));
        }
    }
}
