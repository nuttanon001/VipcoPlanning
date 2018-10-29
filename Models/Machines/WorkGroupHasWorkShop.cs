using System;
using System.Collections.Generic;

namespace VipcoPlanning.Models.Machines
{
    public partial class WorkGroupHasWorkShop
    {
        public int WorkGroupHasWorkShopId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Creator { get; set; }
        public string GroupMis { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifyer { get; set; }
        public string TeamName { get; set; }
        public int WorkShopId { get; set; }

        public virtual EmployeeGroupMis GroupMisNavigation { get; set; }
        public virtual WorkShop WorkShop { get; set; }
    }
}
