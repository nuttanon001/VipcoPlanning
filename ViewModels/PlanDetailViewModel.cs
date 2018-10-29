using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
namespace VipcoPlanning.ViewModels
{
    public class PlanDetailViewModel:PlanDetail
    {
        public string ResponsibilityByString { get; set; }
        public string AssignmentToGroupString { get; set; }
        public string BomLevel2 {get;set;}
        public string ShopDrawingStd {get;set;}
        public string CheckShopDrawingStd {get;set;}
        public string CuttingPlanStd {get;set;}
        public string CheckCuttingPlanStd {get;set;}
        public string PackingFrameStd {get;set;}
        public string CheckPackingFrameStd {get;set;}
        public string FabStd {get;set;}
        public string PreStd {get;set;}
        public string PackStd {get;set;}
        public string WeldStd {get;set;}
    }
}
