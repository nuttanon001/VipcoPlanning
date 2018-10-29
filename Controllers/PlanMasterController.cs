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
    public class PlanMasterController : GenericPlanningController<PlanMaster>
    {
        private readonly IRepositoryPlanning<BillofMaterial> repositoryBom;
        private readonly IRepositoryPlanning<PlanDetail> repositoryPlanDetail;
        private readonly IRepositoryPlanning<StandardTime> repositoryStd;
        private readonly IRepositoryPlanning<EngineerManHour> repositoryEngMH;
        private readonly IRepositoryPlanning<FabricationManHour> repositoryFabMH;
        private readonly IRepositoryPlanning<PackingManHour> repositoryPakMH;
        private readonly IRepositoryPlanning<WeldManHour> repositoryWedMH;
        private readonly IRepositoryPlanning<HistoryPlanMaster> repositoryHistory;
        private readonly IRepositoryPlanning<RateManHour> repositoryRate;
        private readonly IRepositoryPlanning<WorkGroupHasNickName> repositoryNickName;
        private readonly IRepositoryMachine<Employee> repositoryEmp;
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryGroupMis;
        private readonly IRepositoryMachine<WorkGroupHasWorkShop> repositoryWorkGroupShop;

        public PlanMasterController(IRepositoryPlanning<PlanMaster> repo,
            IRepositoryPlanning<BillofMaterial> repoBom,
            IRepositoryPlanning<StandardTime> repoStd,
            IRepositoryPlanning<PlanDetail> repoPlanDetail,
            IRepositoryPlanning<EngineerManHour> repoEngMH,
            IRepositoryPlanning<FabricationManHour> repoFabMM,
            IRepositoryPlanning<PackingManHour> repoPakMH,
            IRepositoryPlanning<WeldManHour> repoWedMH,
            IRepositoryPlanning<HistoryPlanMaster> repoHistory,
            IRepositoryPlanning<RateManHour> repoRate,
            IRepositoryPlanning<WorkGroupHasNickName> repoNickName,
            IRepositoryMachine<Employee> repoEmp,
            IRepositoryMachine<EmployeeGroupMis> repoGroupMis,
            IRepositoryMachine<WorkGroupHasWorkShop> repoWorkGropShop,
            IMapper mapper) : base(repo, mapper)
        {
            // Repository Planning
            this.repositoryBom = repoBom;
            this.repositoryStd = repoStd;
            this.repositoryPlanDetail = repoPlanDetail;
            this.repositoryEngMH = repoEngMH;
            this.repositoryFabMH = repoFabMM;
            this.repositoryPakMH = repoPakMH;
            this.repositoryWedMH = repoWedMH;
            this.repositoryHistory = repoHistory;
            this.repositoryRate = repoRate;
            this.repositoryNickName = repoNickName;
            // Repository Machine
            this.repositoryEmp = repoEmp;
            this.repositoryGroupMis = repoGroupMis;
            this.repositoryWorkGroupShop = repoWorkGropShop;
        }

        readonly Func<string, string> TrimAndLower = s1 => s1.Trim().ToLower();

        // GET: api/controller/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x,x => x.PlanMasterId == key);
            if (HasData != null)
            {
                var MapData = this.mapper.Map<PlanMaster, PlanMasterViewModel>(HasData);
                if (!string.IsNullOrEmpty(MapData.ManagementBy))
                    MapData.ManagementByString = (await this.repositoryEmp.GetFirstOrDefaultAsync(x => x,x => x.EmpCode == MapData.ManagementBy)).NameThai ?? "-";
                return new JsonResult(MapData, this.DefaultJsonSettings);
            }
            return BadRequest(new { Error = "Data not beed found." });
        }
        // POST: api/PlanMaster/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();

            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);
            Expression<Func<PlanMaster, bool>> predicate = e => e.HistoryPlanMaster.ValidTo == null;

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.And(x => x.ProjectName.ToLower().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<PlanMaster>, IOrderedQueryable<PlanMaster>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ProjectName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ProjectName);
                    else
                        order = o => o.OrderBy(x => x.ProjectName);
                    break;
                case "DeliveryDate":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.DeliveryDate);
                    else
                        order = o => o.OrderBy(x => x.DeliveryDate);
                    break;
                case "ManagementBy":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ManagementBy);
                    else
                        order = o => o.OrderBy(x => x.ManagementBy);
                    break;
                default:
                    order = o => o.OrderBy(x => x.ProjectName);
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

            var mapDatas = new List<PlanMasterViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<PlanMaster, PlanMasterViewModel>(item);
                if (!string.IsNullOrEmpty(MapItem.ManagementBy))
                {
                    var NameThai = await this.repositoryEmp.GetFirstOrDefaultAsync(x => x.NameThai, x => x.EmpCode == MapItem.ManagementBy);
                    MapItem.ManagementByString = NameThai;
                }
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<PlanMasterViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }

        // POST: api/PlanDetail/CalcManHour
        [HttpPost("CalcManHour")]
        public async Task<IActionResult> CalcManHour([FromBody] PlanMaster planMaster)
        {
            if (planMaster != null)
            {
                // Get PlanMasters
                var dbPlanMaster = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.PlanMasterId == planMaster.PlanMasterId);
                if (dbPlanMaster != null)
                {
                    dbPlanMaster.ModifyDate = DateTime.Now;
                    dbPlanMaster.Modifyer = planMaster.Modifyer;
                    // Get PlanDetails
                    var dbPlanDetails = await this.repositoryPlanDetail.GetToListAsync(
                        x => x,x => x.PlanMasterId == planMaster.PlanMasterId);

                    if (dbPlanDetails.Any())
                    {
                        foreach (var item in dbPlanDetails)
                        {
                            if (item == null) continue;

                            item.Modifyer = planMaster.Modifyer;
                            item.ModifyDate = dbPlanMaster.ModifyDate;

                            var Weight = (item.ContentWeigth * 1000);
                            // EngineerManHour
                            if (item.EngineerManHour != null)
                            {
                                item.EngineerManHour.EngineerWeight = Weight;
                                item.EngineerManHour.CuttingPlanMH = item.EngineerManHour?.CuttingPlan != null ? (Weight / (item.EngineerManHour?.CuttingPlan?.Rate ?? 0)) : 0;
                                item.EngineerManHour.CuttingPlanCheckMH = item.EngineerManHour?.CuttingPlanCheck != null ? (Weight / (item.EngineerManHour?.CuttingPlanCheck?.Rate ?? 0)) : 0;
                                item.EngineerManHour.ShopDrawingMH = item.EngineerManHour?.ShopDrawing != null ? (Weight / (item.EngineerManHour?.ShopDrawing?.Rate ?? 0)) : 0;
                                item.EngineerManHour.ShopDrawingCheckMH = item.EngineerManHour?.ShopDrawingCheck != null ? (Weight / (item.EngineerManHour?.ShopDrawingCheck?.Rate ?? 0)) : 0;
                                item.EngineerManHour.PackingMH = item.EngineerManHour?.Packing != null ? (Weight / (item.EngineerManHour?.Packing?.Rate ?? 0)) : 0;
                                item.EngineerManHour.PackingCheckMH = item.EngineerManHour?.PackingCheck != null ? (Weight / (item.EngineerManHour?.PackingCheck?.Rate ?? 0)) : 0;

                                item.EngineerManHour.ModifyDate = item.ModifyDate;
                                item.EngineerManHour.Modifyer = item.Modifyer;
                                // Update EngineerManHour
                                await this.repositoryEngMH.UpdateAsync(item.EngineerManHour, item.EngineerManHour.EngineerManHourId);
                            }
                            // FabricationManHour
                            if (item.FabricationManHour != null)
                            {
                                item.FabricationManHour.FabricationWeight = Weight;
                                item.FabricationManHour.FabricationMH = item.FabricationManHour?.Fabrication != null ? (Weight / (item.FabricationManHour?.Fabrication?.Rate ?? 0)) : 0;
                                item.FabricationManHour.PerAssemblyMH = item.FabricationManHour?.PerAssembly != null ? (Weight / (item.FabricationManHour?.PerAssembly?.Rate ?? 0)) : 0;

                                item.FabricationManHour.ModifyDate = item.ModifyDate;
                                item.FabricationManHour.Modifyer = item.Modifyer;
                                // Update FabricationManHour
                                await this.repositoryFabMH.UpdateAsync(item.FabricationManHour, item.FabricationManHour.FabricationManHourId);
                            }
                            // PackingManHour
                            if (item.PackingManHour != null)
                            {
                                item.PackingManHour.PackingWeight = Weight;
                                item.PackingManHour.PackingMH = item.PackingManHour?.Packing != null ? (Weight / (item.PackingManHour?.Packing?.Rate ?? 0)) : 0;

                                item.PackingManHour.ModifyDate = item.ModifyDate;
                                item.PackingManHour.Modifyer = item.Modifyer;
                                // Update PackingManHour
                                await this.repositoryPakMH.UpdateAsync(item.PackingManHour, item.PackingManHour.PackingManHourId);
                            }
                            // WeldManHour
                            if (item.WeldManHour != null)
                            {
                                item.WeldManHour.WeldWetght = Weight;
                                item.WeldManHour.WeldMH = item.WeldManHour?.Weld != null ? (Weight / (item.WeldManHour?.Weld?.Rate ?? 0)) : 0;

                                item.WeldManHour.ModifyDate = item.ModifyDate;
                                item.WeldManHour.Modifyer = item.Modifyer;
                                // Update PackingManHour
                                await this.repositoryWedMH.UpdateAsync(item.WeldManHour, item.WeldManHour.WeldManHourId);
                            }
                            // Update plan-detail
                            await this.repositoryPlanDetail.UpdateAsync(item, item.PlanDetailId);
                        }
                        // update plan-master
                        await this.repository.UpdateAsync(dbPlanMaster, dbPlanMaster.PlanMasterId);
                        // return json result
                        return new JsonResult(new { Result = true }, this.DefaultJsonSettings);
                    }
                }
            }
            return BadRequest(new { Error = "Data not been found." });
        }

        // POST: api/PlanMaster/CreateV2
        [HttpPost("CreateV2")]
        public async Task<IActionResult> CreateV2([FromBody] PlanMasterViewModel recordViewModel)
        {
            var Message = "Data not been found.";
            try
            {
                if (recordViewModel != null)
                {
                    var record = this.mapper.Map<PlanMasterViewModel, PlanMaster>(recordViewModel);
                    // +7 Hour
                    record = this.helper.AddHourMethod(record);
                    record.CreateDate = DateTime.Now;
                    // Update revised
                    var lastPlanMaster = await this.repository.GetFirstOrDefaultAsync(
                                                    e => e,
                                                    e => e.ProjectCodeMasterId == record.ProjectCodeMasterId &&
                                                        (e.HistoryPlanMaster != null && e.HistoryPlanMaster.ValidTo == null),
                                                    e => e.OrderByDescending(x => x.CreateDate),
                                                    e => e.Include(z => z.HistoryPlanMaster));

                    if (lastPlanMaster != null)
                    {
                        record.Revised = lastPlanMaster.Revised + 1;
                        lastPlanMaster.HistoryPlanMaster.ValidTo = DateTime.Now;
                        lastPlanMaster.ModifyDate = DateTime.Now;
                        lastPlanMaster.Modifyer = record.Creator;
                    }

                    record.HistoryPlanMaster = new HistoryPlanMaster()
                    {
                        CreateDate = record.CreateDate,
                        Creator = record.Creator,
                        ValidFrom = DateTime.Now
                    };

                    if (record.PlanDetails.Any())
                        record.PlanDetails = new List<PlanDetail>();

                    if (recordViewModel.PlanDetails != null)
                    {
                        var helperDetail = new Helpers.HelpersClass<PlanDetailViewModel>();
                        // var AllStd = await this.repositoryStd.GetAllAsync();
                        foreach (var item in recordViewModel.PlanDetails.ToList())
                        {
                            if (item == null)
                                continue;

                            var clone = helperDetail.AddHourMethod(item);
                            var mapData = this.mapper.Map<PlanDetailViewModel, PlanDetail>(clone);

                            mapData.CreateDate = record.CreateDate;
                            mapData.Creator = record.Creator;

                            if ((await this.repositoryEmp.GetFirstOrDefaultAsync(e => e, e => e.EmpCode == mapData.ResponsibilityBy)) == null)
                                mapData.ResponsibilityBy = "";

                            if ((await this.repositoryGroupMis.GetFirstOrDefaultAsync(x => x, e => e.GroupMis == mapData.AssignmentToGroup)) == null)
                                mapData.AssignmentToGroup = "";

                            // Bom
                            Expression<Func<BillofMaterial, bool>> expression = b => TrimAndLower(b.Code).Contains(TrimAndLower(clone.BomLevel2));
                            var BomId = (await this.repositoryBom.GetFirstOrDefaultAsync(x => x, expression))?.BillofMaterialId ?? 0;
                            if (BomId > 0)
                                mapData.BillofMaterialId = BomId;
                            //Std Eng
                            if (!string.IsNullOrEmpty(clone.ShopDrawingStd) || !string.IsNullOrEmpty(clone.CuttingPlanStd) || !string.IsNullOrEmpty(clone.PackingFrameStd))
                            {
                                mapData.EngineerManHour = new EngineerManHour()
                                {
                                    CreateDate = record.CreateDate,
                                    Creator = record.Creator,
                                    EngineerWeight = mapData.ContentWeigth,
                                    ShopDrawingId = string.IsNullOrEmpty(clone.ShopDrawingStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.ShopDrawingStd))))?.StandardTimeId ?? null,
                                    ShopDrawingCheckId = string.IsNullOrEmpty(clone.CheckShopDrawingStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.CheckShopDrawingStd))))?.StandardTimeId ?? null,
                                    CuttingPlanId = string.IsNullOrEmpty(clone.CuttingPlanStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.CuttingPlanStd))))?.StandardTimeId ?? null,
                                    CuttingPlanCheckId = string.IsNullOrEmpty(clone.CheckCuttingPlanStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.CheckCuttingPlanStd))))?.StandardTimeId ?? null,
                                    PackingId = string.IsNullOrEmpty(clone.PackingFrameStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.PackingFrameStd))))?.StandardTimeId ?? null,
                                    PackingCheckId = string.IsNullOrEmpty(clone.CheckPackingFrameStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.CheckPackingFrameStd))))?.StandardTimeId ?? null,
                                };
                            }

                            //Std Fab
                            if (!string.IsNullOrEmpty(clone.FabStd) || !string.IsNullOrEmpty(clone.PreStd))
                            {
                                mapData.FabricationManHour = new FabricationManHour()
                                {
                                    CreateDate = record.CreateDate,
                                    Creator = record.Creator,
                                    FabricationWeight = mapData.ContentWeigth,
                                    FabricationId = string.IsNullOrEmpty(clone.FabStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.FabStd))))?.StandardTimeId ?? null,
                                    PerAssemblyId = string.IsNullOrEmpty(clone.PreStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.PreStd))))?.StandardTimeId ?? null,
                                };
                            }

                            //Std Pack
                            if (!string.IsNullOrEmpty(clone.PackStd))
                            {
                                mapData.PackingManHour = new PackingManHour()
                                {
                                    CreateDate = record.CreateDate,
                                    Creator = record.Creator,
                                    PackingWeight = mapData.ContentWeigth,
                                    PackingId = string.IsNullOrEmpty(clone.PackStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.PackStd))))?.StandardTimeId ?? null,
                                };
                            }

                            //Std Weld
                            if (!string.IsNullOrEmpty(clone.WeldStd))
                            {
                                mapData.WeldManHour = new WeldManHour()
                                {
                                    CreateDate = record.CreateDate,
                                    Creator = record.Creator,
                                    WeldWetght = mapData.ContentWeigth,
                                    WeldId = string.IsNullOrEmpty(clone.WeldStd) ? null : (await this.repositoryStd.GetFirstOrDefaultAsync(x => x, x => TrimAndLower(x.Code).Contains(TrimAndLower(clone.WeldStd))))?.StandardTimeId ?? null,
                                };
                            }

                            if (record.PlanDetails == null)
                                record.PlanDetails = new List<PlanDetail>();

                            record.PlanDetails.Add(mapData);
                        }
                    }

                    if (await this.repository.AddAsync(record) == null)
                        return BadRequest();

                    if (lastPlanMaster != null)
                        await this.repositoryHistory.UpdateAsync(lastPlanMaster.HistoryPlanMaster, lastPlanMaster.HistoryPlanMaster.HistoryPlanMasterId);

                    return new JsonResult(record, this.DefaultJsonSettings);
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }
            return BadRequest(new { Error = Message });

         
        }

        // PUT: api/PlanMaster/UpdateV2
        [HttpPut("UpdateV2")]
        public async Task<IActionResult> UpdateV2(int key, [FromBody] PlanMasterViewModel recordViewModel)
        {
            if (recordViewModel == null)
                return BadRequest(new { Error = "Data not been found." });

            var record = this.mapper.Map<PlanMasterViewModel, PlanMaster>(recordViewModel);
            // +7 Hour
            record = this.helper.AddHourMethod(record);
            // Set date for CrateDate Entity
            if (record.GetType().GetProperty("ModifyDate") != null)
                record.GetType().GetProperty("ModifyDate").SetValue(record, DateTime.Now);

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();
           
            return new JsonResult(record, this.DefaultJsonSettings);
        }
        // DELETE: api/PlanMaster/
        [HttpDelete()]
        public override async Task<IActionResult> Delete(int key)
        {
            var Message = "";
            try
            {
                var PlanDetail = await this.repositoryPlanDetail.GetToListAsync(x => x,x => x.PlanMasterId == key);
                var HistoryPm = await this.repositoryHistory.GetFirstOrDefaultAsync(x => x, x => x.PlanMasterId == key);
                if (HistoryPm != null)
                   await this.repositoryHistory.DeleteAsync(HistoryPm.HistoryPlanMasterId);

                if (PlanDetail.Any())
                {
                    foreach (var item in PlanDetail.ToList())
                    {
                        if (item.EngineerManHour != null)
                            await this.repositoryEngMH.DeleteAsync(item.EngineerManHour.EngineerManHourId);
                        if (item.FabricationManHour != null)
                            await this.repositoryFabMH.DeleteAsync(item.FabricationManHour.FabricationManHourId);
                        if (item.PackingManHour != null)
                            await this.repositoryPakMH.DeleteAsync(item.PackingManHour.PackingManHourId);
                        if (item.WeldManHour != null)
                            await this.repositoryWedMH.DeleteAsync(item.WeldManHour.WeldManHourId);

                        await this.repositoryPlanDetail.DeleteAsync(item.PlanDetailId);
                    }
                }
                if (await this.repository.DeleteAsync(key) == 0)
                    return BadRequest();
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }
         
            return NoContent();
        }

        #region SummanyReport
        [HttpPost("SummanyReportByJobNumber")]
        public async Task<IActionResult> SummanyReportByJobNumber([FromBody] SummanyReportViewModel summany)
        {
            var Message = "Data not been found.";
            try
            {
                if (summany != null)
                {
                    if (!summany.PlanMasterId.HasValue)
                        return NoContent();
                        // return BadRequest(new { error = "Data not been found." });

                    Expression<Func<PlanMaster, bool>> exp = e => e.PlanMasterId == summany.PlanMasterId;
                    
                    // if (!string.IsNullOrEmpty(summany.Where))
                        //TODO Filter or do someing

                    if (!string.IsNullOrEmpty(summany.WorkGroup))
                        exp = exp.And(x => x.PlanDetails.Any
                                     (z => z.AssignmentToGroup == summany.WorkGroup));

                    if (summany.BomLevel.HasValue)
                        exp = exp.And(x => x.PlanDetails.Any
                                     (z => z.BillofMaterialId == summany.BomLevel));
                    
                    var GetData = await this.repository.GetFirstOrDefaultAsync(
                                            x => x,exp,
                                            z => z.OrderByDescending(x => x.Revised));

                    var Rate = (await this.repositoryRate.GetFirstOrDefaultAsync(e => e,e => 
                                        e.StandardTimeForWorkGroup.Name.ToLower().Contains("fabricate") &&
                                        GetData.CreateDate.Value.Date >= e.ValidFrom && GetData.CreateDate.Value.Date <= e.ValidTo))?.RateBathPerManHour ?? 0;

                    var NickName = await this.repositoryNickName.GetAllAsync();
                    var SummanyDatas = new List<SummanyDataPlanVsActual>();

                    //Get Detail Data
                    var DetailData = await this.repositoryPlanDetail.GetToListAsync(
                                        z => z,
                                        z => z.PlanMasterId == GetData.PlanMasterId,
                                        null,
                                        z => z.Include(x => x.FabricationManHour));

                    var TotalRow = DetailData.GroupBy(x => x.AssignmentToGroup).Count();
                    // foreach(var ByGroup in DetailData.GroupBy(x => x.AssignmentToGroup).Skip(summany.Skip ?? 0).Take(summany.Take ?? 10))
                    foreach (var ByGroup in DetailData.GroupBy(x => x.AssignmentToGroup))
                    {
                        if (ByGroup.Key == null)
                            continue;

                        var WorkGroup = await this.repositoryGroupMis.GetFirstOrDefaultAsync(
                            x => x, 
                            m => m.GroupMis == ByGroup.Key,null,
                            x => x.Include(z => z.WorkGroupHasWorkShop).ThenInclude(z => z.WorkShop));

                        var WorkShop = WorkGroup?.WorkGroupHasWorkShop.FirstOrDefault()?.WorkShop ?? null;
                        //EngMH
                        //var EngMH = ByGroup.Sum(x => (x?.EngineerManHour?.CuttingPlanMH ?? 0) +
                        //                             (x?.EngineerManHour?.CuttingPlanCheckMH ?? 0) +
                        //                             (x?.EngineerManHour?.PackingCheckMH ?? 0) +
                        //                             (x?.EngineerManHour?.PackingMH ?? 0) +
                        //                             (x?.EngineerManHour?.ShopDrawingCheckMH ?? 0) +
                        //                             (x?.EngineerManHour?.ShopDrawingMH ?? 0));
                        ////FabMH
                        var FabMH = ByGroup.Sum(x => (x?.FabricationManHour?.FabricationMH ?? 0) +
                                                     (x?.FabricationManHour?.PerAssemblyMH ?? 0));
                        //PackMH
                        //var PackMH = ByGroup.Sum(x => (x?.PackingManHour?.PackingMH ?? 0));
                        //WeldMH
                        //var WeldMH = ByGroup.Sum(x => (x?.WeldManHour?.WeldMH ?? 0));
                        var TotalWeight = ByGroup.Sum(x => x.ContentWeigth ?? 0);
                        SummanyDatas.Add(new SummanyDataPlanVsActual
                        {
                            WorkShopName = WorkShop?.WorkShopName ?? "Data not found",
                            WorkGroup = WorkGroup != null ? (NickName.FirstOrDefault(x => x.GroupCode == WorkGroup.GroupMis)?.NickName ?? WorkGroup?.GroupDesc ?? "-") : "Data not found",
                            Item = string.Join(", ",ByGroup.Select(x => x.Description)),
                            Weight = TotalWeight,
                            EngManHour = 0,
                            FabManHour = FabMH,
                            FabRateManHour = Rate > 0 && TotalWeight > 0 && FabMH > 0 ? (FabMH * Rate)/(TotalWeight*1000) : 0,
                            PackManHour = 0,
                            WeldManHour = 0,
                        });
                    }

                    if (SummanyDatas.Any())
                        return new JsonResult( new
                        {
                            SummanyDatas = SummanyDatas.OrderBy(x => x.WorkShopName),
                            TotalRow
                        }, this.DefaultJsonSettings);
                }   
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { error = Message });
        }

        #endregion
    }
}