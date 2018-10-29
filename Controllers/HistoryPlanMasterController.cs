using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using VipcoPlanning.Models.Planning;
using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;

using AutoMapper;
using VipcoPlanning.Helper;

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryPlanMasterController : GenericPlanningController<HistoryPlanMaster>
    {
        public HistoryPlanMasterController(IRepositoryPlanning<HistoryPlanMaster> repo,
          IMapper mapper) :
          base(repo, mapper)
        { }

        // POST: api/HistoryPlanMaster/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<HistoryPlanMaster>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.PlanMaster.ProjectName.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<HistoryPlanMaster>, IOrderedQueryable<HistoryPlanMaster>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ProjectName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.PlanMaster.ProjectName);
                    else
                        order = o => o.OrderBy(x => x.PlanMaster.ProjectName);
                    break;
                case "ValidFrom":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ValidFrom);
                    else
                        order = o => o.OrderBy(x => x.ValidFrom);
                    break;
                case "ValidTo":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ValidTo);
                    else
                        order = o => o.OrderBy(x => x.ValidTo);
                    break;
                default:
                    order = o => o.OrderBy(x => x.ValidTo);
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

            var mapDatas = new List<HistoryPlanMasterViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<HistoryPlanMaster, HistoryPlanMasterViewModel>(item);
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<HistoryPlanMasterViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }
    }
}