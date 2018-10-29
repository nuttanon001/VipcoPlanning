using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using VipcoPlanning.Models.Planning;
using VipcoPlanning.Models.Machines;
using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;

using AutoMapper;
using VipcoPlanning.Helper;

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualMasterController : GenericPlanningController<ActualMaster>
    {
        private readonly IRepositoryPlanning<ActualDetail> repositoryActualDetail;
        private readonly IRepositoryPlanning<ActualBom> repositoryActualBom;
        private readonly IRepositoryPlanning<PlanDetail> repositoryPlanDetail;
        private readonly IRepositoryPlanning<WorkGroupHasNickName> repositoryNickName;
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryWorkGroup;
        // GET: api/ActualMaster
        public ActualMasterController(IRepositoryPlanning<ActualMaster> repo,
            IRepositoryPlanning<ActualDetail> repoActualDetail,
            IRepositoryPlanning<ActualBom> repoActualBom,
            IRepositoryPlanning<PlanDetail> repoPlanDetail,
            IRepositoryPlanning<WorkGroupHasNickName> repoNickName,
             IRepositoryMachine<EmployeeGroupMis> repoWorkGroup,
            IMapper mapper): base(repo, mapper)
        {
            // IRepositoryPlanning
            this.repositoryActualDetail = repoActualDetail;
            this.repositoryActualBom = repoActualBom;
            this.repositoryPlanDetail = repoPlanDetail;
            this.repositoryNickName = repoNickName;
            // IRepositoryMachine
            this.repositoryWorkGroup = repoWorkGroup;
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

            var predicate = PredicateBuilder.False<ActualMaster>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.ProjectName.ToLower().Contains(keyword));
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
                x => x, x => x.PlanMasterId == record.PlanMasterId && x.ValidTo == null);

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
                            x => x, x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == item.GroupCode,
                            null,x => x.Include(z => z.FabricationManHour));

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
                              x => x, x => x.PlanMasterId == record.PlanMasterId && x.AssignmentToGroup == item.GroupCode,
                              null, x => x.Include(z => z.FabricationManHour));

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
                            uActualDetail.WeightPlan = hasPlanDetail.Sum(z => z.ContentWeigth) ?? 0;
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
                #endregion

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
                #endregion
            }

            return new JsonResult(record, this.DefaultJsonSettings);
        }

        // POST: api/ActualMaster/ChartManHours
        [HttpPost("ChartManHour")]
        public async Task<IActionResult> ChartManHour(OptionChartViewModel Confition)
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

                    if (HasData != null)
                    {
                        #region ChartData
                        // Labels
                        var Labels = new List<string>();
                        // Datas
                        var ChartData1s = new List<ChartDataViewModel>();
                        var ChartData2s = new List<ChartDataViewModel>();

                        Labels = HasData.ActualDetails
                            .OrderBy(x => x.NickName)
                            .Where(x => x.ActualType == ActualType.FABRICATE)
                            .Select(x => x.NickName).ToList();

                        // Data Plans
                        var DataPlans = HasData.ActualDetails
                            .Where(x => x.ActualType == ActualType.FABRICATE)
                            .OrderBy(x => x.NickName)
                            .Select(x => x.TotalPlanManHour ?? 0).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Plan MH",
                            ChartData = DataPlans
                        });
                        // Data Actuals
                        var DataActual = HasData.ActualDetails
                           .Where(x => x.ActualType == ActualType.FABRICATE)
                           .OrderBy(x => x.NickName)
                           .Select(x => x.TotalManHourNTOT ?? 0).ToList();
                        ChartData1s.Add(new ChartDataViewModel()
                        {
                            Label = "Actual MH",
                            ChartData = DataActual
                        });
                        // Data Progress MH

                        var DataProgress = HasData.ActualDetails
                           .Where(x => x.ActualType == ActualType.FABRICATE)
                           .OrderBy(x => x.NickName)
                           .Select(x => (
                           x.TotalManHourNTOT.HasValue && x.TotalManHourNTOT > 0 && x.TotalPlanManHour.HasValue && x.TotalPlanManHour > 0 ?
                            ((x.TotalManHourNTOT ?? 0) / (x.TotalPlanManHour ?? 0)) * 100 : 0)).ToList();
                        ChartData2s.Add(new ChartDataViewModel()
                        {
                            Label = "Progress MH",
                            ChartData = DataProgress
                        });
                        #endregion

                        #region TableData

                        var ActualFabTables = new List<ActualFabTable>();

                        foreach (var item in HasData.ActualDetails
                            .Where(x => x.ActualType == ActualType.FABRICATE)
                            .OrderBy(z => z.WorkShop))
                        {
                            ActualFabTables.Add(new ActualFabTable {
                                WorkShopName = item.WorkShop,
                                WorkGroup = item.NickName,
                                Weight = item.WeightPlan,
                                PlanMH = item.TotalPlanManHour,
                                ActualMH = item.TotalManHourNTOT,
                                OverTimemultiply = HasData.OverTimemultiply ?? 1
                            });
                        }

                        #endregion

                        return new JsonResult(new {
                            HasData.ProjectName,
                            Labels,
                            ChartData1s,
                            ChartData2s,
                            ActualFabTables,
                        },this.DefaultJsonSettings);
                    }
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }
    }
}
