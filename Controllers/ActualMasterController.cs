using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VipcoPlanning.Helper;
using VipcoPlanning.Models.Machines;
using VipcoPlanning.Models.Planning;
using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualMasterController : GenericPlanningController<ActualMaster>
    {
        // Planning
        private readonly IRepositoryPlanning<ActualDetail> repositoryActualDetail;
        private readonly IRepositoryPlanning<ActualBom> repositoryActualBom;
        private readonly IRepositoryPlanning<PlanMaster> repositoryPlanMaster;
        private readonly IRepositoryPlanning<PlanDetail> repositoryPlanDetail;
        private readonly IRepositoryPlanning<WorkGroupHasNickName> repositoryNickName;
        private readonly IRepositoryPlanning<BillofMaterial> repositoryBom;
        // Machine
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryWorkGroup;
        private readonly IRepositoryMachine<WorkGroupHasWorkShop> repositoryWorkShop;
        private readonly IRepositoryMachine<ProjectCodeMaster> repositoryProject;

        // Context
        private readonly PlanningContext context;
        // GET: api/ActualMaster
        public ActualMasterController(IRepositoryPlanning<ActualMaster> repo,
            IRepositoryPlanning<ActualDetail> repoActualDetail,
            IRepositoryPlanning<ActualBom> repoActualBom,
            IRepositoryPlanning<PlanDetail> repoPlanDetail,
            IRepositoryPlanning<PlanMaster> repoPlanMaster,
            IRepositoryPlanning<WorkGroupHasNickName> repoNickName,
            IRepositoryPlanning<BillofMaterial> repoBom,
            IRepositoryMachine<EmployeeGroupMis> repoWorkGroup,
            IRepositoryMachine<WorkGroupHasWorkShop> repoWorkShop,
            IRepositoryMachine<ProjectCodeMaster> repoProject,
            PlanningContext context,
            IMapper mapper) : base(repo, mapper)
        {
            // IRepositoryPlanning
            this.repositoryActualDetail = repoActualDetail;
            this.repositoryActualBom = repoActualBom;
            this.repositoryPlanMaster = repoPlanMaster;
            this.repositoryPlanDetail = repoPlanDetail;
            this.repositoryNickName = repoNickName;
            this.repositoryBom = repoBom;
            // IRepositoryMachine
            this.repositoryWorkGroup = repoWorkGroup;
            this.repositoryWorkShop = repoWorkShop;
            this.repositoryProject = repoProject;
            // Planning Context
            this.context = context;
        }

        // POST: api/ActualMaster/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            Expression<Func<ActualMaster, bool>> predicate = e => e.ValidTo == null;

            foreach (string temp in filters)
            {
                string keyword = temp.Trim().ToLower();
                predicate = predicate.And(x => x.ProjectName.ToLower().Contains(keyword));
            }
            //if (!string.IsNullOrEmpty(Scroll.Where))
            //    predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<ActualMaster>, IOrderedQueryable<ActualMaster>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ProjectName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ProjectName);
                    else
                        order = o => o.OrderBy(x => x.ProjectName);
                    break;

                case "ValidTo":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ValidTo);
                    else
                        order = o => o.OrderBy(x => x.ValidTo);
                    break;

                case "ValidFrom":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ValidFrom);
                    else
                        order = o => o.OrderBy(x => x.ValidFrom);
                    break;

                default:
                    order = o => o.OrderByDescending(x => x.CreateDate);
                    break;
            }

            var QueryData = await this.repository.GetToListAsync(
                                    selector: selected => selected,  // Selected
                                    predicate: predicate, // Where
                                    orderBy: order, // Order
                                    include: null, // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take

            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);

            //var mapDatas = new List<BillofMaterialViewModel>();
            //foreach (var item in QueryData)
            //{
            //    var MapItem = this.mapper.Map<BillofMaterial, BillofMaterialViewModel>(item);
            //    mapDatas.Add(MapItem);
            //}
            return new JsonResult(new ScrollDataViewModel<ActualMaster>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }

        // POST: api/ActualMaster/
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] ActualMaster record)
        {
            // Set date for CrateDate Entity
            if (record == null)
                return BadRequest();
            // +7 Hour
            record = this.helper.AddHourMethod(record);

            if (record.GetType().GetProperty("CreateDate") != null)
                record.GetType().GetProperty("CreateDate").SetValue(record, DateTime.Now);
            // Set ValidFrom
            record.ValidFrom = DateTime.Now;

            // Check last record
            var lastRecords = await this.repository.GetToListAsync(
                x => x, 
                x => x.ProjectCodeMasterId == record.ProjectCodeMasterId && x.ValidTo == null);

            if (lastRecords != null && lastRecords.Any())
            {
                foreach (var lastRecord in lastRecords)
                {
                    lastRecord.ValidTo = DateTime.Now;
                    lastRecord.ModifyDate = DateTime.Now;
                    lastRecord.Modifyer = record.Creator;

                    // Update lastrecord Async
                    await this.repository.UpdateAsync(lastRecord, lastRecord.ActualMasterId);
                }
            }

            var WorkGroups = await this.repositoryWorkGroup.GetToListAsync(x => x);
            var WorkNicks = await this.repositoryNickName.GetToListAsync(x => x);

            if (record.ActualDetails != null && record.ActualDetails.Any())
            {
                foreach (var item in record.ActualDetails)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;

                    if (!string.IsNullOrEmpty(item.GroupCode))
                    {
                        var hasPlanDetail = await this.repositoryPlanDetail.GetToListAsync(
                            x => x, 
                            x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == item.GroupCode,
                            null, 
                            x => x.Include(z => z.FabricationManHour));

                        if (hasPlanDetail != null && hasPlanDetail.Any())
                        {
                            item.WeightPlan = hasPlanDetail.Sum(z => z.ContentWeigth) ?? 0;
                            item.TotalPlanManHour = hasPlanDetail.Sum(x => (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                                           (x?.FabricationManHour?.PerAssemblyMH ?? 0));
                        }
                    }
                }
            }

            if (record.ActualBoms != null && record.ActualBoms.Any())
            {
                foreach (var item in record.ActualBoms)
                {
                    item.CreateDate = DateTime.Now;
                    item.Creator = record.Creator;

                    if (!string.IsNullOrEmpty(item.GroupCode))
                    {
                        var hasPlanDetail = await this.repositoryPlanDetail.GetToListAsync(
                              x => x, 
                              x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == item.GroupCode,
                              null, 
                              x => x.Include(z => z.FabricationManHour));

                        if (hasPlanDetail != null && hasPlanDetail.Any())
                        {
                            item.WeightPlan = hasPlanDetail.Sum(z => z.ContentWeigth) ?? 0;
                            item.TotalPlanManHour = hasPlanDetail.Sum(x => (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                                           (x?.FabricationManHour?.PerAssemblyMH ?? 0));
                        }
                    }
                }
            }

            if (await this.repository.AddAsync(record) == null)
                return BadRequest();
            return new JsonResult(record, this.DefaultJsonSettings);
        }

        // PUT: api/ActualMaster/
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] ActualMaster record)
        {
            if (key < 1)
                return BadRequest();
            if (record == null)
                return BadRequest();

            // +7 Hour
            record = this.helper.AddHourMethod(record);

            // Set date for CrateDate Entity
            if (record.GetType().GetProperty("ModifyDate") != null)
                record.GetType().GetProperty("ModifyDate").SetValue(record, DateTime.Now);

            if (record.ActualDetails != null && record.ActualDetails.Any())
            {
                foreach (var item in record.ActualDetails)
                {
                    if (item.ActualDetailId > 0)
                    {
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = record.Creator;
                    }
                    else
                    {
                        item.CreateDate = DateTime.Now;
                        item.Creator = record.Creator;
                    }
                }
            }

            if (record.ActualBoms != null && record.ActualBoms.Any())
            {
                foreach (var itemBom in record.ActualBoms)
                {
                    if (itemBom.ActualBomId > 0)
                    {
                        itemBom.ModifyDate = DateTime.Now;
                        itemBom.Modifyer = record.Creator;
                    }
                    else
                    {
                        itemBom.CreateDate = DateTime.Now;
                        itemBom.Creator = record.Creator;
                    }
                }
            }

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();

            if (record != null)
            {
                #region ActualDetail

                // filter
                var dbActualDetails = await this.repositoryActualDetail.GetToListAsync(x => x, x => x.ActualMasterId == key);

                //Remove ActualDetails if edit remove it
                foreach (var dbActualDetail in dbActualDetails)
                {
                    if (!record.ActualDetails.Any(x => x.ActualDetailId == dbActualDetail.ActualDetailId))
                        await this.repositoryActualDetail.DeleteAsync(dbActualDetail.ActualDetailId);
                }

                //Update ActualDetails or New ActualDetails
                foreach (var uActualDetail in record.ActualDetails)
                {
                    if (!string.IsNullOrEmpty(uActualDetail.GroupCode))
                    {
                        var hasPlanDetail = await this.repositoryPlanDetail.GetToListAsync(
                            x => x, x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == uActualDetail.GroupCode,
                            null, x => x.Include(z => z.FabricationManHour));

                        if (hasPlanDetail != null && hasPlanDetail.Any())
                        {
                            uActualDetail.WeightPlan = hasPlanDetail.Sum(z => z.ContentWeigth) ?? (double)0;
                            uActualDetail.TotalPlanManHour = hasPlanDetail.Sum(x => (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                                                    (x?.FabricationManHour?.PerAssemblyMH ?? 0));
                        }
                    }

                    if (uActualDetail.ActualDetailId > 0)
                        await this.repositoryActualDetail.UpdateAsync(uActualDetail, uActualDetail.ActualDetailId);
                    else
                    {
                        uActualDetail.ActualMasterId = record.ActualMasterId;
                        await this.repositoryActualDetail.AddAsync(uActualDetail);
                    }
                }

                #endregion ActualDetail

                #region ActualBom

                // filter
                var dbActualBoms = await this.repositoryActualBom.GetToListAsync(x => x, x => x.ActualMasterId == key);

                //Remove ActualBoms if edit remove it
                foreach (var dbActualBom in dbActualBoms)
                {
                    if (!record.ActualBoms.Any(x => x.ActualBomId == dbActualBom.ActualBomId))
                        await this.repositoryActualBom.DeleteAsync(dbActualBom.ActualBomId);
                }

                //Update ActualBoms or New ActualBoms
                foreach (var uActualBom in record.ActualBoms)
                {
                    if (!string.IsNullOrEmpty(uActualBom.GroupCode))
                    {
                        var hasPlanDetail = await this.repositoryPlanDetail.GetToListAsync(
                            x => x, x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == uActualBom.GroupCode,
                            null, x => x.Include(z => z.FabricationManHour));

                        if (hasPlanDetail != null && hasPlanDetail.Any())
                        {
                            uActualBom.WeightPlan = hasPlanDetail.Sum(z => z.ContentWeigth) ?? 0;
                            uActualBom.TotalPlanManHour = hasPlanDetail.Sum(x => (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                                                    (x?.FabricationManHour?.PerAssemblyMH ?? 0));
                        }
                    }

                    if (uActualBom.ActualBomId > 0)
                        await this.repositoryActualBom.UpdateAsync(uActualBom, uActualBom.ActualBomId);
                    else
                    {
                        uActualBom.ActualMasterId = record.ActualMasterId;
                        await this.repositoryActualBom.AddAsync(uActualBom);
                    }
                }

                #endregion ActualBom
            }

            return new JsonResult(record, this.DefaultJsonSettings);
        }

        // POST: api/ActualMaster/ChartManHours
        [HttpPost("ChartManHour")]
        public async Task<IActionResult> ChartManHour([FromBody] OptionChartViewModel Confition)
        {
            var Message = "";
            try
            {
                if (Confition != null && Confition.PlanMasterId.HasValue)
                {
                    var HasData = await this.repository.GetFirstOrDefaultAsync(
                        x => x,
                        x => x.PlanMasterId == Confition.PlanMasterId && x.ValidTo == null,
                        null, x => x.Include(z => z.ActualDetails));

                    // Labels
                    var Labels = new List<LabelChartViewMode>();
                    // Chart-Datas
                    var ChartData1s = new List<ChartDataViewModel>();
                    var ChartData2s = new List<ChartDataViewModel>();
                    // Table-Datas
                    var ActualFabTables = new List<ActualFabTable>();
                    // Information
                    var ProjectName = "";
                    DateTime ReportDate = DateTime.Today;

                    if (HasData != null)
                    {
                        #region ChartData
                        // Label for actual
                        Labels = HasData.ActualDetails
                            .OrderBy(x => x.NickName).ThenBy(x => x.GroupCode)
                            .Where(x => x.ActualType == ActualType.FABRICATE
                                        &&
                                       (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                            .Select(x => new LabelChartViewMode
                            {
                                Code = x.GroupCode,
                                Label = x.NickName,
                            }).ToList();

                        // Data Plans
                        var DataPlanFromActual = HasData.ActualDetails
                            .Where(x => x.ActualType == ActualType.FABRICATE
                                       &&
                                       (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                            .OrderBy(x => x.NickName).ThenBy(x => x.GroupCode)
                            .Select(x => x.TotalPlanManHour ?? 0).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Plan MH",
                            ChartData = DataPlanFromActual
                        });

                        // Data Actuals
                        var DataActual = HasData.ActualDetails
                           .Where(x => x.ActualType == ActualType.FABRICATE
                                      &&
                                      (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                           .OrderBy(x => x.NickName).ThenBy(x => x.GroupCode)
                           .Select(x => (x.TotalManHour ?? 0) + (x.TotalManHourOT ?? 0)).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Actual MH",
                            ChartData = DataActual
                        });

                        // Data Progress MH
                        var DataProgress = HasData.ActualDetails
                           .Where(x => x.ActualType == ActualType.FABRICATE
                                      &&
                                      (x.TotalPlanManHour > 0 || x.TotalManHour > 0 || x.TotalManHourOT > 0))
                           .OrderBy(x => x.NickName).ThenBy(x => x.GroupCode)
                           .Select(x => (
                              x.TotalManHour.HasValue && x.TotalManHour > 0 &&
                              x.TotalManHourOT.HasValue && x.TotalManHourOT > 0 &&
                              x.TotalPlanManHour.HasValue && x.TotalPlanManHour > 0 ?
                            (((x.TotalManHour ?? 0) + (x.TotalManHourOT ?? 0)) / (x.TotalPlanManHour ?? 0)) * 100 : 0)).ToList();
                        ChartData2s.Add(new ChartDataViewModel()
                        {
                            Label = "Progress MH",
                            ChartData = DataProgress
                        });

                        #endregion ChartData

                        #region TableData

                        foreach (var item in HasData.ActualDetails
                            .Where(x => x.ActualType == ActualType.FABRICATE &&
                                       (x.TotalPlanManHour > 0 || x.TotalManHour > 0 || x.TotalManHourOT > 0))
                            .OrderBy(z => z.WorkShop))
                        {
                            var mapData = new ActualFabTable
                            {
                                WorkShopName = item.WorkShop,
                                WorkGroup = item.NickName,
                                Weight = item.WeightPlan,
                                PlanMH = item.TotalPlanManHour,
                                ActualMH = (item.TotalManHour ?? 0) + (item.TotalManHourOT ?? 0),
                                ActualMHxOT = (item.TotalManHour ?? 0) + (item.TotalManHourNTOT ?? 0),
                                OverTimemultiply = HasData.OverTimemultiply ?? 1
                            };

                            ActualFabTables.Add(mapData);
                        }


                        #endregion TableData
                        // SET VALUE
                        ProjectName = HasData.ProjectName;
                        ReportDate = HasData.ModifyDate ?? HasData.CreateDate.Value;
                    }

                    var planData = await this.repositoryPlanMaster.
                        GetFirstOrDefaultAsync(
                            x => x, 
                            x => x.PlanMasterId == Confition.PlanMasterId);

                    if (planData != null)
                    {
                        #region PlanData

                        var planDetail = await this.context.PlanDetails
                                                   .Join(this.context.FabricationManHours,
                                                        x => x.FabricationManHourId,
                                                        fab => fab.FabricationManHourId,
                                                        (pd1,fab) => new { pd1, fab })
                                                   .DefaultIfEmpty()
                                                   .Join(this.context.WorkGroupHasNickNames,
                                                       pd => pd.pd1.AssignmentToGroup,
                                                       wn => wn.GroupCode,
                                                       (pd, wn) => new { pd, wn })
                                                   .DefaultIfEmpty()
                                                   .Where(x => x.pd.pd1.PlanMasterId == planData.PlanMasterId &&
                                                               !Labels.Select(z => z.Code).Contains(x.pd.pd1.AssignmentToGroup) &&
                                                               x.wn.ActualType == ActualType.FABRICATE)
                                                   .GroupBy(x => new { x.pd.pd1.AssignmentToGroup, x.wn.NickName })
                                                   .OrderBy(x => x.Key.NickName).ThenBy(x => x.Key.AssignmentToGroup)
                                                   .AsNoTracking()
                                                   .ToListAsync();

                        // Labels for plans
                        Labels.AddRange(planDetail.Select(x => new LabelChartViewMode
                        {
                            Code = x.Key.AssignmentToGroup,
                            Label = x.Key.NickName,
                        }).ToList());
                        // Data Plans
                        var DataPlanFromPlan = planDetail.Select(x => new
                        {
                            Plan = x.Sum(z => (z?.pd?.fab?.FabricationMH ?? 0) +
                                              (z?.pd?.fab?.PerAssemblyMH ?? 0)),
                            Actual = (double)0
                        }).ToList();

                        var PlanMh = ChartData1s.FirstOrDefault(x => x.Label == "Plan MH");
                        if (PlanMh != null)
                            PlanMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Plan));
                        else
                            ChartData1s.Add(new ChartDataViewModel()
                            {
                                Label = "Plan MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Plan).ToList()
                            });

                        var ActualMh = ChartData1s.FirstOrDefault(x => x.Label == "Actual MH");
                        if (ActualMh != null)
                            ActualMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Actual));
                        else
                            ChartData1s.Add(new ChartDataViewModel()
                            {
                                Label = "Actual MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Actual).ToList()
                            });

                        var ProgressMh = ChartData2s.FirstOrDefault(x => x.Label == "Progress MH");
                        if (ProgressMh != null)
                            ProgressMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Actual));
                        else
                            ChartData2s.Add(new ChartDataViewModel()
                            {
                                Label = "Progress MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Actual).ToList()
                            });

                        #endregion

                        #region TableData

                        foreach (var item in planDetail)
                        {
                            var WorkShop = await this.repositoryWorkShop.GetFirstOrDefaultAsync(
                                            x => x.WorkShop.WorkShopName, 
                                            x => x.GroupMis == item.Key.AssignmentToGroup, 
                                            null, 
                                            x => x.Include(z => z.WorkShop));

                            var mapData = new ActualFabTable
                            {
                                WorkShopName = string.IsNullOrEmpty(WorkShop) ? "-" : WorkShop,
                                WorkGroup = item.Key.NickName,
                                Weight = item.Sum(z => z.pd.pd1.ContentWeigth ?? 0),
                                PlanMH = item.Sum(z => (z?.pd?.fab?.FabricationMH ?? 0) +
                                                       (z?.pd?.fab?.PerAssemblyMH ?? 0)),
                                ActualMH = 0,
                                ActualMHxOT = 0,
                                OverTimemultiply = HasData != null ? HasData.OverTimemultiply ?? 1 : 1
                            };

                            ActualFabTables.Add(mapData);
                        }


                        #endregion TableData

                        ProjectName = string.IsNullOrEmpty(ProjectName) ? planData.ProjectName : ProjectName;
                        ReportDate = HasData == null ? planData.ModifyDate ?? HasData.CreateDate.Value : ReportDate;
                    }

                    return new JsonResult(new
                    {
                        ProjectName,
                        ReportDate,
                        Status = planData != null && planData?.PlanningStatus == null ? 
                            "-" : System.Enum.GetName(typeof(PlanningStatus), planData.PlanningStatus),
                        Labels = Labels.Select(x => x.Label),
                        ChartData1s,
                        ChartData2s,
                        ActualFabTables,
                    }, this.DefaultJsonSettings);
                }
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }

        // POST: api/ActualMaster/ChartBomManHour
        [HttpPost("ChartBomManHour")]
        public async Task<IActionResult> ChartBomManHour([FromBody] OptionChartViewModel Confition)
        {
            var Message = "";
            try
            {
                if (Confition != null && Confition.PlanMasterId.HasValue)
                {
                    var HasData = await this.repository.GetFirstOrDefaultAsync(
                        x => x,
                        x => x.PlanMasterId == Confition.PlanMasterId && x.ValidTo == null,
                        null, x => x.Include(z => z.ActualBoms));

                    // Labels
                    var Labels = new List<LabelChartViewMode>();
                    // Datas
                    var ChartData1s = new List<ChartDataViewModel>();
                    var ChartData2s = new List<ChartDataViewModel>();
                    // Table-Datas
                    var ActualFabTables = new List<ActualFabTable>();
                    // Information
                    var ProjectName = HasData.ProjectName;
                    DateTime ReportDate = DateTime.Today;

                    #region Actual

                    if (HasData != null)
                    {
                        #region ChartData

                        Labels = HasData.ActualBoms
                             .Where(x => x.ActualType == ActualType.FABRICATE && !string.IsNullOrEmpty(x.BomCode.Trim()) &&
                                   (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                            .GroupBy(x => new { x.BomCode, x.BomName })
                            .OrderBy(x => x.Key.BomCode)
                            .Select(x => new LabelChartViewMode
                            {
                                Code = x.Key.BomCode,
                                Label = x.Key.BomName ?? "-",
                            }).ToList();

                        // Data Plans
                        var DataPlans = HasData.ActualBoms
                            .Where(x => x.ActualType == ActualType.FABRICATE && !string.IsNullOrEmpty(x.BomCode.Trim()) &&
                                       (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                            .GroupBy(x => new { x.BomCode, x.BomName })
                            .OrderBy(x => x.Key.BomName)
                            .Select(x => x.Sum(z => z.TotalPlanManHour ?? 0)).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Plan MH",
                            ChartData = DataPlans
                        });

                        // Data Actuals
                        var DataActual = HasData.ActualBoms
                           .Where(x => x.ActualType == ActualType.FABRICATE && !string.IsNullOrEmpty(x.BomCode.Trim()) &&
                                      (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                           .GroupBy(x => new { x.BomCode, x.BomName })
                           .OrderBy(x => x.Key.BomName)
                           .Select(x => x.Sum(z => (z.TotalManHour ?? 0) + (z.TotalManHourOT ?? 0))).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Actual MH",
                            ChartData = DataActual
                        });

                        // Data Progress MH
                        var DataProgress = HasData.ActualBoms
                           .Where(x => x.ActualType == ActualType.FABRICATE && !string.IsNullOrEmpty(x.BomCode.Trim()) &&
                                      (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                           .OrderBy(x => x.BomName)
                           .GroupBy(x => new { x.BomCode, x.BomName })
                            .Select(x => new
                            {
                                mh = x.Sum(z =>
                                (z.TotalManHour.HasValue && z.TotalManHour > 0 &&
                                z.TotalManHourOT.HasValue && z.TotalManHourOT > 0 ?
                                (z.TotalManHour ?? 0) + (z.TotalManHourOT ?? 0) : 0)),
                                pl = x.Sum(z =>
                                (z.TotalPlanManHour.HasValue && z.TotalPlanManHour > 0 ?
                                z.TotalPlanManHour ?? 0 : 0)),
                            }).ToList();
                        ChartData2s.Add(new ChartDataViewModel()
                        {
                            Label = "Progress MH",
                            ChartData = DataProgress.Select(z => z.mh > 0 && z.pl > 0 ? (z.mh / z.pl) * 100 : 0).ToList()
                        });

                        #endregion ChartData

                        #region TableData

                        foreach (var item in HasData.ActualBoms
                            .Where(x => x.ActualType == ActualType.FABRICATE && !string.IsNullOrEmpty(x.BomCode.Trim()) &&
                                       (x.TotalPlanManHour > 0 || x.TotalManHourOT > 0 || x.TotalManHour > 0))
                            .OrderBy(z => z.BomName).GroupBy(x => new { x.BomCode, x.BomName }))
                        {
                            ActualFabTables.Add(new ActualFabTable
                            {
                                WorkShopName = item.Key.BomCode,
                                WorkGroup = item.Key.BomName,
                                Weight = item.Sum(z => z.WeightPlan ?? 0),
                                PlanMH = item.Sum(z => z.TotalPlanManHour ?? 0),
                                ActualMH = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourOT ?? 0)),
                                ActualMHxOT = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourNTOT ?? 0)),
                                OverTimemultiply = HasData.OverTimemultiply ?? 1
                            });
                        }

                        #endregion TableData
                    }

                    #endregion

                    var planMaster = await this.repositoryPlanMaster.
                         GetFirstOrDefaultAsync(x => x, x => x.PlanMasterId == Confition.PlanMasterId);

                    if (planMaster != null)
                    {
                        #region PlanData

                        var planDetail = await this.context.PlanDetails
                                                        .Join(this.context.BillofMaterials,
                                                        pd => pd.BillofMaterialId,
                                                        bom => bom.BillofMaterialId,
                                                        (pd, bom) => new
                                                        {
                                                            pd.PlanDetailId,
                                                            pd.PlanMasterId,
                                                            pd.AssignmentToGroup,
                                                            pd.ContentWeigth,
                                                            pd.BillofMaterialId,
                                                            pd.FabricationManHourId,
                                                            bom.Code,
                                                            bom.Name
                                                        })
                                                   //.DefaultIfEmpty()
                                                   .Join(this.context.FabricationManHours,
                                                        pd => pd.FabricationManHourId,
                                                        fab => fab.FabricationManHourId,
                                                        (pd, fab) => new {
                                                            pd.PlanDetailId,
                                                            pd.PlanMasterId,
                                                            pd.AssignmentToGroup,
                                                            pd.ContentWeigth,
                                                            pd.BillofMaterialId,
                                                            pd.FabricationManHourId,
                                                            pd.Code,
                                                            pd.Name,
                                                            fab.FabricationMH,
                                                            fab.PerAssemblyMH
                                                        })
                                                   //.DefaultIfEmpty()
                                                   .Join(this.context.WorkGroupHasNickNames,
                                                       pd => pd.AssignmentToGroup,
                                                       wn => wn.GroupCode,
                                                       (pd, wn) => new
                                                       {
                                                           pd.PlanDetailId,
                                                           pd.PlanMasterId,
                                                           pd.AssignmentToGroup,
                                                           pd.ContentWeigth,
                                                           pd.BillofMaterialId,
                                                           pd.FabricationManHourId,
                                                           pd.Code,
                                                           pd.Name,
                                                           pd.FabricationMH,
                                                           pd.PerAssemblyMH,
                                                           wn.ActualType,
                                                           wn.NickName,
                                                       })
                                                   .DefaultIfEmpty()
                                                   .Where(x => x.PlanMasterId == planMaster.PlanMasterId &&
                                                               !Labels.Select(z => z.Code).Contains(x.Code) &&
                                                                x.ActualType == ActualType.FABRICATE)
                                                   .GroupBy(x => new { x.Code, x.Name })
                                                   .OrderBy(x => x.Key.Name)
                                                   .AsNoTracking()
                                                   .ToListAsync();

                        // Labels for plans
                        Labels.AddRange(planDetail.Select(x => new LabelChartViewMode
                        {
                            Code = x.Key.Code,
                            Label = x.Key.Name,
                        }).ToList());
                        // Data Plans
                        var DataPlanFromPlan = planDetail.Select(x => new
                        {
                            Plan = x.Sum(z => (z?.FabricationMH ?? 0) +
                                              (z?.PerAssemblyMH ?? 0)),
                            Actual = (double)0
                        }).ToList();

                        var PlanMh = ChartData1s.FirstOrDefault(x => x.Label == "Plan MH");
                        if (PlanMh != null)
                            PlanMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Plan));
                        else
                            ChartData1s.Add(new ChartDataViewModel()
                            {
                                Label = "Plan MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Plan).ToList()
                            });

                        var ActualMh = ChartData1s.FirstOrDefault(x => x.Label == "Actual MH");
                        if (ActualMh != null)
                            ActualMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Actual));
                        else
                            ChartData1s.Add(new ChartDataViewModel()
                            {
                                Label = "Actual MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Actual).ToList()
                            });

                        var ProgressMh = ChartData2s.FirstOrDefault(x => x.Label == "Progress MH");
                        if (ProgressMh != null)
                            ProgressMh.ChartData.AddRange(DataPlanFromPlan.Select(z => z.Actual));
                        else
                            ChartData2s.Add(new ChartDataViewModel()
                            {
                                Label = "Progress MH",
                                ChartData = DataPlanFromPlan.Select(z => z.Actual).ToList()
                            });

                        #endregion

                        #region TableData

                        foreach (var item in planDetail)
                        {
                            var mapData = new ActualFabTable
                            {
                                WorkShopName = item.Key.Code,
                                WorkGroup = item.Key.Name,
                                Weight = item.Sum(z => z?.ContentWeigth ?? 0),
                                PlanMH = item.Sum(z => (z?.FabricationMH ?? 0) +
                                                       (z?.PerAssemblyMH ?? 0)),
                                ActualMH = 0,
                                ActualMHxOT = 0,
                                OverTimemultiply = HasData != null ? HasData.OverTimemultiply ?? 1 : 1
                            };

                            ActualFabTables.Add(mapData);
                        }

                        #endregion TableData
                    }

                    ProjectName = string.IsNullOrEmpty(ProjectName) ? planMaster.ProjectName : ProjectName;
                    ReportDate = HasData == null ? planMaster.ModifyDate ?? HasData.CreateDate.Value : ReportDate;

                    return new JsonResult(new
                    {
                        ProjectName,
                        ReportDate = HasData.ModifyDate ?? HasData.CreateDate,
                        Status = planMaster == null ? "-" : System.Enum.GetName(typeof(PlanningStatus), planMaster.PlanningStatus),
                        Labels = Labels.Select(z => z.Label),
                        ChartData1s,
                        ChartData2s,
                        ActualFabTables,
                    }, this.DefaultJsonSettings);
                }
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }

        // POST: api/ActualMaster/TableBomManHour
        [HttpPost("TableBomManHour")]
        public async Task<IActionResult> TableBomManHour([FromBody] OptionChartViewModel option)
        {
            var Message = "Data not been found.";
            try
            {
                if (option != null)
                {
                    if (option.BomId.HasValue)
                    {
                        var hasBom = await this.repositoryBom.GetFirstOrDefaultAsync
                            (x => x,x => x.BillofMaterialId == option.BomId);

                        var ActualFabTables = new List<ActualFabTable>();

                        if (hasBom != null)
                        {
                            #region PlansTable

                            var plans = await this.repositoryPlanMaster.GetToListAsync(
                                                   x => x,
                                                   x => x.HistoryPlanMaster.ValidTo == null,
                                                   null,
                                                   x => x.Include(z => z.HistoryPlanMaster));
                            var planid = plans.Select(z => z.PlanMasterId).ToList();

                            var plans2 = await this.context.PlanDetails
                                                   .Join(this.context.FabricationManHours,
                                                        x => x.FabricationManHourId,
                                                        fab => fab.FabricationManHourId,
                                                        (pd1,fab) => new { pd1, fab})
                                                   .DefaultIfEmpty()
                                                   .Join(this.context.WorkGroupHasNickNames,
                                                       pd => pd.pd1.AssignmentToGroup,
                                                       wn => wn.GroupCode,
                                                       (pd, wn) => new { pd, wn })
                                                   .DefaultIfEmpty()
                                                   .Where(x => planid.Contains(x.pd.pd1.PlanMasterId ?? 0) &&
                                                               x.wn.ActualType == ActualType.FABRICATE)
                                                   .GroupBy(x => new { x.pd.pd1.PlanMasterId })
                                                   .AsNoTracking()
                                                   .ToListAsync();
                           
                            if (plans != null && plans.Any() && plans2 != null && plans2.Any())
                            {
                                foreach (var item in plans2)
                                {
                                    var plan = plans.FirstOrDefault(x => x.PlanMasterId == item.Key.PlanMasterId);
                                    var JobNo = await this.repositoryProject.GetFirstOrDefaultAsync(
                                                    x => x.ProjectCode,
                                                    x => x.ProjectCodeMasterId == plan.ProjectCodeMasterId);

                                    ActualFabTables.Add(new ActualFabTable
                                    {
                                        JobNo = JobNo,
                                        WorkShopName = hasBom.Code,
                                        WorkGroup = hasBom.Name,
                                        Weight = item.Sum(z => z.pd.pd1.ContentWeigth ?? 0),
                                        PlanMH = item.Sum(z => (z?.pd?.fab?.FabricationMH ?? 0) +
                                                               (z?.pd?.fab?.PerAssemblyMH ?? 0)),
                                        ActualMH = 0,
                                        ActualMHxOT = 0,
                                        OverTimemultiply = 1,
                                        Status = System.Enum.GetName(typeof(PlanningStatus), plan.PlanningStatus)
                                    });
                                }
                            }

                            #endregion

                            #region ActualsTable

                            var actuals = await this.repositoryActualBom.GetToListAsync(
                                                    x => x,
                                                    x => x.BomCode.ToLower().Trim().Equals(hasBom.Code.ToLower().Trim()) &&
                                                         x.ActualMaster.ValidTo == null,
                                                    null,
                                                    x => x.Include(z => z.ActualMaster));

                            if (actuals != null && actuals.Any())
                            {
                                foreach (var item in actuals
                                    .Where(x => x.ActualType == ActualType.FABRICATE &&
                                               (x.TotalPlanManHour > 0 || x.TotalManHour > 0 || x.TotalManHourOT > 0))
                                    .GroupBy(x => new { x.BomCode, x.BomName, x.ActualMaster }))
                                {
                                    var JobNo = await this.repositoryProject.GetFirstOrDefaultAsync(
                                                 x => x.ProjectCode,
                                                 x => x.ProjectCodeMasterId == item.Key.ActualMaster.ProjectCodeMasterId);

                                    if (ActualFabTables.Any(z => z.WorkShopName == item.Key.BomCode && z.JobNo == JobNo))
                                    {
                                        var update = ActualFabTables.FirstOrDefault(z => z.WorkShopName == item.Key.BomCode && z.JobNo == JobNo);
                                        update.ActualMH = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourOT ?? 0));
                                        update.ActualMHxOT = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourNTOT ?? 0));
                                        update.OverTimemultiply = item.Key.ActualMaster.OverTimemultiply ?? 1;
                                    }
                                    else
                                    {
                                        var planA = await this.repositoryPlanMaster.GetFirstOrDefaultAsync(x => x, x => x.PlanMasterId == item.Key.ActualMaster.PlanMasterId);
                                        ActualFabTables.Add(new ActualFabTable
                                        {
                                            JobNo = JobNo,
                                            WorkShopName = item.Key.BomCode,
                                            WorkGroup = item.Key.BomName,
                                            Weight = item.Sum(z => z.WeightPlan ?? 0),
                                            PlanMH = item.Sum(z => z.TotalPlanManHour ?? 0),
                                            ActualMH = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourOT ?? 0)),
                                            ActualMHxOT = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourNTOT ?? 0)),
                                            OverTimemultiply = item.Key.ActualMaster.OverTimemultiply ?? 1,
                                            Status = planA != null ? System.Enum.GetName(typeof(PlanningStatus), planA.PlanningStatus) : "-",
                                        });
                                    }
                                }
                            }

                            #endregion Actuals

                            if (ActualFabTables.Any())
                                return new JsonResult(new { ActualFabTables }, this.DefaultJsonSettings);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }

        // POST: api/ActualMaster/ProjectSummanyManHour
        [HttpPost("ProjectSummanyManHour")]
        public async Task<IActionResult> ProjectSummanyManHour([FromBody] OptionChartViewModel option)
        {
            var message = "Data not been found.";
            try
            {
                if (option != null)
                {
                    if (option.PlanMasterId.HasValue)
                    {
                        var ActualFabTables = new List<ActualFabTable>();
                        var planMaster = await this.repositoryPlanMaster.GetFirstOrDefaultAsync(x => x,x => x.PlanMasterId == option.PlanMasterId);
                        var ProjectName = planMaster.ProjectName;
                        DateTime ReportDate = planMaster.ModifyDate ?? planMaster.CreateDate.Value;
                        // has detail with actual type
                        var detailHasType = await this.context.PlanDetails
                                                    .Where(x => x.PlanMasterId == option.PlanMasterId)
                                                    .Join(this.context.WorkGroupHasNickNames,
                                                    x => x.AssignmentToGroup,
                                                    z => z.GroupCode,
                                                    (x, z) => new
                                                        {
                                                            x.PlanDetailId,
                                                            x.AssignmentToGroup,
                                                            z.NickName,
                                                            z.ActualType
                                                        })
                                                    .DefaultIfEmpty()
                                                    .ToListAsync();

                        if (detailHasType != null)
                        {
                            var listIds = detailHasType.Select(z => z.PlanDetailId).ToList();
                            var planDetails = await this.repositoryPlanDetail.GetToListAsync(
                                           x => x,
                                           x => listIds.Contains(x.PlanDetailId),
                                           null,
                                           x => x.Include(z => z.FabricationManHour)
                                                 .Include(z => z.EngineerManHour)
                                                 .Include(z => z.PackingManHour)
                                                 .Include(z => z.WeldManHour));

                            if (planDetails != null)
                            {
                                foreach (var groupType in detailHasType.GroupBy(z => z.ActualType))
                                {
                                    var planMH = 0D;
                                    var planDetail = planDetails.Where(x => groupType.Select(z => z.PlanDetailId).ToList().Contains(x.PlanDetailId));
                                    switch (groupType.Key)
                                    {
                                        case ActualType.FABRICATE:
                                            planMH = planDetail.Sum(x => x?.FabricationManHour != null ? (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                                        (x?.FabricationManHour?.PerAssemblyMH ?? 0) : 0D);
                                            break;
                                        case ActualType.ENGINEERING:
                                            planMH = planDetail.Sum(x => x?.EngineerManHour != null ? 
                                                                        (x?.EngineerManHour?.CuttingPlanCheckMH ?? 0) +
                                                                        (x?.EngineerManHour?.CuttingPlanMH ?? 0) +
                                                                        (x?.EngineerManHour?.PackingCheckMH ?? 0) +
                                                                        (x?.EngineerManHour?.PackingMH ?? 0) +
                                                                        (x?.EngineerManHour?.ShopDrawingCheckMH ?? 0) +
                                                                        (x?.EngineerManHour?.ShopDrawingMH ?? 0) : 0D);
                                            break;
                                        case ActualType.PACK:
                                            planMH = planDetail.Sum(x => x?.PackingManHour != null ? 
                                                                        (x?.PackingManHour?.PackingMH ?? 0)  : 0D);
                                            break;
                                        case ActualType.WELD:
                                            planMH = planDetail.Sum(x => x?.WeldManHour != null ?
                                                                        (x?.WeldManHour?.WeldMH ?? 0) : 0D);
                                            break;
                                        default:
                                            break;
                                    }

                                    ActualFabTables.Add(new ActualFabTable
                                    {
                                        JobNo =((int)groupType.Key).ToString(),
                                        WorkShopName = groupType.Key != null ? System.Enum.GetName(typeof(ActualType), groupType.Key) : "-",
                                        Weight = planDetail.Sum(z => z.ContentWeigth ?? 0),
                                        PlanMH = planMH,
                                        ActualMH = 0,
                                        ActualMHxOT = 0,
                                        OverTimemultiply = 1,
                                    });
                                }
                            }
                        }

                        var actualDetails = await this.repositoryActualDetail.GetToListAsync(
                            x => x,
                            x => x.ActualMaster.PlanMasterId == option.PlanMasterId,
                            null, x => x.Include(z => z.ActualMaster));

                        if (actualDetails != null)
                        {
                            ReportDate = (actualDetails?.FirstOrDefault()?.ActualMaster?.ModifyDate ??
                                actualDetails?.FirstOrDefault()?.ActualMaster?.CreateDate) ?? ReportDate;

                            foreach (var item in actualDetails.GroupBy(z => z.ActualType))
                            {
                                var key1 = ((int)item.Key).ToString();

                                if (ActualFabTables.Any(z => z.JobNo == key1))
                                {
                                    var update = ActualFabTables.FirstOrDefault(z => z.JobNo == item.Key.ToString());
                                    if (update != null)
                                    {
                                        update.ActualMH += (item.Sum(z => (z.TotalManHour ?? 0) + (z.TotalManHourOT ?? 0)));
                                        update.ActualMHxOT += (item.Sum(z => (z.TotalManHour ?? 0) + (z.TotalManHourNTOT ?? 0)));
                                    }
                                }
                                else
                                {
                                    ActualFabTables.Add(new ActualFabTable
                                    {
                                        JobNo = ((int)item.Key).ToString(),
                                        WorkShopName = item.Key != null ? System.Enum.GetName(typeof(ActualType), item.Key) : "-",
                                        Weight = item.Sum(z => z.WeightPlan ?? 0),
                                        PlanMH = item.Sum(z => z.TotalPlanManHour ?? 0),
                                        ActualMH = (item.Sum(z => (z.TotalManHour ?? 0) + (z.TotalManHourOT ?? 0))),
                                        ActualMHxOT = (item.Sum(z => (z.TotalManHour ?? 0) + (z.TotalManHourNTOT ?? 0))),
                                        OverTimemultiply = item?.FirstOrDefault()?.ActualMaster?.OverTimemultiply ?? 1
                                    });
                                }
                            }
                        }

                        if (ActualFabTables.Any())
                            return new JsonResult(new {
                                ProjectName,
                                ReportDate,
                                Status = planMaster != null && planMaster?.PlanningStatus == null ?
                                    "-" : System.Enum.GetName(typeof(PlanningStatus), planMaster.PlanningStatus),
                                ActualFabTables = ActualFabTables.OrderBy(z => z.JobNo)
                            }, this.DefaultJsonSettings);
                    }
                }
            }
            catch(Exception ex)
            {
                message = $"Has error {ex.ToString()}";
            }
            return BadRequest(new { message });
        }
    }
}