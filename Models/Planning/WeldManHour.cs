using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoPlanning.Models.Planning
{
    public class WeldManHour:BaseModel
    {
        [Key]
        public int WeldManHourId { get; set; }
        public double? WeldWetght { get; set; }
        //Weld
        public double? WeldMH { get; set; }
        //Relation
        //StadardTime-Weld
        [ForeignKey("Weld")]
        public int? WeldId { get; set; }
        public virtual StandardTime Weld { get; set; }
    }
}
