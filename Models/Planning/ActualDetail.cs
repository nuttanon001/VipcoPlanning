using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class ActualDetail:BaseModel
    {
        [Key]
        public int ActualDetailId { get; set; }
        [StringLength(50)]
        public string GroupCode { get; set; }
        [StringLength(200)]
        public string GroupName { get; set; }
        [StringLength(50)]
        public string WorkShop { get; set; }
        [StringLength(200)]
        public string NickName { get; set; }
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
    public enum ActualType
    {
        FABRICATE = 1,
        ENGINEERING,
        MACHINE,
        WELD,
        PAINT,
        INSULATION,
        PACK,
        NONE,
    }

    public enum ActualDetailType
    {
        VIPCO = 1,
        SUBCONTRACTOR
    }
}
