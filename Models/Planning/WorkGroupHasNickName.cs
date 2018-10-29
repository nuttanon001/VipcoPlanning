using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class WorkGroupHasNickName : BaseModel
    {
        [Key]
        public int WorkGroupNickNameId { get; set; }
        [StringLength(200)]
        public string NickName { get; set; }
        public ActualType? ActualType { get; set; }
        //Relation
        [StringLength(50)]
        public string GroupCode { get; set; }
        [StringLength(50)]
        public string ReferenceGroupCode { get; set; }

    }
}
