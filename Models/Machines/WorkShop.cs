using System;
using System.Collections.Generic;

namespace VipcoPlanning.Models.Machines
{
    public partial class WorkShop
    {
        public WorkShop()
        {
            WorkGroupHasWorkShop = new HashSet<WorkGroupHasWorkShop>();
        }

        public int WorkShopId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifyer { get; set; }
        public string Remark { get; set; }
        public string WorkShopName { get; set; }

        public virtual ICollection<WorkGroupHasWorkShop> WorkGroupHasWorkShop { get; set; }
    }
}
