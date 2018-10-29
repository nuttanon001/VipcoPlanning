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

namespace VipcoPlanning.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeeController : GenericMachineController<Employee>
    {
        // Mapper
        public EmployeeController(IRepositoryMachine<Employee> repo,
            IMapper mapper) : base(repo,mapper) {
        }
       
    }
}
