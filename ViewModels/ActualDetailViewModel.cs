using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.ViewModels
{
    public class ActualDetailViewModel:ActualDetail
    {
        public string ActualTypeString { get; set; }
    }

    public class ActualFabTable
    {
        public string JobNo { get; set; }
        public string WorkShopName { get; set; }
        public string WorkGroup { get; set; }
        public string Status { get; set; }
        public double? NormalTime { get; set; }
        public double? OverTime { get; set; }
        public double? OverTimeX { get; set; }
        public string NormalTimeString => string.Format("{0:#,##0.00}", this.NormalTime);
        public string OverTimeString => string.Format("{0:#,##0.00}", this.OverTime);
        public string OverTimeXString => string.Format("{0:#,##0.00}", this.OverTimeX);
        public double? Weight { get; set; }
        public string WeightString => string.Format("{0:#,##0.00}", this.Weight);
        public double? PlanMH { get; set; }
        public string PlanMHString => string.Format("{0:#,##0.00}", this.PlanMH);
        public double? ActualMH { get; set; }
        public double? ActualMHxOT { get; set; }
        public string ActualMHString => string.Format("{0:#,##0.00}", this.ActualMH);
        public double? Diff => (this.PlanMH - this.ActualMH) ?? 0;
        public string DiffString => string.Format("{0:#,##0}", this.Diff);
        public string ProgressMH => (this.ActualMH > 0 && this.PlanMH > 0 ? (((this.ActualMH / this.PlanMH) ?? 0) * 100).ToString("0.0") : "0.0") + "%";
        public double? OverTimemultiply { get; set; }
        public double? PlanMHOT => this.PlanMH * (this.OverTimemultiply ?? 1);
        public string PlanMHOTString => string.Format("{0:#,##0.00}", this.PlanMHOT);
        public double? ActualMHOT => this.ActualMHxOT;
        public string ActualMHOTString => string.Format("{0:#,##0.00}", this.ActualMHOT);
        public double? DiffOT => (this.PlanMHOT - this.ActualMHOT) ?? 0;
        public string DiffOTString => string.Format("{0:#,##0.00}", this.DiffOT);
        public string ProgressOTMH => (this.ActualMHOT > 0 && this.PlanMHOT > 0 ? (((this.ActualMHOT / this.PlanMHOT) ?? 0) * 100).ToString("0.0") : "0.0") + "%";
        public string PlanKg => (this.Weight > 0 && this.PlanMH > 0 ? (((this.Weight * 1000) / this.PlanMH) ?? 0).ToString("0.0") : "0.0") + "Kg/MH";
        public string ActualKg => (this.Weight > 0 && this.ActualMH > 0 ? (((this.Weight * 1000) / this.ActualMH) ?? 0).ToString("0.0") : "0.0") + "Kg/MH";
        public string PlanMT => (this.PlanMH > 0 && this.Weight > 0 ? ((this.PlanMH / this.Weight) ?? 0).ToString("0.0"): "0.0") + "MH/MT";
        public string ActualMT => (this.ActualMH > 0 && this.Weight > 0 ? ((this.ActualMH / this.Weight ) ?? 0).ToString("0.0"): "0.0") + "MH/MT";
    }
}
