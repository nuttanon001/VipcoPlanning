using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class ActualDaily : BaseModel
    {
        [Key]
        public int ActualDailyId { get; set; }
        public DateTime Daily { get; set; }
        [StringLength(20)]
        public string JobNo { get; set; }
        [StringLength(50)]
        public string GroupCode { get; set; }
        [StringLength(200)]
        public string GroupName { get; set; }
        [StringLength(50)]
        public string WorkShop { get; set; }
        [StringLength(200)]
        public string NickName { get; set; }
        public double? TotalManHour { get; set; }
        public double? TotalManHourOT { get; set; }
        public double? TotalManHourNTOT { get; set; }
        public ActualType? ActualType { get; set; }
        public ActualDetailType? ActualDetailType { get; set; }
    }
}
