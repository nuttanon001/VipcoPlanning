using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Machines;

namespace VipcoPlanning.ViewModels
{
    public class UserViewModel:User
    {
        public string NameThai { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public int LevelPlanning { get; set; }
    }
}
