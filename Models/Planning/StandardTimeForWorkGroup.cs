using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class StandardTimeForWorkGroup:BaseModel
    {
        [Key]
        public int StandardTimeForId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        //Relation
        //StandardTimes
        public virtual ICollection<StandardTime> StandardTimes { get; set; }
        //RateManHour
        public virtual ICollection<RateManHour> RateManHours { get; set; }
    }
}
