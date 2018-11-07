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
    public class PlanDetailController : GenericPlanningController<PlanDetail>
    {
        private readonly IRepositoryMachine<Employee> repositoryEmp;
        private readonly IRepositoryMachine<EmployeeGroup> repositoryWorkGroup;
        private readonly IRepositoryPlanning<EngineerManHour> repositoryEngMH;
        private readonly IRepositoryPlanning<FabricationManHour> repositoryFabMH;
        private readonly IRepositoryPlanning<PackingManHour> repositoryPakMH;
        private readonly IRepositoryPlanning<WeldManHour> repositoryWedMH;
        private readonly IRepositoryPlanning<PlanMaster> repositoryPlanMaster;
        public PlanDetailController(IRepositoryPlanning<PlanDetail> repo,
            IRepositoryPlanning<PlanMaster> repoPlanMaster,
            IRepositoryPlanning<EngineerManHour> repoEngMH,
            IRepositoryPlanning<FabricationManHour> repoFabMM,
            IRepositoryPlanning<PackingManHour> repoPakMH,
            IRepositoryPlanning<WeldManHour> repoWedMH,
            IRepositoryMachine<Employee> repoEmp,
            IRepositoryMachine<EmployeeGroup> repoWorkGroup,
            IMapper mapper) : base(repo, mapper)
        {
            // RepositoryPlanning
            this.repositoryPlanMaster = repoPlanMaster;
            this.repositoryEngMH = repoEngMH;
            this.repositoryFabMH = repoFabMM;
            this.repositoryPakMH = repoPakMH;
            this.repositoryWedMH = repoWedMH;
            // RepositoryMachine
            this.repositoryEmp = repoEmp;
            this.repositoryWorkGroup = repoWorkGroup;
        }

        // GET: api/controller/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(
                x => x,x => x.PlanDetailId == key,null,
                x => x.Include(z => z.EngineerManHour)
                      .Include(z => z.FabricationManHour)
                      .Include(z => z.PackingManHour)
                      .Include(z => z.WeldManHour));
            if (HasData == null) return BadRequest(new { Error = "Data not been found." });

            var MapData = this.mapper.Map<PlanDetail, PlanDetailViewModel>(HasData);
            if (HasData.EngineerManHour != null)
                MapData.EngineerManHour = this.mapper.Map<EngineerManHour, EngineerManHourViewModel>(HasData.EngineerManHour);
            if (HasData.FabricationManHour != null)
                MapData.FabricationManHour = this.mapper.Map<FabricationManHour, FabricationManHourViewModel>(HasData.FabricationManHour);
            if (HasData.PackingManHour != null)
                MapData.PackingManHour = this.mapper.Map<PackingManHour, PackingManHourViewModel>(HasData.PackingManHour);
            if (HasData.WeldManHour != null)
                MapData.WeldManHour = this.mapper.Map<WeldManHour, WeldManHourViewModel>(HasData.WeldManHour);

            return new JsonResult(MapData, this.DefaultJsonSettings);
        }

        // GET: api/PlanDetail/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var Message = "";
            try
            {
                if (key > 0)
                {
                    var HasData = await this.repository.GetToListAsync(
                        x => x, x => x.PlanMasterId == key,
                        null,x => x.Include(z => z.BillofMaterial)
                                    .Include(z => z.EngineerManHour)
                                    .Include(z => z.FabricationManHour)
                                    .Include(z => z.PackingManHour)
                                    .Include(z => z.WeldManHour));
                    if (HasData.Any())
                    {
                        var MapData = new List<PlanDetail>();
                        foreach (var item in HasData)
                        {
                            var Map = this.mapper.Map<PlanDetail, PlanDetailViewModel>(item);
                            if (!string.IsNullOrEmpty(Map.ResponsibilityBy))
                                Map.ResponsibilityByString = (await this.repositoryEmp.GetAsync(Map.ResponsibilityBy))?.NameThai ?? "-";
                            if (!string.IsNullOrEmpty(Map.AssignmentToGroup))
                                Map.AssignmentToGroupString = (await this.repositoryWorkGroup.GetAsync(Map.AssignmentToGroup))?.Description ?? "-";
                            MapData.Add(Map);
                        }
                        return new JsonResult(MapData, this.DefaultJsonSettings);
                    }
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = "Key not been found." });
        }
       
        // POST: api/PlanDetail/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();

            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<PlanDetail>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.Code.ToLower().Contains(keyword) ||
                                              x.Description.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<PlanDetail>, IOrderedQueryable<PlanDetail>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "Code":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Code);
                    else
                        order = o => o.OrderBy(x => x.Code);
                    break;
                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
                    break;
                default:
                    order = o => o.OrderBy(x => x.Code);
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

            var mapDatas = new List<PlanDetailViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<PlanDetail, PlanDetailViewModel>(item);
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<PlanDetailViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }

        // PUT: api/PlanDetail/5
        [HttpPut]
        public override async Task<IActionResult> Update(int key, [FromBody] PlanDetail record)
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

            if (record.EngineerManHour != null)
            {
                if (record.EngineerManHourId > 0)
                {
                    record.EngineerManHour.ModifyDate = record.ModifyDate;
                    record.EngineerManHour.Modifyer = record.Modifyer;

                    await this.repositoryEngMH.UpdateAsync(record.EngineerManHour, record.EngineerManHour.EngineerManHourId);
                }
                //else
                //{
                //    record.EngineerManHour.CreateDate = record.ModifyDate;
                //    record.EngineerManHour.Creator = record.Modifyer;

                //    await this.repositoryEngMH.AddAsync(record.EngineerManHour);
                //    record.EngineerManHourId = record.EngineerManHour.EngineerManHourId;
                //}
            }

            if (record.FabricationManHour != null)
            {
                if (record.FabricationManHourId > 0)
                {
                    record.FabricationManHour.ModifyDate = record.ModifyDate;
                    record.FabricationManHour.Modifyer = record.Modifyer;

                    await this.repositoryFabMH.UpdateAsync(record.FabricationManHour, record.FabricationManHour.FabricationManHourId);
                }
                //else
                //{
                //    record.FabricationManHour.CreateDate = record.ModifyDate;
                //    record.FabricationManHour.Creator = record.Modifyer;

                //    await this.repositoryFabMH.AddAsync(record.FabricationManHour);
                //    record.FabricationManHourId = record.FabricationManHour.FabricationManHourId;
                //}
            }

            if (record.PackingManHour != null)
            {
                if (record.PackingManHourId > 0)
                {
                    record.PackingManHour.ModifyDate = record.ModifyDate;
                    record.PackingManHour.Modifyer = record.Modifyer;

                    await this.repositoryPakMH.UpdateAsync(record.PackingManHour, record.PackingManHour.PackingManHourId);
                }
                //else
                //{
                //    record.PackingManHour.CreateDate = record.ModifyDate;
                //    record.PackingManHour.Creator = record.Modifyer;

                //    await this.repositoryPakMH.AddAsync(record.PackingManHour);
                //    record.PackingManHourId = record.PackingManHour.PackingManHourId;
                //}
            }

            if (record.WeldManHour != null)
            {
                if (record.WeldManHourId > 0)
                {
                    record.WeldManHour.ModifyDate = record.ModifyDate;
                    record.WeldManHour.Modifyer = record.Modifyer;

                    await this.repositoryWedMH.UpdateAsync(record.WeldManHour, record.WeldManHour.WeldManHourId);
                }
                //else
                //{
                //    record.WeldManHour.CreateDate = record.ModifyDate;
                //    record.WeldManHour.Creator = record.Modifyer;

                //    await this.repositoryWedMH.AddAsync(record.WeldManHour);
                //    record.WeldManHourId = record.WeldManHour.WeldManHourId;
                //}
            }

            if (await this.repository.UpdateAsync(record, key) == null)
                return BadRequest();

            return new JsonResult(record, this.DefaultJsonSettings);
        }
    }
}