using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoPlanning.Models.Planning
{
    public class FabricationManHour:BaseModel
    {
        [Key]
        public int FabricationManHourId { get; set; }
        public double? FabricationWeight { get; set; }
        //Fabrication
        public double? FabricationMH { get; set; }
        //PerAssembly
        public double? PerAssemblyMH { get; set; }
        //Relation
        //StadardTime-Fabrication
        [ForeignKey("Fabrication")]
        public int? FabricationId { get; set; }
        public virtual StandardTime Fabrication { get; set; }
        //StadardTime-PerAssembly
        [ForeignKey("PerAssembly")]
        public int? PerAssemblyId { get; set; }
        public virtual StandardTime PerAssembly { get; set; }
    }
}
