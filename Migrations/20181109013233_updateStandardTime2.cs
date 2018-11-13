using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class updateStandardTime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RateMaster",
                table: "StandardTime",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 11, 9, 8, 32, 33, 428, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateMaster",
                table: "StandardTime");

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
        }
    }
}
