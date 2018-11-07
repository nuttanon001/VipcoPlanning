﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.Migrations
{
    [DbContext(typeof(PlanningContext))]
    partial class PlanningContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VipcoPlanning.Models.Planning.ActualBom", b =>
                {
                    b.Property<int>("ActualBomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualDetailType");

                    b.Property<int?>("ActualMasterId");

                    b.Property<int?>("ActualType");

                    b.Property<string>("BomCode")
                        .HasMaxLength(50);

                    b.Property<string>("BomName")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("GroupCode")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<double?>("TotalManHour");

                    b.Property<double?>("TotalManHourNTOT");

                    b.Property<double?>("TotalManHourOT");

                    b.Property<double?>("TotalPlanManHour");

                    b.Property<double?>("WeightPlan");

                    b.HasKey("ActualBomId");

                    b.HasIndex("ActualMasterId");

                    b.ToTable("ActualBoms");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.ActualDetail", b =>
                {
                    b.Property<int>("ActualDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualDetailType");

                    b.Property<int?>("ActualMasterId");

                    b.Property<int?>("ActualType");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("GroupCode")
                        .HasMaxLength(50);

                    b.Property<string>("GroupName")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("NickName")
                        .HasMaxLength(200);

                    b.Property<double?>("TotalManHour");

                    b.Property<double?>("TotalManHourNTOT");

                    b.Property<double?>("TotalManHourOT");

                    b.Property<double?>("TotalPlanManHour");

                    b.Property<double?>("WeightPlan");

                    b.Property<string>("WorkShop")
                        .HasMaxLength(50);

                    b.HasKey("ActualDetailId");

                    b.HasIndex("ActualMasterId");

                    b.ToTable("ActualDetails");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.ActualMaster", b =>
                {
                    b.Property<int>("ActualMasterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualStatus");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<double?>("OverTimemultiply");

                    b.Property<int?>("PlanMasterId");

                    b.Property<int?>("ProjectCodeMasterId");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ValidFrom");

                    b.Property<DateTime?>("ValidTo");

                    b.HasKey("ActualMasterId");

                    b.ToTable("ActualMasters");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.BillofMaterial", b =>
                {
                    b.Property<int>("BillofMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BomParentId");

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("LevelofBom");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<string>("Remark")
                        .HasMaxLength(250);

                    b.HasKey("BillofMaterialId");

                    b.HasIndex("BomParentId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("BillofMaterial");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.EngineerManHour", b =>
                {
                    b.Property<int>("EngineerManHourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<int?>("CuttingPlanCheckId");

                    b.Property<double?>("CuttingPlanCheckMH");

                    b.Property<int?>("CuttingPlanId");

                    b.Property<double?>("CuttingPlanMH");

                    b.Property<double?>("EngineerWeight");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PackingCheckId");

                    b.Property<double?>("PackingCheckMH");

                    b.Property<int?>("PackingId");

                    b.Property<double?>("PackingMH");

                    b.Property<int?>("ShopDrawingCheckId");

                    b.Property<double?>("ShopDrawingCheckMH");

                    b.Property<int?>("ShopDrawingId");

                    b.Property<double?>("ShopDrawingMH");

                    b.HasKey("EngineerManHourId");

                    b.HasIndex("CuttingPlanCheckId");

                    b.HasIndex("CuttingPlanId");

                    b.HasIndex("PackingCheckId");

                    b.HasIndex("PackingId");

                    b.HasIndex("ShopDrawingCheckId");

                    b.HasIndex("ShopDrawingId");

                    b.ToTable("EngineerManHours");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.FabricationManHour", b =>
                {
                    b.Property<int>("FabricationManHourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<int?>("FabricationId");

                    b.Property<double?>("FabricationMH");

                    b.Property<double?>("FabricationWeight");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PerAssemblyId");

                    b.Property<double?>("PerAssemblyMH");

                    b.HasKey("FabricationManHourId");

                    b.HasIndex("FabricationId");

                    b.HasIndex("PerAssemblyId");

                    b.ToTable("FabricationManHours");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.GroupStandardTime", b =>
                {
                    b.Property<int>("GroupStandardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.HasKey("GroupStandardId");

                    b.ToTable("GroupStandardTimes");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.HistoryPlanMaster", b =>
                {
                    b.Property<int>("HistoryPlanMasterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PlanMasterId");

                    b.Property<DateTime?>("ValidFrom");

                    b.Property<DateTime?>("ValidTo");

                    b.HasKey("HistoryPlanMasterId");

                    b.HasIndex("PlanMasterId")
                        .IsUnique()
                        .HasFilter("[PlanMasterId] IS NOT NULL");

                    b.ToTable("HistoryPlanMasters");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PackingManHour", b =>
                {
                    b.Property<int>("PackingManHourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PackingId");

                    b.Property<double?>("PackingMH");

                    b.Property<double?>("PackingWeight");

                    b.HasKey("PackingManHourId");

                    b.HasIndex("PackingId");

                    b.ToTable("PackingManHours");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<int>("LevelPermission");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PlanDetail", b =>
                {
                    b.Property<int>("PlanDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignmentToGroup")
                        .HasMaxLength(50);

                    b.Property<int?>("BillofMaterialId");

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<double?>("ContentWeigth");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CustomerDrawingDate");

                    b.Property<DateTime?>("CuttingPlanDate");

                    b.Property<string>("Description")
                        .HasMaxLength(300);

                    b.Property<int?>("EngineerManHourId");

                    b.Property<DateTime?>("FabPlanEDate");

                    b.Property<DateTime?>("FabPlanSDate");

                    b.Property<int?>("FabricationManHourId");

                    b.Property<DateTime?>("InsuPlanEDate");

                    b.Property<DateTime?>("InsuPlanSDate");

                    b.Property<DateTime?>("MachineAndPartDate");

                    b.Property<DateTime?>("MaterialDate");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("PackPlanEDate");

                    b.Property<DateTime?>("PackPlanSDate");

                    b.Property<int?>("PackingManHourId");

                    b.Property<DateTime?>("PaintPlanEDate");

                    b.Property<DateTime?>("PaintPlanSDate");

                    b.Property<int?>("PlanMasterId");

                    b.Property<DateTime?>("PreAssPlanEDate");

                    b.Property<DateTime?>("PreAssPlanSDate");

                    b.Property<string>("Remark")
                        .HasMaxLength(200);

                    b.Property<string>("ResponsibilityBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ShopDrawingDate");

                    b.Property<int?>("WeldManHourId");

                    b.HasKey("PlanDetailId");

                    b.HasIndex("BillofMaterialId");

                    b.HasIndex("EngineerManHourId");

                    b.HasIndex("FabricationManHourId");

                    b.HasIndex("PackingManHourId");

                    b.HasIndex("PlanMasterId");

                    b.HasIndex("WeldManHourId");

                    b.ToTable("PlanDetails");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PlanMaster", b =>
                {
                    b.Property<int>("PlanMasterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeliveryDate");

                    b.Property<string>("ManagementBy")
                        .HasMaxLength(50);

                    b.Property<string>("ManagementName")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PlanningStatus");

                    b.Property<int?>("ProjectCodeMasterId");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(200);

                    b.Property<int?>("Revised");

                    b.HasKey("PlanMasterId");

                    b.ToTable("PlanMasters");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PlanShipment", b =>
                {
                    b.Property<int>("PlanShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DateShipment");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("PlanMasterId");

                    b.Property<int?>("SequenceNo");

                    b.HasKey("PlanShipmentId");

                    b.HasIndex("PlanMasterId");

                    b.ToTable("PlanShipments");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.RateManHour", b =>
                {
                    b.Property<int>("RateManHourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<double?>("RateBathPerManHour");

                    b.Property<int?>("StandardTimeForId");

                    b.Property<DateTime?>("ValidFrom");

                    b.Property<DateTime?>("ValidTo");

                    b.HasKey("RateManHourId");

                    b.HasIndex("StandardTimeForId");

                    b.ToTable("RateManHours");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.StandardTime", b =>
                {
                    b.Property<int>("StandardTimeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("GroupStandardId");

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<double?>("Rate");

                    b.Property<string>("RateUnit")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasMaxLength(250);

                    b.Property<int?>("StandardTimeForId");

                    b.HasKey("StandardTimeId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("GroupStandardId");

                    b.HasIndex("StandardTimeForId");

                    b.ToTable("StandardTime");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.StandardTimeForWorkGroup", b =>
                {
                    b.Property<int>("StandardTimeForId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("StandardTimeForId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("StandardTimeForWorkGroup");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.WeldManHour", b =>
                {
                    b.Property<int>("WeldManHourId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<int?>("WeldId");

                    b.Property<double?>("WeldMH");

                    b.Property<double?>("WeldWetght");

                    b.HasKey("WeldManHourId");

                    b.HasIndex("WeldId");

                    b.ToTable("WeldManHours");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.WorkGroupHasNickName", b =>
                {
                    b.Property<int>("WorkGroupNickNameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualType");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(50);

                    b.Property<string>("GroupCode")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifyDate");

                    b.Property<string>("Modifyer")
                        .HasMaxLength(50);

                    b.Property<string>("NickName")
                        .HasMaxLength(200);

                    b.Property<string>("ReferenceGroupCode")
                        .HasMaxLength(50);

                    b.HasKey("WorkGroupNickNameId");

                    b.HasIndex("NickName")
                        .IsUnique()
                        .HasFilter("[NickName] IS NOT NULL");

                    b.ToTable("WorkGroupHasNickName");

                    b.HasData(
                        new { WorkGroupNickNameId = 1, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 502, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA01", NickName = "S Chumsaeng" },
                        new { WorkGroupNickNameId = 2, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA02", NickName = "S Malee" },
                        new { WorkGroupNickNameId = 3, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA03", NickName = "S Kitti" },
                        new { WorkGroupNickNameId = 4, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA04", NickName = "S Kritsada" },
                        new { WorkGroupNickNameId = 5, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA05", NickName = "S Montree" },
                        new { WorkGroupNickNameId = 6, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA06", NickName = "S Boonma" },
                        new { WorkGroupNickNameId = 7, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA07", NickName = "S Sumruoy" },
                        new { WorkGroupNickNameId = 8, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA08", NickName = "S Surat" },
                        new { WorkGroupNickNameId = 9, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "CFA09", NickName = "S Yai" },
                        new { WorkGroupNickNameId = 10, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA02", NickName = "Wichit" },
                        new { WorkGroupNickNameId = 11, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA05", NickName = "Narintron" },
                        new { WorkGroupNickNameId = 12, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA06", NickName = "San" },
                        new { WorkGroupNickNameId = 13, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA07", NickName = "Suwan" },
                        new { WorkGroupNickNameId = 14, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA08", NickName = "Phairat" },
                        new { WorkGroupNickNameId = 15, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA09", NickName = "Kittipong" },
                        new { WorkGroupNickNameId = 16, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA10", NickName = "Boonlert" },
                        new { WorkGroupNickNameId = 17, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA12", NickName = "Thongdee" },
                        new { WorkGroupNickNameId = 18, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA13", NickName = "Sompian" },
                        new { WorkGroupNickNameId = 19, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA14", NickName = "Boonyuen" },
                        new { WorkGroupNickNameId = 20, CreateDate = new DateTime(2018, 11, 2, 8, 35, 16, 515, DateTimeKind.Local), Creator = "SeedData", GroupCode = "DFA18", NickName = "Sil" }
                    );
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.ActualBom", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.ActualMaster", "ActualMaster")
                        .WithMany("ActualBoms")
                        .HasForeignKey("ActualMasterId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.ActualDetail", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.ActualMaster", "ActualMaster")
                        .WithMany("ActualDetails")
                        .HasForeignKey("ActualMasterId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.BillofMaterial", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.BillofMaterial", "BomParent")
                        .WithMany()
                        .HasForeignKey("BomParentId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.EngineerManHour", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "CuttingPlanCheck")
                        .WithMany()
                        .HasForeignKey("CuttingPlanCheckId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "CuttingPlan")
                        .WithMany()
                        .HasForeignKey("CuttingPlanId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "PackingCheck")
                        .WithMany()
                        .HasForeignKey("PackingCheckId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "Packing")
                        .WithMany()
                        .HasForeignKey("PackingId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "ShopDrawingCheck")
                        .WithMany()
                        .HasForeignKey("ShopDrawingCheckId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "ShopDrawing")
                        .WithMany()
                        .HasForeignKey("ShopDrawingId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.FabricationManHour", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "Fabrication")
                        .WithMany()
                        .HasForeignKey("FabricationId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "PerAssembly")
                        .WithMany()
                        .HasForeignKey("PerAssemblyId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.HistoryPlanMaster", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.PlanMaster", "PlanMaster")
                        .WithOne("HistoryPlanMaster")
                        .HasForeignKey("VipcoPlanning.Models.Planning.HistoryPlanMaster", "PlanMasterId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PackingManHour", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "Packing")
                        .WithMany()
                        .HasForeignKey("PackingId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PlanDetail", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.BillofMaterial", "BillofMaterial")
                        .WithMany()
                        .HasForeignKey("BillofMaterialId");

                    b.HasOne("VipcoPlanning.Models.Planning.EngineerManHour", "EngineerManHour")
                        .WithMany()
                        .HasForeignKey("EngineerManHourId");

                    b.HasOne("VipcoPlanning.Models.Planning.FabricationManHour", "FabricationManHour")
                        .WithMany()
                        .HasForeignKey("FabricationManHourId");

                    b.HasOne("VipcoPlanning.Models.Planning.PackingManHour", "PackingManHour")
                        .WithMany()
                        .HasForeignKey("PackingManHourId");

                    b.HasOne("VipcoPlanning.Models.Planning.PlanMaster", "PlanMaster")
                        .WithMany("PlanDetails")
                        .HasForeignKey("PlanMasterId");

                    b.HasOne("VipcoPlanning.Models.Planning.WeldManHour", "WeldManHour")
                        .WithMany()
                        .HasForeignKey("WeldManHourId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.PlanShipment", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.PlanMaster", "PlanMaster")
                        .WithMany("PlanShipments")
                        .HasForeignKey("PlanMasterId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.RateManHour", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.StandardTimeForWorkGroup", "StandardTimeForWorkGroup")
                        .WithMany("RateManHours")
                        .HasForeignKey("StandardTimeForId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.StandardTime", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.GroupStandardTime", "GroupStandardTime")
                        .WithMany()
                        .HasForeignKey("GroupStandardId");

                    b.HasOne("VipcoPlanning.Models.Planning.StandardTimeForWorkGroup", "StandardTimeForWorkGroup")
                        .WithMany("StandardTimes")
                        .HasForeignKey("StandardTimeForId");
                });

            modelBuilder.Entity("VipcoPlanning.Models.Planning.WeldManHour", b =>
                {
                    b.HasOne("VipcoPlanning.Models.Planning.StandardTime", "Weld")
                        .WithMany()
                        .HasForeignKey("WeldId");
                });
#pragma warning restore 612, 618
        }
    }
}
