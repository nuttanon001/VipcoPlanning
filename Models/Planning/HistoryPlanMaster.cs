using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class HistoryPlanMaster:BaseModel
    {
        [Key]
        public int HistoryPlanMasterId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        //Relation
        //PlanningProjectMaster
        public int? PlanMasterId { get; set; }
        public virtual PlanMaster PlanMaster { get; set; }
    }
}
