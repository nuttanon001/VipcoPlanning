using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using VipcoPlanning.Services;
using VipcoPlanning.ViewModels;
using VipcoPlanning.Models.Machines;
using AutoMapper;
using VipcoPlanning.Helper;

namespace VipcoPlanning.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProjectCodeMasterController : GenericMachineController<ProjectCodeMaster>
    {
        public ProjectCodeMasterController(IRepositoryMachine<ProjectCodeMaster> repo,
            IMapper mapper) : base(repo,mapper) { }

        // POST: api/Branch/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();

            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<ProjectCodeMaster>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.ProjectCode.ToLower().Contains(keyword) ||
                                              x.ProjectName.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<ProjectCodeMaster>, IOrderedQueryable<ProjectCodeMaster>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ProjectCode":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ProjectCode);
                    else
                        order = o => o.OrderBy(x => x.ProjectCode);
                    break;
                case "ProjectName":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.ProjectName);
                    else
                        order = o => o.OrderBy(x => x.ProjectName);
                    break;
                default:
                    order = o => o.OrderBy(x => x.CreateDate);
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

            var mapDatas = new List<ProjectMasterViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<ProjectCodeMaster, ProjectMasterViewModel>(item);
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<ProjectMasterViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }
    }
}
