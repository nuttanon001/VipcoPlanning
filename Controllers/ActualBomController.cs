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
    public class ActualBomController : GenericPlanningController<ActualBom>
    {
        private readonly IRepositoryPlanning<BillofMaterial> repositoryBom;
        // GET: api/ActualBom
        public ActualBomController(IRepositoryPlanning<ActualBom> repo,
            IRepositoryPlanning<BillofMaterial> repoBom,
            IMapper mapper) : base(repo, mapper)
        {
            this.repositoryBom = repoBom;
        }

        // GET: api/ActualDetail/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.ActualMasterId == key, z => z.OrderBy(x => x.BomCode));
            if (HasData.Any())
                return new JsonResult(HasData, this.DefaultJsonSettings);
            else
                return NoContent();
        }
    }
}
