using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VipcoPlanning.Migrations
{
    public partial class IntliCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillofMaterial",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    BillofMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    LevelofBom = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Remark = table.Column<string>(maxLength: 250, nullable: true),
                    BomParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillofMaterial", x => x.BillofMaterialId);
                    table.ForeignKey(
                        name: "FK_BillofMaterial_BillofMaterial_BomParentId",
                        column: x => x.BomParentId,
                        principalTable: "BillofMaterial",
                        principalColumn: "BillofMaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupStandardTime",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    GroupStandardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStandardTime", x => x.GroupStandardId);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    LevelPermission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaster",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PlanMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(maxLength: 200, nullable: true),
                    Revised = table.Column<int>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    PlanningStatus = table.Column<int>(nullable: true),
                    ProjectCodeMasterId = table.Column<int>(nullable: true),
                    ManagementBy = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMaster", x => x.PlanMasterId);
                });

            migrationBuilder.CreateTable(
                name: "StandardTime",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    StandardTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Rate = table.Column<double>(nullable: true),
                    RateUnit = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Remark = table.Column<string>(maxLength: 250, nullable: true),
                    GroupStandardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTime", x => x.StandardTimeId);
                    table.ForeignKey(
                        name: "FK_StandardTime_GroupStandardTime_GroupStandardId",
                        column: x => x.GroupStandardId,
                        principalTable: "GroupStandardTime",
                        principalColumn: "GroupStandardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoryPlanMaster",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    HistoryPlanMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    PlanMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPlanMaster", x => x.HistoryPlanMasterId);
                    table.ForeignKey(
                        name: "FK_HistoryPlanMaster_PlanMaster_PlanMasterId",
                        column: x => x.PlanMasterId,
                        principalTable: "PlanMaster",
                        principalColumn: "PlanMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EngineerManHour",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    EngineerManHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngineerWeight = table.Column<double>(nullable: true),
                    ShopDrawingMH = table.Column<double>(nullable: true),
                    ShopDrawingCheckMH = table.Column<double>(nullable: true),
                    CuttingPlanMH = table.Column<double>(nullable: true),
                    CuttingPlanCheckMH = table.Column<double>(nullable: true),
                    PackingMH = table.Column<double>(nullable: true),
                    PackingCheckMH = table.Column<double>(nullable: true),
                    ShopDrawingId = table.Column<int>(nullable: true),
                    ShopDrawingCheckId = table.Column<int>(nullable: true),
                    CuttingPlanId = table.Column<int>(nullable: true),
                    CuttingPlanCheckId = table.Column<int>(nullable: true),
                    PackingId = table.Column<int>(nullable: true),
                    PackingCheckId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerManHour", x => x.EngineerManHourId);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_CuttingPlanCheckId",
                        column: x => x.CuttingPlanCheckId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_CuttingPlanId",
                        column: x => x.CuttingPlanId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_PackingCheckId",
                        column: x => x.PackingCheckId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_PackingId",
                        column: x => x.PackingId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_ShopDrawingCheckId",
                        column: x => x.ShopDrawingCheckId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EngineerManHour_StandardTime_ShopDrawingId",
                        column: x => x.ShopDrawingId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FabricationManHour",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    FabricationManHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FabricationWeight = table.Column<double>(nullable: true),
                    FabricationMH = table.Column<double>(nullable: true),
                    PerAssemblyMH = table.Column<double>(nullable: true),
                    FabricationId = table.Column<int>(nullable: true),
                    PerAssemblyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricationManHour", x => x.FabricationManHourId);
                    table.ForeignKey(
                        name: "FK_FabricationManHour_StandardTime_FabricationId",
                        column: x => x.FabricationId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FabricationManHour_StandardTime_PerAssemblyId",
                        column: x => x.PerAssemblyId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackingManHour",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PackingManHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PackingWeight = table.Column<double>(nullable: true),
                    PackingMH = table.Column<double>(nullable: true),
                    PackingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingManHour", x => x.PackingManHourId);
                    table.ForeignKey(
                        name: "FK_PackingManHour_StandardTime_PackingId",
                        column: x => x.PackingId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeldManHour",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    WeldManHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeldWetght = table.Column<double>(nullable: true),
                    WeldMH = table.Column<double>(nullable: true),
                    WeldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeldManHour", x => x.WeldManHourId);
                    table.ForeignKey(
                        name: "FK_WeldManHour_StandardTime_WeldId",
                        column: x => x.WeldId,
                        principalTable: "StandardTime",
                        principalColumn: "StandardTimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                columns: table => new
                {
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Modifyer = table.Column<string>(maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    PlanDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    ContentWeigth = table.Column<double>(nullable: true),
                    CustomerDrawingDate = table.Column<DateTime>(nullable: true),
                    ShopDrawingDate = table.Column<DateTime>(nullable: true),
                    CuttingPlanDate = table.Column<DateTime>(nullable: true),
                    MaterialDate = table.Column<DateTime>(nullable: true),
                    MachineAndPartDate = table.Column<DateTime>(nullable: true),
                    FabPlanSDate = table.Column<DateTime>(nullable: true),
                    FabPlanEDate = table.Column<DateTime>(nullable: true),
                    PreAssPlanSDate = table.Column<DateTime>(nullable: true),
                    PreAssPlanEDate = table.Column<DateTime>(nullable: true),
                    PaintPlanSDate = table.Column<DateTime>(nullable: true),
                    PaintPlanEDate = table.Column<DateTime>(nullable: true),
                    InsuPlanSDate = table.Column<DateTime>(nullable: true),
                    InsuPlanEDate = table.Column<DateTime>(nullable: true),
                    PackPlanSDate = table.Column<DateTime>(nullable: true),
                    PackPlanEDate = table.Column<DateTime>(nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    ResponsibilityBy = table.Column<string>(maxLength: 50, nullable: true),
                    AssignmentToGroup = table.Column<string>(maxLength: 50, nullable: true),
                    PlanMasterId = table.Column<int>(nullable: true),
                    BillofMaterialId = table.Column<int>(nullable: true),
                    EngineerManHourId = table.Column<int>(nullable: true),
                    FabricationManHourId = table.Column<int>(nullable: true),
                    PackingManHourId = table.Column<int>(nullable: true),
                    WeldManHourId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.PlanDetailId);
                    table.ForeignKey(
                        name: "FK_PlanDetail_BillofMaterial_BillofMaterialId",
                        column: x => x.BillofMaterialId,
                        principalTable: "BillofMaterial",
                        principalColumn: "BillofMaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_EngineerManHour_EngineerManHourId",
                        column: x => x.EngineerManHourId,
                        principalTable: "EngineerManHour",
                        principalColumn: "EngineerManHourId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_FabricationManHour_FabricationManHourId",
                        column: x => x.FabricationManHourId,
                        principalTable: "FabricationManHour",
                        principalColumn: "FabricationManHourId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_PackingManHour_PackingManHourId",
                        column: x => x.PackingManHourId,
                        principalTable: "PackingManHour",
                        principalColumn: "PackingManHourId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_PlanMaster_PlanMasterId",
                        column: x => x.PlanMasterId,
                        principalTable: "PlanMaster",
                        principalColumn: "PlanMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanDetail_WeldManHour_WeldManHourId",
                        column: x => x.WeldManHourId,
                        principalTable: "WeldManHour",
                        principalColumn: "WeldManHourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillofMaterial_BomParentId",
                table: "BillofMaterial",
                column: "BomParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BillofMaterial_Code",
                table: "BillofMaterial",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_CuttingPlanCheckId",
                table: "EngineerManHour",
                column: "CuttingPlanCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_CuttingPlanId",
                table: "EngineerManHour",
                column: "CuttingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_PackingCheckId",
                table: "EngineerManHour",
                column: "PackingCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_PackingId",
                table: "EngineerManHour",
                column: "PackingId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_ShopDrawingCheckId",
                table: "EngineerManHour",
                column: "ShopDrawingCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerManHour_ShopDrawingId",
                table: "EngineerManHour",
                column: "ShopDrawingId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricationManHour_FabricationId",
                table: "FabricationManHour",
                column: "FabricationId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricationManHour_PerAssemblyId",
                table: "FabricationManHour",
                column: "PerAssemblyId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPlanMaster_PlanMasterId",
                table: "HistoryPlanMaster",
                column: "PlanMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PackingManHour_PackingId",
                table: "PackingManHour",
                column: "PackingId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_BillofMaterialId",
                table: "PlanDetail",
                column: "BillofMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_EngineerManHourId",
                table: "PlanDetail",
                column: "EngineerManHourId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_FabricationManHourId",
                table: "PlanDetail",
                column: "FabricationManHourId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PackingManHourId",
                table: "PlanDetail",
                column: "PackingManHourId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanMasterId",
                table: "PlanDetail",
                column: "PlanMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_WeldManHourId",
                table: "PlanDetail",
                column: "WeldManHourId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTime_Code",
                table: "StandardTime",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTime_GroupStandardId",
                table: "StandardTime",
                column: "GroupStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_WeldManHour_WeldId",
                table: "WeldManHour",
                column: "WeldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryPlanMaster");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "BillofMaterial");

            migrationBuilder.DropTable(
                name: "EngineerManHour");

            migrationBuilder.DropTable(
                name: "FabricationManHour");

            migrationBuilder.DropTable(
                name: "PackingManHour");

            migrationBuilder.DropTable(
                name: "PlanMaster");

            migrationBuilder.DropTable(
                name: "WeldManHour");

            migrationBuilder.DropTable(
                name: "StandardTime");

            migrationBuilder.DropTable(
                name: "GroupStandardTime");
        }
    }
}
