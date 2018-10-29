using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.ViewModels
{
    public class OptionChartViewModel
    {
        public DateTime? SDate { get; set; }
        public DateTime? EDate { get; set; }
        public int? PlanMasterId { get; set; }
        public string Filter { get; set; }
    }
}
