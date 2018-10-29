using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class PlanMaster:BaseModel
    {
        [Key]
        public int PlanMasterId { get; set; }
        [StringLength(200)]
        public string ProjectName { get; set; }
        public int? Revised { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public PlanningStatus? PlanningStatus { get; set; }
        //Relation
        //ProjectCodeMaster
        public int? ProjectCodeMasterId { get; set; }
        //EmpCode
        [StringLength(50)]
        public string ManagementBy { get; set; }
        //PlanningProjectDetail
        public virtual ICollection<PlanDetail> PlanDetails { get; set; } = new List<PlanDetail>();
        public virtual HistoryPlanMaster HistoryPlanMaster { get; set; }
    }

    public enum PlanningStatus
    {
        InProcess = 1,
        Complate,
        Cancel,
    }
}
