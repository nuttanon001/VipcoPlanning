using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.Models.Planning
{
    public class WorkGroupTotalManHourSubView
    {
        public string JobNo { get; set; }
        public string GroupMIS { get; set; }
        public string GroupName { get; set; }
        public double? TotalWorkTime { get; set; }
        public double? TotalWorkTimeOverTime { get; set; }
        public double? TotalOverTime { get; set; }
    }
}
