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
    public class ActualDetailController : GenericPlanningController<ActualDetail>
    {
        private readonly IRepositoryMachine<EmployeeGroupMis> repositoryWorkGroup;
        // GET: api/ActualDetail
        public ActualDetailController(IRepositoryPlanning<ActualDetail> repo,
            IRepositoryMachine<EmployeeGroupMis> repoWorkGroup,IMapper mapper)
            : base(repo,mapper)
        {
            // Repository
            this.repositoryWorkGroup = repoWorkGroup;
        }

        // GET: api/ActualDetail/GetByMaster/5
        [HttpGet("GetByMaster")]
        public async Task<IActionResult> GetByMaster(int key)
        {
            var HasData = await this.repository.GetToListAsync(
                            x => x, e => e.ActualMasterId == key, z => z.OrderBy(x => x.GroupCode));
            if (HasData.Any())
            {
                var MapDatas = new List<ActualDetailViewModel>();
                foreach (var item in HasData)
                    MapDatas.Add(this.mapper.Map<ActualDetail, ActualDetailViewModel>(item));
                return new JsonResult(MapDatas, this.DefaultJsonSettings);
            }
            else
                return NoContent();
        }
    }
}
