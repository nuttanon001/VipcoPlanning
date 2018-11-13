using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.Models.Planning
{
    public class EmpTimeVipcoView
    {
        public string GroupCode { get; set; }
        public string JobNo { get; set; }
        public DateTime? WorkDate { get; set; }
        public double? TotalWorkTime { get; set; }
        public double? TotalOverTime { get; set; }
        public double? TotalWorkTimeOverTime { get; set; }
    }
}
