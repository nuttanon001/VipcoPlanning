using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.Models.Planning
{
    public class BomTotalManHourView
    {
        public string JobNo { get; set; }
        public string ItemCode { get; set; }
        public string GroupCode { get; set; }
        public double? TotalWorkTime { get; set; }
        public double? TotalWorkTimeOverTime { get; set; }
        public double? TotalOverTime { get; set; }
    }
}
