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
using VipcoPlanning.Models.Planning;
using AutoMapper;
using VipcoPlanning.Helper;

namespace VipcoPlanning.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeeGroupMisController : GenericMachineController<EmployeeGroupMis>
    {
        public EmployeeGroupMisController(IRepositoryMachine<EmployeeGroupMis> repo,
            IMapper mapper) : base(repo,mapper) {
        }

        // POST: api/EmployeeGroupMis/GetScroll
        [HttpPost("GetScroll")]
        public async Task<IActionResult> GetScroll([FromBody] ScrollViewModel Scroll)
        {
            if (Scroll == null)
                return BadRequest();
            // Filter
            var filters = string.IsNullOrEmpty(Scroll.Filter) ? new string[] { "" }
                                : Scroll.Filter.Split(null);

            var predicate = PredicateBuilder.False<EmployeeGroupMis>();

            foreach (string temp in filters)
            {
                string keyword = temp;
                predicate = predicate.Or(x => x.GroupDesc.ToLower().Contains(keyword) ||
                                              x.GroupMis.ToLower().Contains(keyword) ||
                                              x.Remark.ToLower().Contains(keyword));
            }
            //if (!string.IsNullOrEmpty(Scroll.Where))
            //    predicate = predicate.And(p => p.Creator == Scroll.Where);
            // Order by
            Func<IQueryable<EmployeeGroupMis>, IOrderedQueryable<EmployeeGroupMis>> order;
            // Order
            switch (Scroll.SortField)
            {
                case "GroupMis":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.GroupMis);
                    else
                        order = o => o.OrderBy(x => x.GroupMis);
                    break;
                case "GroupDesc":
                    if (Scroll.SortOrder == -1)
                        order = o => o.OrderByDescending(x => x.GroupDesc);
                    else
                        order = o => o.OrderBy(x => x.GroupDesc);
                    break;
                default:
                    order = o => o.OrderByDescending(x => x.GroupDesc);
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
            return new JsonResult(new ScrollDataViewModel<EmployeeGroupMis>(Scroll, QueryData.ToList()), this.DefaultJsonSettings);
        }

        [HttpGet("GroupMisByEmpCode")]
        public async Task<IActionResult> GetGroupMisByEmpCode(string EmpCode)
        {
            var HasData = await this.repository.GetFirstOrDefaultAsync(x => x, x => x.Employee.Any(z => z.EmpCode == EmpCode));
            return new JsonResult(HasData, this.DefaultJsonSettings);
        }
    }
}
