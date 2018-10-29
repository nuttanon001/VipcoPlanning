using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VipcoPlanning.Models.Planning
{
    public class GroupStandardTime:BaseModel
    {
        [Key]
        public int GroupStandardId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        //Relateion
    }
}
