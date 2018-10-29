using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.ViewModels
{
    public class BillofMaterialViewModel : BillofMaterial
    {
        public string BomParentString { get; set; }
        public ICollection<BillofMaterial> BomLowLevel { get; set; }
    }
}
