using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoPlanning.Models.Planning
{
    public class PackingManHour:BaseModel
    {
        [Key]
        public int PackingManHourId { get; set; }
        public double? PackingWeight { get; set; }
        //Packing
        public double? PackingMH { get; set; }
        //Relation
        [ForeignKey("Packing")]
        public int? PackingId { get; set; }
        public virtual StandardTime Packing { get; set; }
    }
}
