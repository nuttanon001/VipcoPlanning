using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using VipcoPlanning.Models.Planning;
using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;

using AutoMapper;
using VipcoPlanning.Helper;
using VipcoPlanning.Models.Machines;

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkGroupTotalManHourController : ControllerBase
    {
        //View
        private readonly IRepositoryPlanning<WorkGroupTotalManHourView> repository;
        private readonly IRepositoryPlanning<WorkGroupTotalManHourSubView> repositorySub;
        private readonly IRepositoryPlanning<BomTotalManHourView> repositoryBomMh;
        private readonly IRepositoryPlanning<BomTotalManHourSubView> repositoryBomMhSub;
        private readonly IRepositoryPlanning<EmpTimeSubView> repositoryEmpTimeSub;
        private readonly IRepositoryPlanning<EmpTimeVipcoView> repositoryEmpTimeVipco;
        //Entity
        private readonly IRepositoryPlanning<WorkGroupHasNickName> repositoryNickName;
        private readonly IRepositoryPlanning<PlanMaster> repositoryPlanMaster;
        private readonly IRepositoryPlanning<PlanDetail> repositoryPlanDetail;
        private readonly IRepositoryPlanning<BillofMaterial> repositoryBom;
        private readonly IRepositoryMachine<ProjectCodeMaster> repositoryProject;
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryWorkGroup;
        private readonly IRepositoryMachine<WorkGroupHasWorkShop> repositoryWorkShop;
        private readonly IMapper mapper;
        public JsonSerializerSettings DefaultJsonSettings =>
           new JsonSerializerSettings()
           {
               Formatting = Formatting.Indented,
               PreserveReferencesHandling = PreserveReferencesHandling.Objects,
               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
           };
        // GET: api/WorkGroupTotalManHour
        public WorkGroupTotalManHourController(
            // Views
            IRepositoryPlanning<WorkGroupTotalManHourView> repo,
            IRepositoryPlanning<WorkGroupTotalManHourSubView> repoSub,
            IRepositoryPlanning<BomTotalManHourView> repoBomMh,
            IRepositoryPlanning<BomTotalManHourSubView> repoBomMhSub,
            IRepositoryPlanning<EmpTimeSubView> repoEmpTimeSub,
            IRepositoryPlanning<EmpTimeVipcoView> repoEmpTimeVipco,
            //Entities
            IRepositoryPlanning<PlanMaster> repoPlanMaster,
            IRepositoryPlanning<PlanDetail> repoPlanDetail,
            IRepositoryPlanning<WorkGroupHasNickName> repoNickName,
            IRepositoryPlanning<BillofMaterial> repoyBom,
            IRepositoryMachine<ProjectCodeMaster> repoProject,
            IRepositoryMachine<EmployeeGroupMis> repoWorkGroup,
            IRepositoryMachine<WorkGroupHasWorkShop> repoWorkShop,
            IMapper mapper)
        {
            // RepositoryPlanning
            //Views
            this.repository = repo;
            this.repositorySub = repoSub;
            this.repositoryBomMh = repoBomMh;
            this.repositoryBomMhSub = repoBomMhSub;
            this.repositoryEmpTimeSub = repoEmpTimeSub;
            this.repositoryEmpTimeVipco = repoEmpTimeVipco;
            //Entities
            this.repositoryNickName = repoNickName;
            this.repositoryPlanMaster = repoPlanMaster;
            this.repositoryPlanDetail = repoPlanDetail;
            this.repositoryBom = repoyBom;
            // RepositoryMachine
            this.repositoryProject = repoProject;
            this.repositoryWorkGroup = repoWorkGroup;
            this.repositoryWorkShop = repoWorkShop;
            // Mapper
            this.mapper = mapper;
        }

        // GET: api/WorkGroupTotalManHour/WrokGroupTotalMH
        [HttpGet("GetWorkGroupTotalMH")]
        public async Task<IActionResult> GetWorkGroupTotalMH(int PlanMasterId)
        {
            if (PlanMasterId > 0)
            {
                var hasPlan = await this.repositoryPlanMaster.GetFirstOrDefaultAsync(
                                        x => x,x => x.PlanMasterId == PlanMasterId,
                                        null,x => x.Include(z => z.PlanDetails));
                if (hasPlan != null)
                {
                    var hasProject = await this.repositoryProject.GetFirstOrDefaultAsync(x => x, x => x.ProjectCodeMasterId == hasPlan.ProjectCodeMasterId);
                    if (hasProject != null)
                    {
                        var MapDatas = new List<ActualDetailViewModel>();

                        #region ActualData

                        var WorkShop = await this.repositoryWorkShop.GetToListAsync(x => x, null, null, x => x.Include(z => z.WorkShop));
                        var WorkGroups = await this.repositoryWorkGroup.GetToListAsync(x => x);
                        var WorkNicks = await this.repositoryNickName.GetToListAsync(x => x);
                        // var workGroups = hasPlan.PlanDetails.GroupBy(x => x.AssignmentToGroup).Select(x => x.Key);
                        var hasData = await this.repository.GetToListAsync(
                            x => x,
                            //  x.JobNo.ToLower().Contains(hasProject.ProjectCode.ToLower()) && workGroups.Contains(x.GroupCode)
                            x => x.JobNo.ToLower().Equals(hasProject.ProjectCode.ToLower()));

                        if (hasData != null)
                        {
                            foreach (var item in hasData.OrderBy(z => z.GroupCode))
                            {
                                var MapData = this.mapper.Map<WorkGroupTotalManHourView, ActualDetailViewModel>(item);
                                var WorkNick = WorkNicks.FirstOrDefault(x => x.GroupCode == item.GroupCode);
                                var WorkGroup = WorkGroups.FirstOrDefault(x => x.GroupMis == item.GroupCode);
                                // Group
                                MapData.GroupName = WorkGroup?.GroupDesc ?? "-";
                                MapData.WorkShop = WorkShop?.FirstOrDefault(x => x.GroupMis == item.GroupCode)?.WorkShop?.WorkShopName ?? "-";
                                MapData.NickName = WorkNick?.NickName ?? MapData.GroupName;
                                MapData.ActualDetailType = ActualDetailType.VIPCO;
                                MapData.ActualType = WorkNick?.ActualType ?? ActualType.NONE;
                                MapData.ActualTypeString = System.Enum.GetName(typeof(ActualType), MapData.ActualType);
                                MapDatas.Add(MapData);
                            }
                        }

                        var hasDataSub = await this.repositorySub.GetToListAsync(
                            x => x,
                            x => x.JobNo.ToLower().Equals(hasProject.ProjectCode.ToLower()));

                        if (hasDataSub != null)
                        {
                            foreach (var itemSub in hasDataSub.OrderBy(z => z.GroupMIS))
                            {
                                var MapDataSub = this.mapper.Map<WorkGroupTotalManHourSubView, ActualDetailViewModel>(itemSub);
                                // Get workgroup planning
                                var WorkNickSub = WorkNicks.FirstOrDefault(x => x.GroupCode == itemSub.GroupMIS);
                                // Found workgroup have reference to other group
                                var RefWorkGroup = WorkNickSub != null ? WorkGroups.FirstOrDefault(x => x.GroupMis == WorkNickSub.ReferenceGroupCode) : null;
                                if (RefWorkGroup != null) // If have change this group to other group
                                {
                                    MapDataSub.GroupCode = RefWorkGroup?.GroupMis ?? "-";
                                    MapDataSub.GroupName = RefWorkGroup?.GroupDesc ?? "-";
                                    MapDataSub.ActualDetailType = ActualDetailType.VIPCO;
                                }
                                else
                                    MapDataSub.ActualDetailType = ActualDetailType.SUBCONTRACTOR;

                                // Check have workgroup from manhour
                                if (MapDatas.Any(z => z.GroupCode == MapDataSub.GroupCode))
                                {
                                    var updateManHour = MapDatas.FirstOrDefault(z => z.GroupCode == MapDataSub.GroupCode);
                                    updateManHour.TotalManHour += MapDataSub.TotalManHour;
                                    updateManHour.TotalManHourNTOT += MapDataSub.TotalManHourNTOT;
                                    updateManHour.TotalManHourOT += MapDataSub.TotalManHourOT;
                                }
                                else // if don't have in manhour add new
                                {
                                    MapDataSub.WorkShop = WorkShop?.FirstOrDefault(x => x.GroupMis == MapDataSub.GroupCode)?.WorkShop?.WorkShopName ?? "-";
                                    var WorkNickSub2 = WorkNicks.FirstOrDefault(x => x.GroupCode == MapDataSub.GroupCode);
                                    MapDataSub.NickName = WorkNickSub2?.NickName ?? MapDataSub.GroupName;
                                    MapDataSub.ActualType = WorkNickSub2?.ActualType ?? ActualType.NONE;
                                    MapDataSub.ActualTypeString = System.Enum.GetName(typeof(ActualType), MapDataSub.ActualType);
                                    MapDatas.Add(MapDataSub);
                                }
                            }
                        }

                        #endregion

                        #region PlanData

                        #endregion

                        if (MapDatas.Any())
                            return new JsonResult(MapDatas, this.DefaultJsonSettings);
                    }
                }
            }
            return BadRequest(new { Error = "Data not been found." });
        }

        // GET: api/WorkGroupTotalManHour/WrokGroupTotalMH
        [HttpGet("GetBomTotalMH")]
        public async Task<IActionResult> GetBomTotalMH(int PlanMasterId)
        {
            if (PlanMasterId > 0)
            {
                var hasPlan = await this.repositoryPlanMaster.GetFirstOrDefaultAsync(
                                        x => x, x => x.PlanMasterId == PlanMasterId,
                                        null, x => x.Include(z => z.PlanDetails));
                if (hasPlan != null)
                {
                    var hasProject = await this.repositoryProject.GetFirstOrDefaultAsync(x => x, x => x.ProjectCodeMasterId == hasPlan.ProjectCodeMasterId);
                    if (hasProject != null)
                    {
                        var MapDatas = new List<ActualBom>();
                        var WorkNicks = await this.repositoryNickName.GetToListAsync(x => x);
                        var hasData = await this.repositoryBomMh.GetToListAsync(
                            x => x,
                            x => x.JobNo.ToLower().Equals(hasProject.ProjectCode.ToLower()));

                        if (hasData != null)
                        {
                            var isBom = hasData.Where(x => !string.IsNullOrEmpty(x.ItemCode)).Select(z => z.ItemCode).Distinct().ToList();
                            var Boms = await this.repositoryBom.GetToListAsync(x => x,x => isBom.Contains(x.Code));

                            foreach (var item in hasData.OrderBy(z => z.ItemCode))
                            {
                                var MapData = this.mapper.Map<BomTotalManHourView, ActualBom>(item);
                                var WorkNick = WorkNicks.FirstOrDefault(x => x.GroupCode == item.GroupCode);

                                // Group
                                if (!string.IsNullOrEmpty(item.ItemCode))
                                    MapData.BomName = Boms.Any() ? Boms.FirstOrDefault(x => x.Code.ToLower().Equals(item.ItemCode.ToLower())).Name ?? "NONE" : "NONE";

                                MapData.ActualType = WorkNick?.ActualType ?? ActualType.NONE;
                                MapData.ActualDetailType = ActualDetailType.VIPCO;
                                MapDatas.Add(MapData);
                            }
                        }

                        var hasDataSub = await this.repositoryBomMhSub.GetToListAsync(
                            x => x,
                            x => x.JobNo.ToLower().Equals(hasProject.ProjectCode.ToLower()));

                        if (hasDataSub != null)
                        {
                            var isBomSub = hasData.Where(x => !string.IsNullOrEmpty(x.ItemCode)).Select(z => z.ItemCode).Distinct().ToList();
                            var BomSubs = await this.repositoryBom.GetToListAsync(x => x, x => isBomSub.Contains(x.Code));

                            foreach (var itemSub in hasDataSub.OrderBy(z => z.ItemCode))
                            {
                                var MapDataSub = this.mapper.Map<BomTotalManHourSubView, ActualBom>(itemSub);
                                if (!string.IsNullOrEmpty(itemSub.ItemCode))
                                    MapDataSub.BomName = BomSubs.Any() ? BomSubs.FirstOrDefault(x => x.Code.ToLower().Equals(itemSub.ItemCode.ToLower())).Name ?? "NONE" : "NONE";

                                var WorkNickSub = WorkNicks.FirstOrDefault(x => x.GroupCode == itemSub.GroupMIS);
                                var RefWorkGroup = WorkNickSub != null ? await this.repositoryWorkGroup.GetFirstOrDefaultAsync(x => x,x => x.GroupMis == WorkNickSub.ReferenceGroupCode) : null;
                                if (RefWorkGroup != null)
                                {
                                    MapDataSub.GroupCode = RefWorkGroup?.GroupMis ?? "-";
                                    MapDataSub.ActualDetailType = ActualDetailType.VIPCO;
                                }
                                else
                                    MapDataSub.ActualDetailType = ActualDetailType.SUBCONTRACTOR;

                                if (MapDatas.Any(z => z.GroupCode == MapDataSub.GroupCode && z.BomCode == MapDataSub.BomCode))
                                {
                                    var updateManHour = MapDatas.FirstOrDefault(z => z.GroupCode == MapDataSub.GroupCode && z.BomCode == MapDataSub.BomCode);
                                    updateManHour.TotalManHour += MapDataSub.TotalManHour;
                                    updateManHour.TotalManHourNTOT += MapDataSub.TotalManHourNTOT;
                                    updateManHour.TotalManHourOT += MapDataSub.TotalManHourOT;
                                }
                                else
                                {
                                    var WorkNickSub2 = WorkNicks.FirstOrDefault(x => x.GroupCode == MapDataSub.GroupCode);
                                    MapDataSub.ActualType = WorkNickSub2?.ActualType ?? ActualType.NONE;
                                    MapDatas.Add(MapDataSub);
                                }
                            }
                        }

                        if (MapDatas.Any())
                            return new JsonResult(MapDatas, this.DefaultJsonSettings);
                    }
                }
            }
            return BadRequest(new { Error = "Data not been found." });
        }

        // GET: api/WorkGroupTotalManHour/WrokGroupTotalMH
        [HttpPost("GetManHourDaily")]
        public async Task<IActionResult> GetManHourDaily(OptionChartViewModel option)
        {
            var message = "Data not been found.";

            try
            {
                if (option != null)
                {
                    if (option.SDate.HasValue && option.EDate.HasValue)
                    {
                        var MapDatas = new List<ActualDaily>();
                        var planWorkGroup = await this.repositoryNickName.GetToListAsync(x => x);
                        var conditionGroup = planWorkGroup.Select(x => x.GroupCode).ToList();
                        // Get workshop from MachineVipcoDatabase
                        var workShop = await this.repositoryWorkShop.GetToListAsync(x => x, 
                            x => conditionGroup.Contains(x.GroupMis), 
                            null, x => x.Include(z => z.WorkShop).Include(z => z.GroupMisNavigation));
                        // Get Employee total time by date from vipco
                        var HasVipcoTime = await this.repositoryEmpTimeVipco.GetToListAsync(x => x,
                            x => conditionGroup.Contains(x.GroupCode) &&
                                 x.WorkDate >= option.SDate.Value.Date &&
                                 x.WorkDate <= option.EDate.Value.Date &&
                                 x.WorkDate != null
                            , x => x.OrderBy(z => z.WorkDate));
                        if (HasVipcoTime != null)
                        {
                            foreach (var itemV in HasVipcoTime)
                            {
                                var MapData = this.mapper.Map<EmpTimeVipcoView, ActualDaily>(itemV);
                                var WorkNick = planWorkGroup.FirstOrDefault(x => x.GroupCode == itemV.GroupCode);

                                if (WorkNick != null)
                                {
                                    var CurWorkShop = workShop?.FirstOrDefault(x => x.GroupMis == MapData.GroupCode);
                                    if (CurWorkShop != null)
                                    {
                                        MapData.WorkShop = CurWorkShop?.WorkShop?.WorkShopName ?? "-";
                                        MapData.GroupName = CurWorkShop?.GroupMisNavigation?.GroupDesc ?? "-";
                                    }
                                    else
                                    {
                                        var groupMis = await this.repositoryWorkGroup.
                                            GetFirstOrDefaultAsync(x => x, x => x.GroupMis == MapData.GroupCode);
                                        MapData.GroupName = groupMis?.GroupDesc ?? "-";
                                    }
                                    

                                    MapData.NickName = WorkNick?.NickName ?? MapData.GroupName;
                                    MapData.ActualDetailType = ActualDetailType.VIPCO;
                                    MapData.ActualType = WorkNick?.ActualType ?? ActualType.NONE;
                                }

                                if (MapDatas.Any(x => x.GroupCode == MapData.GroupCode &&
                                                      x.JobNo == MapData.JobNo &&
                                                      x.Daily.Date == MapData.Daily)) // check if have data try to plus it
                                {
                                    var updateManHour = MapDatas.FirstOrDefault(x => 
                                                              x.GroupCode == MapData.GroupCode &&
                                                              x.JobNo == MapData.JobNo &&
                                                              x.Daily.Date == MapData.Daily);

                                    updateManHour.TotalManHour += MapData.TotalManHour;
                                    updateManHour.TotalManHourNTOT += MapData.TotalManHourNTOT;
                                    updateManHour.TotalManHourOT += MapData.TotalManHourOT;
                                }
                                else // else add it to list
                                    MapDatas.Add(MapData);
                            }
                        }
                        // Get Employee total time by date from sub
                        var HasSubTime = await this.repositoryEmpTimeSub.GetToListAsync(x => x,
                           x => conditionGroup.Contains(x.GroupMIS) &&
                                x.WorkDate >= option.SDate.Value.Date &&
                                x.WorkDate <= option.EDate.Value.Date &&
                                x.WorkDate != null
                           , x => x.OrderBy(z => z.WorkDate));

                        if (HasSubTime != null)
                        {
                            foreach (var itemS in HasSubTime)
                            {
                                var MapDataSub = this.mapper.Map<EmpTimeSubView, ActualDaily>(itemS);
                                var WorkNickSub = planWorkGroup.FirstOrDefault(x => x.GroupCode == MapDataSub.GroupCode);

                                if (WorkNickSub.ReferenceGroupCode != null && !string.IsNullOrEmpty(WorkNickSub.ReferenceGroupCode)) // If have change this group to other group
                                {
                                    MapDataSub.GroupCode = WorkNickSub?.ReferenceGroupCode ?? "-";
                                    MapDataSub.ActualDetailType = ActualDetailType.VIPCO;
                                }
                                else
                                    MapDataSub.ActualDetailType = ActualDetailType.SUBCONTRACTOR;

                                if (MapDatas.Any(x => x.GroupCode == MapDataSub.GroupCode &&
                                                      x.JobNo == MapDataSub.JobNo &&
                                                      x.Daily.Date == MapDataSub.Daily)) // check if have data try to plus it
                                {
                                    var updateManHourSub = MapDatas.FirstOrDefault(x =>
                                                              x.GroupCode == MapDataSub.GroupCode &&
                                                              x.JobNo == MapDataSub.JobNo &&
                                                              x.Daily.Date == MapDataSub.Daily);

                                    updateManHourSub.TotalManHour += MapDataSub.TotalManHour;
                                    updateManHourSub.TotalManHourNTOT += MapDataSub.TotalManHourNTOT;
                                    updateManHourSub.TotalManHourOT += MapDataSub.TotalManHourOT;
                                }
                                else // else add it to list
                                {
                                    if (WorkNickSub != null)
                                    {
                                        var CurWorkShopSub = workShop?.FirstOrDefault(x => x.GroupMis == MapDataSub.GroupCode);

                                        if (CurWorkShopSub != null)
                                        {
                                            MapDataSub.WorkShop = CurWorkShopSub?.WorkShop?.WorkShopName ?? "-";
                                            MapDataSub.GroupName = CurWorkShopSub?.GroupMisNavigation?.GroupDesc ?? "-";
                                        }
                                        else
                                        {
                                            var groupMis = await this.repositoryWorkGroup.
                                                GetFirstOrDefaultAsync(x => x, x => x.GroupMis == MapDataSub.GroupCode);
                                            MapDataSub.GroupName = groupMis?.GroupDesc ?? "-";
                                        }
                                      

                                        MapDataSub.NickName = WorkNickSub?.NickName ?? MapDataSub.GroupName;
                                        MapDataSub.ActualDetailType = ActualDetailType.VIPCO;
                                        MapDataSub.ActualType = WorkNickSub?.ActualType ?? ActualType.NONE;
                                    }

                                    MapDatas.Add(MapDataSub);
                                }
                            }
                        }

                        if (MapDatas.Any())
                            return new JsonResult(MapDatas.OrderBy(z => z.Daily).ThenBy(z => z.JobNo), this.DefaultJsonSettings);
                    }
                }
            }
            catch(Exception ex)
            {
                message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = message });
        }
    }
}
