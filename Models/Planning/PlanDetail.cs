using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class PlanDetail : BaseModel
    {
        [Key]
        public int PlanDetailId { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public double? ContentWeigth { get; set; }
        public DateTime? CustomerDrawingDate { get; set; }
        public DateTime? ShopDrawingDate { get; set; }
        public DateTime? CuttingPlanDate { get; set; }
        public DateTime? MaterialDate { get; set; }
        public DateTime? MachineAndPartDate { get; set; }
        public DateTime? FabPlanSDate { get; set; }
        public DateTime? FabPlanEDate { get; set; }
        public DateTime? PreAssPlanSDate { get; set; }
        public DateTime? PreAssPlanEDate { get; set; }
        public DateTime? PaintPlanSDate { get; set; }
        public DateTime? PaintPlanEDate { get; set; }
        public DateTime? InsuPlanSDate { get; set; }
        public DateTime? InsuPlanEDate { get; set; }
        public DateTime? PackPlanSDate { get; set; }
        public DateTime? PackPlanEDate { get; set; }
        [StringLength(200)]
        public string Remark { get; set; }
        //Relation
        //EmpCode
        [StringLength(50)]
        public string ResponsibilityBy { get; set; }
        //WorkGroup
        [StringLength(50)]
        public string AssignmentToGroup { get; set; }
        // PlanningProjectMaster
        public int? PlanMasterId { get; set; }
        public virtual PlanMaster PlanMaster { get; set; }
        // BillOfMaterial
        public int? BillofMaterialId { get; set; }
        public virtual BillofMaterial BillofMaterial { get; set; }
        // EngineerManHour
        public int? EngineerManHourId { get; set; }
        public virtual EngineerManHour EngineerManHour { get; set; }
        // FabricationManHour
        public int? FabricationManHourId { get; set; }
        public virtual FabricationManHour FabricationManHour { get; set; }
        // PackingManHour
        public int? PackingManHourId { get; set; }
        public virtual PackingManHour PackingManHour { get; set; }
        // WeldManHour
        public int? WeldManHourId { get; set; }
        public virtual WeldManHour WeldManHour { get; set; }
    }
}
