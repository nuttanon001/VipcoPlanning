using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoPlanning.Models.Planning
{
    public class BillofMaterial:BaseModel
    {
        [Key]
        public int BillofMaterialId { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public int? LevelofBom { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        public string Remark { get; set; }
        // Relation
        [ForeignKey("BomParent")]
        public int? BomParentId { get; set; }
        public virtual BillofMaterial BomParent { get; set; }
    }
}
