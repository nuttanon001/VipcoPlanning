using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.ViewModels
{
    public class SummanyReportViewModel
    {
        public int? PlanMasterId { get; set; }
        public int? JobNumber { get; set; }
        public string WorkGroup { get; set; }
        public string Where { get; set; }
        public int? BomLevel {get;set;}
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }

    public class SummanyDataPlanVsActual
    {


        public string WorkShopName { get; set; }
        public string WorkGroup { get; set; }
        public string Item { get; set; }
        public double? Weight { get; set; }
        public double? FabKiloPerHour => Weight > 0 && FabManHour > 0 ? (Weight*1000) / FabManHour : 0;
        public double? FabRateManHour { get; set; }
        public double? EngManHour { get; set; }
        public double? FabManHour { get; set; }
        public double? PackManHour { get; set; }
        public double? WeldManHour { get; set; }
    }
}
