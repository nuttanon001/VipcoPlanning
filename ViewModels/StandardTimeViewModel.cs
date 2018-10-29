using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
namespace VipcoPlanning.ViewModels
{
    public class StandardTimeViewModel:StandardTime
    {
        public string GroupStandardString { get; set; }
        public string ForWorkGroupString { get; set; }
    }
}
