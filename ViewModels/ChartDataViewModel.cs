﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoPlanning.ViewModels
{
    public class ChartDataViewModel
    {
        public string Label { get; set; }
        public List<double> ChartData { get; set; } = new List<double>();
    }
}
