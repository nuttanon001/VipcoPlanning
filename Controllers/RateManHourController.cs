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
    public class RateManHourController : GenericPlanningController<RateManHour>
    {
        public RateManHourController(IRepositoryPlanning<RateManHour> repo, IMapper mapper) : base(repo, mapper)
        { }

        // GET: api/RateManHour/GetKeyNumber/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetAsync(key,true);
            return new JsonResult(this.mapper.Map<RateManHour,RateManHourViewModel>(HasData), this.DefaultJsonSettings);
        }

        // POST: api/RateManHour/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();

            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<RateManHour>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.StandardTimeForWorkGroup.Name.ToLower().Contains(keyword) ||
                                              x.StandardTimeForWorkGroup.Description.ToLower().Contains(keyword) ||
                                              x.Description.ToLower().Contains(keyword));
            }
            if (!string.IsNullOrEmpty(Scroll.Where))
                predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<RateManHour>, IOrderedQueryable<RateManHour>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "ForWorkGroupString":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.StandardTimeForWorkGroup.Name);
                    else
                        order = o => o.OrderBy(x => x.StandardTimeForWorkGroup.Name);
                    break;
                case "Rate":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.RateBathPerManHour);
                    else
                        order = o => o.OrderBy(x => x.RateBathPerManHour);
                    break;
                case "Description":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.Description);
                    else
                        order = o => o.OrderBy(x => x.Description);
                    break;
                default:
                    order = o => o.OrderBy(x => x.StandardTimeForWorkGroup.Name);
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

            var mapDatas = new List<RateManHourViewModel>();
            foreach (var item in QueryData)
            {
                var MapItem = this.mapper.Map<RateManHour, RateManHourViewModel>(item);
                mapDatas.Add(MapItem);
            }

            return new JsonResult(new ScrollDataViewModel<RateManHourViewModel>(Scroll, mapDatas), this.DefaultJsonSettings);
        }


        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] RateManHour record)
        {
            // Set date for CrateDate Entity
            if (record == null)
                return BadRequest();
            // +7 Hour
            record = this.helper.AddHourMethod(record);
            record.ValidFrom = DateTime.Now;

            // Update revised
            var lastRateManHours = await this.repository.GetToListAsync(x => x,
                x => x.StandardTimeForId == record.StandardTimeForId && x.ValidTo == null);

            if (lastRateManHours != null && lastRateManHours.Any())
            {
                foreach (var item in lastRateManHours)
                {
                    item.ValidTo = DateTime.Now;
                    item.ModifyDate = DateTime.Now;
                    item.Modifyer = record.Creator;
                };
            }

            if (record.GetType().GetProperty("CreateDate") != null)
                record.GetType().GetProperty("CreateDate").SetValue(record, DateTime.Now);
            if (await this.repository.AddAsync(record) == null)
                return BadRequest();

            if (lastRateManHours != null && lastRateManHours.Any())
            {
                foreach (var item in lastRateManHours)
                    await this.repository.UpdateAsync(item, item.RateManHourId);
            }

            return new JsonResult(record, this.DefaultJsonSettings);
        }
    }
}
