using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class PlanShipment:BaseModel
    {
        [Key]
        public int PlanShipmentId { get; set; }
        public DateTime? DateShipment { get; set; }
        public int? SequenceNo { get; set; }
        //FK
        //PlanMaster
        public int? PlanMasterId { get; set; }
        public PlanMaster PlanMaster { get; set; }
    }
}
