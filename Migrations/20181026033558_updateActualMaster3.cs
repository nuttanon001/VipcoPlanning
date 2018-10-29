using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class updateActualMaster3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OverTimemultiply",
                table: "ActualMasters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActualBoms",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ActualBomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BomCode = table.Column<string>(maxLength: 50, nullable: true),
                    BomName = table.Column<string>(maxLength: 200, nullable: true),
                    TotalManHour = table.Column<double>(nullable: true),
                    TotalManHourOT = table.Column<double>(nullable: true),
                    TotalManHourNTOT = table.Column<double>(nullable: true),
                    WeightPlan = table.Column<double>(nullable: true),
                    TotalPlanManHour = table.Column<double>(nullable: true),
                    ActualMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualBoms", x => x.ActualBomId);
                    table.ForeignKey(
                        name: "FK_ActualBoms_ActualMasters_ActualMasterId",
                        column: x => x.ActualMasterId,
                        principalTable: "ActualMasters",
                        principalColumn: "ActualMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 815, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 10, 26, 10, 35, 57, 816, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_ActualBoms_ActualMasterId",
                table: "ActualBoms",
                column: "ActualMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualBoms");

            migrationBuilder.DropColumn(
                name: "OverTimemultiply",
                table: "ActualMasters");

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 953, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 10, 25, 11, 7, 2, 969, DateTimeKind.Local));
        }
    }
}
