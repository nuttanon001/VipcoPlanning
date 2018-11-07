using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class ActualBom:BaseModel
    {
        [Key]
        public int ActualBomId { get; set; }
        [StringLength(50)]
        public string BomCode { get; set; }
        [StringLength(200)]
        public string BomName { get; set; }
        [StringLength(50)]
        public string GroupCode { get; set; }
        public double? TotalManHour { get; set; }
        public double? TotalManHourOT { get; set; }
        public double? TotalManHourNTOT { get; set; }
        public double? WeightPlan { get; set; }
        public double? TotalPlanManHour { get; set; }
        public ActualType? ActualType { get; set; }
        public ActualDetailType? ActualDetailType { get; set; }
        // FK
        // ActualMasterId
        public int? ActualMasterId { get; set; }
        public ActualMaster ActualMaster { get; set; }
    }
}
