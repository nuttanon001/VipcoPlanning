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

namespace VipcoPlanning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricationManHourController : GenericPlanningController<FabricationManHour>
    {
        public FabricationManHourController(IRepositoryPlanning<FabricationManHour> repo,
          IMapper mapper) :
          base(repo, mapper)
        { }
    }
}