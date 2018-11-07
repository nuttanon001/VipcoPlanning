using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VipcoPlanning.ViewModels;

namespace VipcoPlanning.Models.Planning
{
    public class PlanningContext : DbContext
    {
        public PlanningContext(DbContextOptions<PlanningContext> option) : base(option)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillofMaterial>().ToTable("BillofMaterial")
                        .HasIndex(b => b.Code).IsUnique();
            modelBuilder.Entity<StandardTime>().ToTable("StandardTime")
                        .HasIndex(s => s.Code).IsUnique();
            modelBuilder.Entity<StandardTimeForWorkGroup>().ToTable("StandardTimeForWorkGroup")
                        .HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<WorkGroupHasNickName>().ToTable("WorkGroupHasNickName")
                .HasIndex(b => b.NickName).IsUnique();
            modelBuilder.Entity<WorkGroupHasNickName>()
                .HasData(
                    new { WorkGroupNickNameId = 1, GroupCode = "CFA01",NickName = "S Chumsaeng",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 2, GroupCode = "CFA02",NickName = "S Malee",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 3, GroupCode = "CFA03",NickName = "S Kitti",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 4, GroupCode = "CFA04",NickName = "S Kritsada",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 5, GroupCode = "CFA05",NickName = "S Montree",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 6, GroupCode = "CFA06",NickName = "S Boonma",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 7, GroupCode = "CFA07",NickName = "S Sumruoy",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 8, GroupCode = "CFA08",NickName = "S Surat",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 9, GroupCode = "CFA09",NickName = "S Yai",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 10, GroupCode = "DFA02",NickName = "Wichit",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 11, GroupCode = "DFA05",NickName = "Narintron",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 12, GroupCode = "DFA06",NickName = "San",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 13, GroupCode = "DFA07",NickName = "Suwan",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 14, GroupCode = "DFA08",NickName = "Phairat",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 15, GroupCode = "DFA09",NickName = "Kittipong",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 16, GroupCode = "DFA10",NickName = "Boonlert",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 17, GroupCode = "DFA12",NickName = "Thongdee",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 18, GroupCode = "DFA13",NickName = "Sompian",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 19, GroupCode = "DFA14",NickName = "Boonyuen",CreateDate = DateTime.Now,Creator = "SeedData" },
                    new { WorkGroupNickNameId = 20, GroupCode = "DFA18",NickName = "Sil",CreateDate = DateTime.Now,Creator = "SeedData" }
                 );
            //View
            modelBuilder.Query<WorkGroupTotalManHourView>().ToView("View_WorkGroup_TotalMh");
            modelBuilder.Query<WorkGroupTotalManHourSubView>().ToView("View_WorkGroupSub_TotalMh");
            modelBuilder.Query<BomTotalManHourView>().ToView("View_Bom_TotalMh");
            modelBuilder.Query<BomTotalManHourSubView>().ToView("View_BomSub_TotalMh");
        }
        //DbSet
        public DbSet<ActualBom> ActualBoms { get; set; }
        public DbSet<ActualDetail> ActualDetails { get; set; }
        public DbSet<ActualMaster> ActualMasters { get; set; }
        public DbSet<BillofMaterial> BillofMaterials { get; set; }
        public DbSet<EngineerManHour> EngineerManHours { get; set; }
        public DbSet<FabricationManHour> FabricationManHours { get; set; }
        public DbSet<GroupStandardTime> GroupStandardTimes { get; set; }
        public DbSet<HistoryPlanMaster> HistoryPlanMasters { get; set; }
        public DbSet<PackingManHour> PackingManHours { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PlanDetail> PlanDetails { get; set; }
        public DbSet<PlanMaster> PlanMasters { get; set; }
        public DbSet<PlanShipment> PlanShipments { get; set; }
        public DbSet<RateManHour> RateManHours { get; set; }
        public DbSet<StandardTime> StandardTimes { get; set; }
        public DbSet<StandardTimeForWorkGroup> StandardTimeForWorkGroups { get; set; }
        public DbSet<WeldManHour> WeldManHours { get; set; }
        public DbSet<WorkGroupHasNickName> WorkGroupHasNickNames { get; set; }
        // View
        public DbQuery<WorkGroupTotalManHourView> WorkGroupTotalManHours { get; set; }
        public DbQuery<WorkGroupTotalManHourSubView> WorkGroupTotalManHourSubs { get; set; }
        public DbQuery<BomTotalManHourView> BomTotalManHourViews { get; set; }
        public DbQuery<BomTotalManHourSubView> BomTotalManHourSubViews { get; set; }
    }
}