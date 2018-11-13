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
    public class ActualDailyController : GenericPlanningController<ActualDaily>
    {
        // GET: api/ActualDaily
        public ActualDailyController(IRepositoryPlanning<ActualDaily> repo,
             IMapper mapper)
            : base(repo, mapper)
        { }

        // POST: api/ActualDaily/CreateAndUpdate
        [HttpPost("CreateAndUpdate")]
        public async Task<IActionResult> CreateAndUpdateMulit([FromBody] List<ActualDaily> records)
        {
            var Message = "Data not been found.";
            try
            {
                if (records != null && records.Any())
                {
                    foreach (var item in records)
                    {

                        var hasData = await this.repository.GetFirstOrDefaultAsync(x => x,
                            x => x.Daily.Date == item.Daily.Date && 
                                 x.JobNo.ToLower().Trim() == item.JobNo.ToLower().Trim() && 
                                 x.GroupCode.ToLower().Trim() == item.GroupCode.ToLower().Trim());

                        if (hasData != null)
                        {
                            hasData.ActualDetailType = item.ActualDetailType;
                            hasData.ActualType = item.ActualType;
                            hasData.GroupName = item.GroupName;
                            hasData.NickName = item.NickName;
                            hasData.WorkShop = item.WorkShop;
                            hasData.TotalManHour = item.TotalManHour;
                            hasData.TotalManHourNTOT = item.TotalManHourNTOT;
                            hasData.TotalManHourOT = item.TotalManHourOT;
                            hasData.ModifyDate = DateTime.Now;
                            hasData.Modifyer = item.ActualDailyId > 0 ? item.Modifyer : item.Creator;

                            await this.repository.UpdateAsync(hasData, hasData.ActualDailyId);
                        }
                        else
                        {
                            item.CreateDate = DateTime.Now;
                            await this.repository.AddAsync(item);
                        }
                    }

                    return new JsonResult(new { Result = true }, this.DefaultJsonSettings);
                }
            }
            catch(Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }
            return BadRequest(new { Error = Message });
        }

        // POST: api/ActualDaily/ChartBomManHour
        [HttpPost("TableActualDaily")]
        public async Task<IActionResult> TableActualDaily([FromBody] OptionChartViewModel Option)
        {
            var Message = "";
            try
            {
                if (Option != null && Option.SDate.HasValue && Option.EDate.HasValue)
                {
                    var HasData = await this.repository.GetToListAsync(
                        x => x,
                        x => x.Daily.Date >= Option.SDate.Value.Date && 
                             x.Daily.Date <= Option.EDate.Value.Date);

                    if (HasData != null)
                    {
                        
                        #region TableData

                        var ActualFabTables = new List<ActualFabTable>();

                        foreach (var item in HasData.GroupBy(x => new { x.GroupCode , x.GroupName}))
                        {
                            ActualFabTables.Add(new ActualFabTable
                            {
                                WorkShopName = item?.FirstOrDefault()?.WorkShop ?? "-",
                                WorkGroup = item.Key.GroupName,
                                ActualMH = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourOT ?? 0)),
                                ActualMHxOT = (item.Sum(z => z.TotalManHour ?? 0)) + (item.Sum(z => z.TotalManHourNTOT ?? 0)),
                            });
                        }

                        #endregion TableData

                        return new JsonResult(new
                        {
                            ActualFabTables = ActualFabTables.OrderBy(x => x.WorkShopName).ThenBy(x => x.WorkGroup),
                        }, this.DefaultJsonSettings);
                    }
                }
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = Message });
        }
    }
}
