using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class StandardTime:BaseModel
    {
        [Key]
        public int StandardTimeId { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public double? Rate { get; set; }
        [StringLength(20)]
        public string RateUnit { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        public string Remark { get; set; }
        //Relation
        //GroupStandardTime
        public virtual GroupStandardTime GroupStandardTime { get; set; }
        public int? GroupStandardId { get; set; }
        // StandardTimeForWorkGroup
        public virtual StandardTimeForWorkGroup StandardTimeForWorkGroup { get; set; }
        public int? StandardTimeForId { get; set; }

    }
}
