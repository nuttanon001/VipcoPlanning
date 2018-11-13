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
    public class StandardTimeController : GenericPlanningController<StandardTime>
    {
        public StandardTimeController(IRepositoryPlanning<StandardTime> repo,
          IMapper mapper) :
          base(repo, mapper)
        { }

        // GET: api/StandardTime/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetAsync(key,true);
            return new JsonResult(this.mapper.Map<StandardTime,StandardTimeViewModel>(HasData), this.DefaultJsonSettings);
        }

        //// GET: api/StandardTime/GetRateMaster/
        [HttpGet("GetRateMaster")]
        public async Task<IActionResult> GetRateMaster(string ModifiedBy)
        {
            var message = "Data not been found.";
            try
            {
                var HasData = await this.repository.GetToListAsync(x => x, x => x.Rate != x.RateMaster);
                if (HasData != null)
                {
                    foreach (var item in HasData)
                    {
                        item.Rate = item.RateMaster;
                        item.ModifyDate = DateTime.Now;
                        item.Modifyer = ModifiedBy;

                        await this.repository.UpdateAsync(item, item.StandardTimeId);
                    }

                    return new JsonResult(new { Result = true }, this.DefaultJsonSettings);
                }
            }
            catch (Exception ex)
            {
                message = $"Has error {ex.ToString()}";
            }
            return BadRequest(new { Error = message });
        }

        // POST: api/StandardTime/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();

            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<StandardTime>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.GroupStandardTime.Name.ToLower().Contains(keyword) ||
                                                x.GroupStandardTime.Description.ToLower().Contains(keyword) ||
                                                x.Code.ToLower().Contains(keyword) ||
                                                x.Name.ToLower().Contains(keyword) ||
                                                x.Description.ToLower().Contains(keyword) ||
                                                x.StandardTimeForWorkGroup.Name.ToLower().Contains(keyword) ||
                                                x.StandardTimeForWorkGroup.Description.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<StandardTime>, IOrderedQueryable<StandardTime>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "Code":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Code);
                    else
                        order = o => o.OrderBy(x => x.Code);
                    break;
                case "Name":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Name);
                    else
                        order = o => o.OrderBy(x => x.Name);
                    break;
                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
                    break;
                case "RateUnit":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.RateUnit);
                    else
                        order = o => o.OrderBy(x => x.RateUnit);
                    break;
                case "Rate":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Rate);
                    else
                        order = o => o.OrderBy(x => x.Rate);
                    break;
                case "GroupStandardString":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.GroupStandardTime.Name);
                    else
                        order = o => o.OrderBy(x => x.GroupStandardTime.Name);
                    break;
                case "ForWorkGroupString":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.StandardTimeForWorkGroup.Name);
                    else
                        order = o => o.OrderBy(x => x.StandardTimeForWorkGroup.Name);
                    break;
                default:
                    order = o => o.OrderBy(x => x.Code);
                    break;
            }

            var QueryData = await this.repository.GetToListAsync(
                                    selector: selected => selected,  // Selected
                                    predicate: predicate, // Where
                                    orderBy: order, // Order
                                    include: x => x.Include(z => z.GroupStandardTime).Include(z => z.StandardTimeForWorkGroup), // Include
                                    skip: Scroll.Skip ?? 0, // Skip
                                    take: Scroll.Take ?? 10); // Take

            // Get TotalRow
            Scroll.TotalRow = await this.repository.GetLengthWithAsync(predicate: predicate);

            var mapDatas = new List<StandardTimeViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<StandardTime, StandardTimeViewModel>(item);
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<StandardTimeViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }
    }
}