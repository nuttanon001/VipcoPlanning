using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class ActualMaster:BaseModel
    {
        [Key]
        public int ActualMasterId { get; set; }
        [StringLength(200)]
        public string ProjectName { get; set; }
        public double? OverTimemultiply { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public PlanningStatus? ActualStatus { get; set; }
        public int? ProjectCodeMasterId { get; set; }
        //Relation
        // PlanMaster
        public int? PlanMasterId { get; set; }
        // ActualDetail
        public virtual ICollection<ActualDetail> ActualDetails { get; set; } = new List<ActualDetail>();
        public virtual ICollection<ActualBom> ActualBoms { get; set; } = new List<ActualBom>();
    }
}
