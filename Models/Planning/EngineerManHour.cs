using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using VipcoPlanning.Models.Planning;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoPlanning.Models.Planning
{
    public class EngineerManHour:BaseModel
    {
        [Key]
        public int EngineerManHourId { get; set; }
        public double? EngineerWeight { get; set; }
        //ShopDrawing
        public double? ShopDrawingMH { get; set; }
        public double? ShopDrawingCheckMH { get; set; }
        //CuttingPlan
        public double? CuttingPlanMH { get; set; }
        public double? CuttingPlanCheckMH { get; set; }
        //Packing
        public double? PackingMH { get; set; }
        public double? PackingCheckMH { get; set; }
        //Relation
        //StadardTime-ShopDrawing
        [ForeignKey("ShopDrawing")]
        public int? ShopDrawingId { get; set; }
        public virtual StandardTime ShopDrawing { get; set; }
        //StadardTime-ShopDrawingCheck
        [ForeignKey("ShopDrawingCheck")]
        public int? ShopDrawingCheckId { get; set; }
        public virtual StandardTime ShopDrawingCheck { get; set; }
        //StadardTime-CuttingPlan
        [ForeignKey("CuttingPlan")]
        public int? CuttingPlanId { get; set; }
        public virtual StandardTime CuttingPlan { get; set; }
        //StadardTime-CuttingPlanCheck
        [ForeignKey("CuttingPlanCheck")]
        public int? CuttingPlanCheckId { get; set; }
        public virtual StandardTime CuttingPlanCheck { get; set; }
        //StadardTime-Packing
        [ForeignKey("Packing")]
        public int? PackingId { get; set; }
        public virtual StandardTime Packing { get; set; }
        //StadardTime-PackingCheck
        [ForeignKey("PackingCheck")]
        public int? PackingCheckId { get; set; }
        public virtual StandardTime PackingCheck { get; set; }
    }
}
