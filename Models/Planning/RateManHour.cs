using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class RateManHour:BaseModel
    {
        [Key]
        public int RateManHourId { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public double? RateBathPerManHour { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        // Relation
        public int? StandardTimeForId { get; set; }
        public virtual StandardTimeForWorkGroup StandardTimeForWorkGroup { get; set; }
    }
}
