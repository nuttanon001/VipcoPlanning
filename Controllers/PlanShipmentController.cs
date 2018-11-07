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
    public class PlanShipmentController : GenericPlanningController<PlanShipment>
    {
        // GET: api/PlanShipment
        public PlanShipmentController(IRepositoryPlanning<PlanShipment> repo,IMapper mapper):
            base(repo, mapper)
        { }

        // GET: api/controller/5
        [HttpGet("GetKeyNumber")]
        public override async Task<IActionResult> Get(int key)
        {
            var HasData = await this.repository.GetAsync(key, true);
            if (HasData == null) return BadRequest(new { Error = "Data not been found." });
            return new JsonResult(HasData, this.DefaultJsonSettings);
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
                        x => x, x => x.PlanMasterId == key);
                    if (HasData.Any())
                        return new JsonResult(HasData, this.DefaultJsonSettings);
                    else
                        return NoContent();
                }
            }
            catch (Exception ex)
            {
                Message = $"Has error {ex.ToString()}";
            }

            return BadRequest(new { Error = "Key not been found." });
        }
    }
}
