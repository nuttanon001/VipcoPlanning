using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.ViewModels
{
    public class PlanMasterViewModel
    {
        public int PlanMasterId { get; set; }
        public string ProjectName { get; set; }
        public int? Revised { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public PlanningStatus? PlanningStatus { get; set; }
        public int? ProjectCodeMasterId { get; set; }
        public string ManagementBy { get; set; }
        public string ManagementName { get; set; }
        public List<PlanDetailViewModel> PlanDetails { get; set; } = new List<PlanDetailViewModel>();
        public List<PlanShipment> PlanShipments { get; set; } = new List<PlanShipment>();
        public string ManagementByString { get; set; }
        public string Creator { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Modifyer { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
