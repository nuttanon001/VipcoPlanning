using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class WorkGroupHasNickName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkGroupHasNickName",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    WorkGroupNickNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NickName = table.Column<string>(maxLength: 200, nullable: true),
                    GroupCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGroupHasNickName", x => x.WorkGroupNickNameId);
                });

            migrationBuilder.InsertData(
                table: "WorkGroupHasNickName",
                columns: new[] { "WorkGroupNickNameId", "CreateDate", "Creator", "GroupCode", "ModifyDate", "Modifyer", "NickName" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA01", null, null, "S Chumsaeng" },
                    { 18, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA13", null, null, "Sompian" },
                    { 17, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA12", null, null, "Thongdee" },
                    { 16, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA10", null, null, "Boonlert" },
                    { 15, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA09", null, null, "Kittipong" },
                    { 14, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA08", null, null, "Phairat" },
                    { 13, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA07", null, null, "Suwan" },
                    { 12, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA06", null, null, "San" },
                    { 11, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA05", null, null, "Narintron" },
                    { 10, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA02", null, null, "Wichit" },
                    { 9, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA09", null, null, "S Yai" },
                    { 8, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA08", null, null, "S Surat" },
                    { 7, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA07", null, null, "S Sumruoy" },
                    { 6, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA06", null, null, "S Boonma" },
                    { 5, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA05", null, null, "S Montree" },
                    { 4, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA04", null, null, "S Kritsada" },
                    { 3, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA03", null, null, "S Kitti" },
                    { 2, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "CFA02", null, null, "S Malee" },
                    { 19, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA14", null, null, "Boonyuen" },
                    { 20, new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local), "SeedData", "DFA18", null, null, "Sil" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkGroupHasNickName_NickName",
                table: "WorkGroupHasNickName",
                column: "NickName",
                unique: true,
                filter: "[NickName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkGroupHasNickName");
        }
    }
}
