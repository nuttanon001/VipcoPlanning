﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoPlanning.Models.Planning
{
    public class Permission:BaseModel
    {
        [Key]
        public int PermissionId { get; set; }
        /// <summary>
        /// User FK from Table User in MachineDataBase
        /// </summary>
        public int UserId { get; set; }
        public int LevelPermission { get; set; }
    }
}
