using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class updateAcutal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "ActualDetails",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 978, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 10, 24, 13, 9, 33, 979, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "ActualDetails");

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 152, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 10, 19, 14, 52, 15, 153, DateTimeKind.Local));
        }
    }
}
