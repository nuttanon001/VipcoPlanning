using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class updateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_CuttingPlanCheckId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_CuttingPlanId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_PackingCheckId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_PackingId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_ShopDrawingCheckId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHour_StandardTime_ShopDrawingId",
                table: "EngineerManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_FabricationManHour_StandardTime_FabricationId",
                table: "FabricationManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_FabricationManHour_StandardTime_PerAssemblyId",
                table: "FabricationManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryPlanMaster_PlanMaster_PlanMasterId",
                table: "HistoryPlanMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_PackingManHour_StandardTime_PackingId",
                table: "PackingManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_BillofMaterial_BillofMaterialId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_EngineerManHour_EngineerManHourId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_FabricationManHour_FabricationManHourId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_PackingManHour_PackingManHourId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_PlanMaster_PlanMasterId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetail_WeldManHour_WeldManHourId",
                table: "PlanDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RateManHour_StandardTimeForWorkGroup_StandardTimeForId",
                table: "RateManHour");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardTime_GroupStandardTime_GroupStandardId",
                table: "StandardTime");

            migrationBuilder.DropForeignKey(
                name: "FK_WeldManHour_StandardTime_WeldId",
                table: "WeldManHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeldManHour",
                table: "WeldManHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateManHour",
                table: "RateManHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanMaster",
                table: "PlanMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDetail",
                table: "PlanDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackingManHour",
                table: "PackingManHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryPlanMaster",
                table: "HistoryPlanMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStandardTime",
                table: "GroupStandardTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FabricationManHour",
                table: "FabricationManHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerManHour",
                table: "EngineerManHour");

            migrationBuilder.RenameTable(
                name: "WeldManHour",
                newName: "WeldManHours");

            migrationBuilder.RenameTable(
                name: "RateManHour",
                newName: "RateManHours");

            migrationBuilder.RenameTable(
                name: "PlanMaster",
                newName: "PlanMasters");

            migrationBuilder.RenameTable(
                name: "PlanDetail",
                newName: "PlanDetails");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "PackingManHour",
                newName: "PackingManHours");

            migrationBuilder.RenameTable(
                name: "HistoryPlanMaster",
                newName: "HistoryPlanMasters");

            migrationBuilder.RenameTable(
                name: "GroupStandardTime",
                newName: "GroupStandardTimes");

            migrationBuilder.RenameTable(
                name: "FabricationManHour",
                newName: "FabricationManHours");

            migrationBuilder.RenameTable(
                name: "EngineerManHour",
                newName: "EngineerManHours");

            migrationBuilder.RenameIndex(
                name: "IX_WeldManHour_WeldId",
                table: "WeldManHours",
                newName: "IX_WeldManHours_WeldId");

            migrationBuilder.RenameIndex(
                name: "IX_RateManHour_StandardTimeForId",
                table: "RateManHours",
                newName: "IX_RateManHours_StandardTimeForId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_WeldManHourId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_WeldManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_PlanMasterId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_PlanMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_PackingManHourId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_PackingManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_FabricationManHourId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_FabricationManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_EngineerManHourId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_EngineerManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetail_BillofMaterialId",
                table: "PlanDetails",
                newName: "IX_PlanDetails_BillofMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_PackingManHour_PackingId",
                table: "PackingManHours",
                newName: "IX_PackingManHours_PackingId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMasters",
                newName: "IX_HistoryPlanMasters_PlanMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_FabricationManHour_PerAssemblyId",
                table: "FabricationManHours",
                newName: "IX_FabricationManHours_PerAssemblyId");

            migrationBuilder.RenameIndex(
                name: "IX_FabricationManHour_FabricationId",
                table: "FabricationManHours",
                newName: "IX_FabricationManHours_FabricationId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_ShopDrawingId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_ShopDrawingId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_ShopDrawingCheckId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_ShopDrawingCheckId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_PackingId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_PackingId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_PackingCheckId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_PackingCheckId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_CuttingPlanId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_CuttingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHour_CuttingPlanCheckId",
                table: "EngineerManHours",
                newName: "IX_EngineerManHours_CuttingPlanCheckId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupCode",
                table: "WorkGroupHasNickName",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualType",
                table: "WorkGroupHasNickName",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceGroupCode",
                table: "WorkGroupHasNickName",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeldManHours",
                table: "WeldManHours",
                column: "WeldManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateManHours",
                table: "RateManHours",
                column: "RateManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanMasters",
                table: "PlanMasters",
                column: "PlanMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDetails",
                table: "PlanDetails",
                column: "PlanDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackingManHours",
                table: "PackingManHours",
                column: "PackingManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryPlanMasters",
                table: "HistoryPlanMasters",
                column: "HistoryPlanMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStandardTimes",
                table: "GroupStandardTimes",
                column: "GroupStandardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FabricationManHours",
                table: "FabricationManHours",
                column: "FabricationManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerManHours",
                table: "EngineerManHours",
                column: "EngineerManHourId");

            migrationBuilder.CreateTable(
                name: "ActualMasters",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ActualMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(maxLength: 200, nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    ActualStatus = table.Column<int>(nullable: true),
                    ProjectCodeMasterId = table.Column<int>(nullable: true),
                    PlanMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualMasters", x => x.ActualMasterId);
                });

            migrationBuilder.CreateTable(
                name: "ActualDetails",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ActualDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupCode = table.Column<string>(maxLength: 50, nullable: true),
                    GroupName = table.Column<string>(maxLength: 200, nullable: true),
                    WorkShop = table.Column<string>(maxLength: 50, nullable: true),
                    TotalManHour = table.Column<double>(nullable: true),
                    TotalManHourOT = table.Column<double>(nullable: true),
                    TotalManHourNTOT = table.Column<double>(nullable: true),
                    WeightPlan = table.Column<double>(nullable: true),
                    TotalPlanManHour = table.Column<double>(nullable: true),
                    ActualType = table.Column<int>(nullable: true),
                    ActualMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualDetails", x => x.ActualDetailId);
                    table.ForeignKey(
                        name: "FK_ActualDetails_ActualMasters_ActualMasterId",
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

            migrationBuilder.CreateIndex(
                name: "IX_ActualDetails_ActualMasterId",
                table: "ActualDetails",
                column: "ActualMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_CuttingPlanCheckId",
                table: "EngineerManHours",
                column: "CuttingPlanCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_CuttingPlanId",
                table: "EngineerManHours",
                column: "CuttingPlanId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_PackingCheckId",
                table: "EngineerManHours",
                column: "PackingCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_PackingId",
                table: "EngineerManHours",
                column: "PackingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_ShopDrawingCheckId",
                table: "EngineerManHours",
                column: "ShopDrawingCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHours_StandardTime_ShopDrawingId",
                table: "EngineerManHours",
                column: "ShopDrawingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FabricationManHours_StandardTime_FabricationId",
                table: "FabricationManHours",
                column: "FabricationId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FabricationManHours_StandardTime_PerAssemblyId",
                table: "FabricationManHours",
                column: "PerAssemblyId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryPlanMasters_PlanMasters_PlanMasterId",
                table: "HistoryPlanMasters",
                column: "PlanMasterId",
                principalTable: "PlanMasters",
                principalColumn: "PlanMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackingManHours_StandardTime_PackingId",
                table: "PackingManHours",
                column: "PackingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_BillofMaterial_BillofMaterialId",
                table: "PlanDetails",
                column: "BillofMaterialId",
                principalTable: "BillofMaterial",
                principalColumn: "BillofMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_EngineerManHours_EngineerManHourId",
                table: "PlanDetails",
                column: "EngineerManHourId",
                principalTable: "EngineerManHours",
                principalColumn: "EngineerManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_FabricationManHours_FabricationManHourId",
                table: "PlanDetails",
                column: "FabricationManHourId",
                principalTable: "FabricationManHours",
                principalColumn: "FabricationManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_PackingManHours_PackingManHourId",
                table: "PlanDetails",
                column: "PackingManHourId",
                principalTable: "PackingManHours",
                principalColumn: "PackingManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_PlanMasters_PlanMasterId",
                table: "PlanDetails",
                column: "PlanMasterId",
                principalTable: "PlanMasters",
                principalColumn: "PlanMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetails_WeldManHours_WeldManHourId",
                table: "PlanDetails",
                column: "WeldManHourId",
                principalTable: "WeldManHours",
                principalColumn: "WeldManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RateManHours_StandardTimeForWorkGroup_StandardTimeForId",
                table: "RateManHours",
                column: "StandardTimeForId",
                principalTable: "StandardTimeForWorkGroup",
                principalColumn: "StandardTimeForId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardTime_GroupStandardTimes_GroupStandardId",
                table: "StandardTime",
                column: "GroupStandardId",
                principalTable: "GroupStandardTimes",
                principalColumn: "GroupStandardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeldManHours_StandardTime_WeldId",
                table: "WeldManHours",
                column: "WeldId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_CuttingPlanCheckId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_CuttingPlanId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_PackingCheckId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_PackingId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_ShopDrawingCheckId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerManHours_StandardTime_ShopDrawingId",
                table: "EngineerManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_FabricationManHours_StandardTime_FabricationId",
                table: "FabricationManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_FabricationManHours_StandardTime_PerAssemblyId",
                table: "FabricationManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryPlanMasters_PlanMasters_PlanMasterId",
                table: "HistoryPlanMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_PackingManHours_StandardTime_PackingId",
                table: "PackingManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_BillofMaterial_BillofMaterialId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_EngineerManHours_EngineerManHourId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_FabricationManHours_FabricationManHourId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_PackingManHours_PackingManHourId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_PlanMasters_PlanMasterId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanDetails_WeldManHours_WeldManHourId",
                table: "PlanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RateManHours_StandardTimeForWorkGroup_StandardTimeForId",
                table: "RateManHours");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardTime_GroupStandardTimes_GroupStandardId",
                table: "StandardTime");

            migrationBuilder.DropForeignKey(
                name: "FK_WeldManHours_StandardTime_WeldId",
                table: "WeldManHours");

            migrationBuilder.DropTable(
                name: "ActualDetails");

            migrationBuilder.DropTable(
                name: "ActualMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeldManHours",
                table: "WeldManHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateManHours",
                table: "RateManHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanMasters",
                table: "PlanMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDetails",
                table: "PlanDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackingManHours",
                table: "PackingManHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryPlanMasters",
                table: "HistoryPlanMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStandardTimes",
                table: "GroupStandardTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FabricationManHours",
                table: "FabricationManHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EngineerManHours",
                table: "EngineerManHours");

            migrationBuilder.DropColumn(
                name: "ActualType",
                table: "WorkGroupHasNickName");

            migrationBuilder.DropColumn(
                name: "ReferenceGroupCode",
                table: "WorkGroupHasNickName");

            migrationBuilder.RenameTable(
                name: "WeldManHours",
                newName: "WeldManHour");

            migrationBuilder.RenameTable(
                name: "RateManHours",
                newName: "RateManHour");

            migrationBuilder.RenameTable(
                name: "PlanMasters",
                newName: "PlanMaster");

            migrationBuilder.RenameTable(
                name: "PlanDetails",
                newName: "PlanDetail");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "PackingManHours",
                newName: "PackingManHour");

            migrationBuilder.RenameTable(
                name: "HistoryPlanMasters",
                newName: "HistoryPlanMaster");

            migrationBuilder.RenameTable(
                name: "GroupStandardTimes",
                newName: "GroupStandardTime");

            migrationBuilder.RenameTable(
                name: "FabricationManHours",
                newName: "FabricationManHour");

            migrationBuilder.RenameTable(
                name: "EngineerManHours",
                newName: "EngineerManHour");

            migrationBuilder.RenameIndex(
                name: "IX_WeldManHours_WeldId",
                table: "WeldManHour",
                newName: "IX_WeldManHour_WeldId");

            migrationBuilder.RenameIndex(
                name: "IX_RateManHours_StandardTimeForId",
                table: "RateManHour",
                newName: "IX_RateManHour_StandardTimeForId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_WeldManHourId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_WeldManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_PlanMasterId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_PlanMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_PackingManHourId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_PackingManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_FabricationManHourId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_FabricationManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_EngineerManHourId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_EngineerManHourId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDetails_BillofMaterialId",
                table: "PlanDetail",
                newName: "IX_PlanDetail_BillofMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_PackingManHours_PackingId",
                table: "PackingManHour",
                newName: "IX_PackingManHour_PackingId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryPlanMasters_PlanMasterId",
                table: "HistoryPlanMaster",
                newName: "IX_HistoryPlanMaster_PlanMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_FabricationManHours_PerAssemblyId",
                table: "FabricationManHour",
                newName: "IX_FabricationManHour_PerAssemblyId");

            migrationBuilder.RenameIndex(
                name: "IX_FabricationManHours_FabricationId",
                table: "FabricationManHour",
                newName: "IX_FabricationManHour_FabricationId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_ShopDrawingId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_ShopDrawingId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_ShopDrawingCheckId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_ShopDrawingCheckId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_PackingId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_PackingId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_PackingCheckId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_PackingCheckId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_CuttingPlanId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_CuttingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerManHours_CuttingPlanCheckId",
                table: "EngineerManHour",
                newName: "IX_EngineerManHour_CuttingPlanCheckId");

            migrationBuilder.AlterColumn<string>(
                name: "GroupCode",
                table: "WorkGroupHasNickName",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeldManHour",
                table: "WeldManHour",
                column: "WeldManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateManHour",
                table: "RateManHour",
                column: "RateManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanMaster",
                table: "PlanMaster",
                column: "PlanMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDetail",
                table: "PlanDetail",
                column: "PlanDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "PermissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackingManHour",
                table: "PackingManHour",
                column: "PackingManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryPlanMaster",
                table: "HistoryPlanMaster",
                column: "HistoryPlanMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStandardTime",
                table: "GroupStandardTime",
                column: "GroupStandardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FabricationManHour",
                table: "FabricationManHour",
                column: "FabricationManHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EngineerManHour",
                table: "EngineerManHour",
                column: "EngineerManHourId");

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 18,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 19,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "WorkGroupHasNickName",
                keyColumn: "WorkGroupNickNameId",
                keyValue: 20,
                column: "CreateDate",
                value: new DateTime(2018, 7, 4, 11, 9, 10, 802, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_CuttingPlanCheckId",
                table: "EngineerManHour",
                column: "CuttingPlanCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_CuttingPlanId",
                table: "EngineerManHour",
                column: "CuttingPlanId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_PackingCheckId",
                table: "EngineerManHour",
                column: "PackingCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_PackingId",
                table: "EngineerManHour",
                column: "PackingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_ShopDrawingCheckId",
                table: "EngineerManHour",
                column: "ShopDrawingCheckId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerManHour_StandardTime_ShopDrawingId",
                table: "EngineerManHour",
                column: "ShopDrawingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FabricationManHour_StandardTime_FabricationId",
                table: "FabricationManHour",
                column: "FabricationId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FabricationManHour_StandardTime_PerAssemblyId",
                table: "FabricationManHour",
                column: "PerAssemblyId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryPlanMaster_PlanMaster_PlanMasterId",
                table: "HistoryPlanMaster",
                column: "PlanMasterId",
                principalTable: "PlanMaster",
                principalColumn: "PlanMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackingManHour_StandardTime_PackingId",
                table: "PackingManHour",
                column: "PackingId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_BillofMaterial_BillofMaterialId",
                table: "PlanDetail",
                column: "BillofMaterialId",
                principalTable: "BillofMaterial",
                principalColumn: "BillofMaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_EngineerManHour_EngineerManHourId",
                table: "PlanDetail",
                column: "EngineerManHourId",
                principalTable: "EngineerManHour",
                principalColumn: "EngineerManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_FabricationManHour_FabricationManHourId",
                table: "PlanDetail",
                column: "FabricationManHourId",
                principalTable: "FabricationManHour",
                principalColumn: "FabricationManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_PackingManHour_PackingManHourId",
                table: "PlanDetail",
                column: "PackingManHourId",
                principalTable: "PackingManHour",
                principalColumn: "PackingManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_PlanMaster_PlanMasterId",
                table: "PlanDetail",
                column: "PlanMasterId",
                principalTable: "PlanMaster",
                principalColumn: "PlanMasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDetail_WeldManHour_WeldManHourId",
                table: "PlanDetail",
                column: "WeldManHourId",
                principalTable: "WeldManHour",
                principalColumn: "WeldManHourId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RateManHour_StandardTimeForWorkGroup_StandardTimeForId",
                table: "RateManHour",
                column: "StandardTimeForId",
                principalTable: "StandardTimeForWorkGroup",
                principalColumn: "StandardTimeForId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardTime_GroupStandardTime_GroupStandardId",
                table: "StandardTime",
                column: "GroupStandardId",
                principalTable: "GroupStandardTime",
                principalColumn: "GroupStandardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeldManHour_StandardTime_WeldId",
                table: "WeldManHour",
                column: "WeldId",
                principalTable: "StandardTime",
                principalColumn: "StandardTimeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
