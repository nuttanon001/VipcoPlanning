using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.ViewModels
{
    public class NickNameViewModel:WorkGroupHasNickName
    {
        public string GroupName { get; set; }
        public string TypeName { get; set; }
        public string ReferenceName { get; set; }
    }
}
