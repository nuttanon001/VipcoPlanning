using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.Datas
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var Context = new PlanningContext(
                serviceProvider.GetRequiredService<DbContextOptions<PlanningContext>>()))
            {
                // Look for any movies.
                if (Context.Database.EnsureCreated())
                {
                    #region ViewVIPCO
                    // VIPCO Total Manhour with WorkGroup
                    Context.Database.ExecuteSqlCommand(
                        @"CREATE VIEW View_WorkGroup_TotalMh AS 
                            SELECT  EmpJob.JobNo, 
                                    EmpJob.GroupCode, 
                                    SUM(ISNULL(EmpTime.NT, 0)) AS TotalWorkTime, 
                                    SUM(ISNULL(EmpTime.NTOT, 0)) AS TotalWorkTimeOverTime, 
                                    SUM(ISNULL(EmpTime.OT, 0)) AS TotalOverTime
                            FROM    VIPCOTH.ShareData.dbo.V_Emp_Jobs AS EmpJob INNER JOIN 
                                    VIPCOTH.ShareData.dbo.V_tblEmployee AS Emp ON EmpJob.EmpCode = Emp.EmpCode INNER JOIN 
                                    VIPCOTH.ShareData.dbo.V_EmpTime AS EmpTime ON Emp.EmpCard = EmpTime.EmpCard AND EmpJob.WorkDate = EmpTime.WorkDate
                            GROUP BY EmpJob.GroupCode, EmpJob.JobNo");
                    // VIPCO Total Manhour with Bom
                    Context.Database.ExecuteSqlCommand(
                        @"CREATE VIEW View_Bom_TotalMh AS 
                            SELECT  EmpJob.JobNo, EmpJob.GroupCode, EmpJob.ItemCode, 
                                    SUM(ISNULL(EmpTime.NT, 0)) AS TotalWorkTime, 
                                    SUM(ISNULL(EmpTime.NTOT, 0)) AS TotalWorkTimeOverTime, 
                                    SUM(ISNULL(EmpTime.OT, 0)) AS TotalOverTime
                            FROM    VIPCOTH.ShareData.dbo.V_Emp_Jobs AS EmpJob INNER JOIN
                                    VIPCOTH.ShareData.dbo.V_tblEmployee AS Emp ON EmpJob.EmpCode = Emp.EmpCode INNER JOIN
                                    VIPCOTH.ShareData.dbo.V_EmpTime AS EmpTime ON Emp.EmpCard = EmpTime.EmpCard AND EmpJob.WorkDate = EmpTime.WorkDate
                            GROUP BY EmpJob.ItemCode, EmpJob.JobNo");

                    // SUB Total Manhour with WorkGroup
                    Context.Database.ExecuteSqlCommand(
                        @"CREATE VIEW View_WorkGroupSub_TotalMh AS 
                            SELECT  EmpJob.JobNo, 
                                    EmpJob.GroupMIS,
                                    (
                                        SELECT TOP (1) GroupDesc
                                        FROM      VIPCOTH.ShareData.dbo.V_tblGroupNameMIS AS GroupMis
                                        WHERE   (GroupMIS = EmpJob.GroupMIS)
                                    ) AS GroupName, 
                                    SUM(ISNULL(EmpTime.NT, 0)) AS TotalWorkTime, 
                                    SUM(ISNULL(EmpTime.NTOT, 0)) AS TotalWorkTimeOverTime, 
                                    SUM(ISNULL(EmpTime.OT, 0)) AS TotalOverTime
                            FROM    VIPCOTH.ShareData.dbo.V_Emp_Jobs_Sub AS EmpJob INNER JOIN
                                    VIPCOTH.ShareData.dbo.V_EmpTime_Sub AS EmpTime ON EmpJob.EmpCode = EmpTime.EmpCard AND EmpJob.WorkDate = EmpTime.WorkDate
                            GROUP BY EmpJob.GroupMIS, EmpJob.JobNo");
                    // SUB Total Manhour with Bom
                    Context.Database.ExecuteSqlCommand(
                        @"CREATE VIEW View_BomSub_TotalMh AS 
                            SELECT  EmpJob.JobNo, 
                                    EmpJob.ItemCode, 
                                    EmpJob.GroupMIS,
                                    SUM(ISNULL(EmpTime.NT, 0)) AS TotalWorkTime, 
                                    SUM(ISNULL(EmpTime.NTOT, 0)) AS TotalWorkTimeOverTime, 
                                    SUM(ISNULL(EmpTime.OT, 0)) AS TotalOverTime
                            FROM    VIPCOTH.ShareData.dbo.V_Emp_Jobs_Sub AS EmpJob INNER JOIN
                                    VIPCOTH.ShareData.dbo.V_EmpTime_Sub AS EmpTime ON EmpJob.EmpCode = EmpTime.EmpCard AND EmpJob.WorkDate = EmpTime.WorkDate
                            GROUP BY EmpJob.ItemCode, EmpJob.JobNo");
                    #endregion
                }

            }
        }
    }
}
