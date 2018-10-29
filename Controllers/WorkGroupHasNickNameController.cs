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
    public class WorkGroupHasNickNameController : GenericPlanningController<WorkGroupHasNickName>
    {
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryGroup;
        // GET: api/WorkGroupHasNickName
        public WorkGroupHasNickNameController(IRepositoryPlanning<WorkGroupHasNickName> repo,
            IRepositoryMachine<EmployeeGroupMis> repoGroup,
            IMapper mapper)
            :base(repo,mapper)
        {
            this.repositoryGroup = repoGroup;
        }

        // GET: api/ActualMaster/GetKeyNumber/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x,x => x.WorkGroupNickNameId == key);
            if (HasData != null)
            {
                var MapData = this.mapper.Map<WorkGroupHasNickName, NickNameViewModel>(HasData);
                if (!string.IsNullOrEmpty(MapData.GroupCode))
                    MapData.GroupName = await this.repositoryGroup.GetFirstOrDefaultAsync(x => x.GroupDesc,x => x.GroupMis == MapData.GroupCode) ?? "-";
                if (!string.IsNullOrEmpty(MapData.ReferenceGroupCode))
                    MapData.ReferenceName = await this.repositoryGroup.GetFirstOrDefaultAsync(x => x.GroupDesc,x => x.GroupMis == MapData.ReferenceGroupCode) ?? "-";
                return new JsonResult(MapData, this.DefaultJsonSettings);
            }
            return NoContent();
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

            var predicate = PredicateBuilder.False<WorkGroupHasNickName>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.GroupCode.ToLower().Contains(keyword) ||
                                              x.NickName.ToLower().Contains(keyword) ||
                                              x.ReferenceGroupCode.ToLower().Contains(keyword));

            }

            //if (!string.IsNullOrEmpty(Scroll.Where))
            //    predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<WorkGroupHasNickName>, IOrderedQueryable<WorkGroupHasNickName>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "GroupCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.GroupCode);
                    else
                        order = o => o.OrderBy(x => x.GroupCode);
                    break;
                case "NickName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.NickName);
                    else
                        order = o => o.OrderBy(x => x.NickName);
                    break;
                case "ReferenceGroupCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ReferenceGroupCode);
                    else
                        order = o => o.OrderBy(x => x.ReferenceGroupCode);
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

            var AllGroup = await this.repositoryGroup.GetToListAsync(x => new { x.GroupMis,x.GroupDesc});

            var mapDatas = new List<NickNameViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<WorkGroupHasNickName, NickNameViewModel>(item);
                if (!string.IsNullOrEmpty(MapItem.GroupCode))
                    MapItem.GroupName = AllGroup.FirstOrDefault(x => x.GroupMis == MapItem.GroupCode).GroupDesc ?? "-";
                if (!string.IsNullOrEmpty(MapItem.ReferenceGroupCode))
                    MapItem.ReferenceName = AllGroup.FirstOrDefault(x => x.GroupMis == MapItem.ReferenceGroupCode).GroupDesc ?? "-";

                mapDatas.Add(MapItem);
            }
            return new JsonResult(new ScrollDataViewModel<NickNameViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }

    }
}
