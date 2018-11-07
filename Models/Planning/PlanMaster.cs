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
        [StringLength(500)]
        public string ManagementName { get; set; }
        //Relation
        //ProjectCodeMaster
        public int? ProjectCodeMasterId { get; set; }
        //EmpCode
        [StringLength(50)]
        public string ManagementBy { get; set; }
        //PlanDetail
        public virtual ICollection<PlanDetail> PlanDetails { get; set; } = new List<PlanDetail>();
        //PlanShipment
        public virtual ICollection<PlanShipment> PlanShipments { get; set; } = new List<PlanShipment>();
        public virtual HistoryPlanMaster HistoryPlanMaster { get; set; }
    }

    public enum PlanningStatus
    {
        InProcess = 1,
        Complate,
        Cancel,
    }
}
