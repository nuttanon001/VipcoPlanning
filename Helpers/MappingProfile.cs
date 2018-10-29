using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using VipcoPlanning.Models.Planning;
using VipcoPlanning.Models.Machines;
using VipcoPlanning.ViewModels;

namespace VipcoPlanning.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BillOfMaterial
            CreateMap<BillofMaterial, BillofMaterialViewModel>()
                .ForMember(x => x.BomParent, o => o.Ignore());

            CreateMap<BillofMaterialViewModel, BillofMaterial>();
            #endregion

            #region EngineerManHour
            CreateMap<EngineerManHour, EngineerManHourViewModel>()
                .ForMember(x => x.CuttingPlan, o => o.Ignore())
                .ForMember(x => x.CuttingPlanString,o => o.MapFrom(s => s.CuttingPlan.Name))
                .ForMember(x => x.CuttingPlanCheck, o => o.Ignore())
                .ForMember(x => x.CuttingPlanCheckString, o => o.MapFrom(s => s.CuttingPlanCheck.Name))
                .ForMember(x => x.Packing, o => o.Ignore())
                .ForMember(x => x.PackingString, o => o.MapFrom(s => s.Packing.Name))
                .ForMember(x => x.PackingCheck, o => o.Ignore())
                .ForMember(x => x.PackingCheckString, o => o.MapFrom(s => s.PackingCheck.Name))
                .ForMember(x => x.ShopDrawing, o => o.Ignore())
                .ForMember(x => x.ShopDrawingString, o => o.MapFrom(s => s.ShopDrawing.Name))
                .ForMember(x => x.ShopDrawingCheck, o => o.Ignore())
                .ForMember(x => x.ShopDrawingCheckString, o => o.MapFrom(s => s.ShopDrawingCheck.Name));
            #endregion

            #region FabricationManHour
            CreateMap<FabricationManHour, FabricationManHourViewModel>()
                .ForMember(x => x.Fabrication, o => o.Ignore())
                .ForMember(x => x.FabricationString, o => o.MapFrom(s => s.Fabrication.Name))
                .ForMember(x => x.PerAssembly, o => o.Ignore())
                .ForMember(x => x.PerAssemblyString, o => o.MapFrom(s => s.PerAssembly.Name));
            #endregion

            #region HistoryPlanMaster
            CreateMap<HistoryPlanMaster, HistoryPlanMasterViewModel>()
                .ForMember(x => x.PlanMaster, o => o.Ignore());

            #endregion

            #region PackingManHour
            CreateMap<PackingManHour, PackingManHourViewModel>()
                .ForMember(x => x.Packing, o => o.Ignore())
                .ForMember(x => x.PackingString, o => o.MapFrom(s => s.Packing.Name));
            #endregion

            #region PlanDetail
            CreateMap<PlanDetail, PlanDetailViewModel>()
                .ForMember(x => x.BomLevel2,o => o.MapFrom(s => s.BillofMaterial.Name))
                .ForMember(x => x.BillofMaterial,o => o.Ignore())
                .ForMember(x => x.ShopDrawingStd,o => o.MapFrom(s => s.EngineerManHour.ShopDrawing.Code))
                .ForMember(x => x.CheckShopDrawingStd, o => o.MapFrom(s => s.EngineerManHour.ShopDrawingCheck.Code))
                .ForMember(x => x.CuttingPlanStd, o => o.MapFrom(s => s.EngineerManHour.CuttingPlan.Code))
                .ForMember(x => x.CheckCuttingPlanStd, o => o.MapFrom(s => s.EngineerManHour.CuttingPlanCheck.Code))
                .ForMember(x => x.PackingFrameStd, o => o.MapFrom(s => s.EngineerManHour.Packing.Code))
                .ForMember(x => x.CheckPackingFrameStd, o => o.MapFrom(s => s.EngineerManHour.PackingCheck.Code))
                .ForMember(x => x.EngineerManHour,o => o.Ignore())
                .ForMember(x => x.FabStd, o => o.MapFrom(s => s.FabricationManHour.Fabrication.Code))
                .ForMember(x => x.PreStd, o => o.MapFrom(s => s.FabricationManHour.PerAssembly.Code))
                .ForMember(x => x.FabricationManHour,o => o.Ignore())
                .ForMember(x => x.PackStd, o => o.MapFrom(s => s.PackingManHour.Packing.Code))
                .ForMember(x => x.PackingManHour,o => o.Ignore())
                .ForMember(x => x.WeldStd, o => o.MapFrom(s => s.WeldManHour.Weld.Code))
                .ForMember(x => x.WeldManHour,o => o.Ignore())
                .ForMember(x => x.PlanMaster, o => o.Ignore());
            CreateMap<PlanDetailViewModel, PlanDetail>();
            #endregion

            #region PlanMaster
            CreateMap<PlanMaster, PlanMasterViewModel>()
                .ForMember(x => x.PlanDetails, o => o.Ignore());
            CreateMap<PlanMasterViewModel, PlanMaster>();
            #endregion

            #region StandardTime

            CreateMap<StandardTime, StandardTimeViewModel>()
                .ForMember(x => x.ForWorkGroupString,o => o.MapFrom(s => s.StandardTimeForWorkGroup == null ? "-" : s.StandardTimeForWorkGroup.Name))
                .ForMember(x => x.StandardTimeForWorkGroup, o => o.Ignore())
                .ForMember(x => x.GroupStandardString, o => o.MapFrom(s => s.GroupStandardTime == null ? "-" : s.GroupStandardTime.Name))
                .ForMember(x => x.GroupStandardTime, o => o.Ignore());

            #endregion

            #region StandardTimeForWorkGroup

            CreateMap<StandardTimeForWorkGroup, StandardTimeForWorkGroupViewModel>()
                .ForMember(x => x.RateManHours,o => o.Ignore()) 
                .ForMember(x => x.StandardTimes,o => o.Ignore());

            #endregion

            #region WeldManHour
            CreateMap<WeldManHour, WeldManHourViewModel>()
                .ForMember(x => x.Weld, o => o.Ignore())
                .ForMember(x => x.WeldString, o => o.MapFrom(s => s.Weld.Name));
            #endregion

            #region User

            //User
            CreateMap<User, UserViewModel>()
                // CuttingPlanNo
                .ForMember(x => x.NameThai,
                           o => o.MapFrom(s => s.EmpCodeNavigation == null ? "-" : $"คุณ{s.EmpCodeNavigation.NameThai}"))
                .ForMember(x => x.EmpCodeNavigation, o => o.Ignore());

            #endregion User

            #region Employee

            //Employee
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(x => x.User, o => o.Ignore())
                .ForMember(x => x.GroupMisNavigation, o => o.Ignore());

            #endregion

            #region EmployeeGroupMis

            CreateMap<EmployeeGroupMis, GroupMisViewModel>()
                .ForMember(x => x.Employee, o => o.Ignore());

            #endregion

            #region ProjectCodeMaster

            CreateMap<ProjectCodeMaster, ProjectMasterViewModel>();

            #endregion

            #region RateManhour

            CreateMap<RateManHour, RateManHourViewModel>()
                .ForMember(x => x.ForWorkGroupString, o => o.MapFrom(s => s.StandardTimeForWorkGroup.Name ?? "-"))
                .ForMember(x => x.StandardTimeForWorkGroup, o => o.Ignore());

            #endregion

            #region WorkGroupManHour

            CreateMap<WorkGroupTotalManHourView, ActualDetailViewModel>()
                .ForMember(x => x.GroupCode, o => o.MapFrom(s => s.GroupCode))
                .ForMember(x => x.TotalManHour, o => o.MapFrom(s => s.TotalWorkTime))
                .ForMember(x => x.TotalManHourOT, o => o.MapFrom(s => s.TotalOverTime))
                .ForMember(x => x.TotalManHourNTOT, o => o.MapFrom(s => s.TotalWorkTimeOverTime));

            #endregion

            #region WorkGroupManHour

            CreateMap<WorkGroupTotalManHourSubView, ActualDetailViewModel>()
                .ForMember(x => x.GroupCode, o => o.MapFrom(s => s.GroupMIS))
                .ForMember(x => x.GroupName, o => o.MapFrom(s => s.GroupName))
                .ForMember(x => x.TotalManHour, o => o.MapFrom(s => s.TotalWorkTime))
                .ForMember(x => x.TotalManHourOT, o => o.MapFrom(s => s.TotalOverTime))
                .ForMember(x => x.TotalManHourNTOT, o => o.MapFrom(s => s.TotalWorkTimeOverTime));

            #endregion

            #region BomTotalManHourView

            CreateMap<BomTotalManHourView, ActualBom>()
                .ForMember(x => x.BomCode, o => o.MapFrom(s => s.ItemCode))
                .ForMember(x => x.GroupCode, o => o.MapFrom(s => s.GroupCode))
                .ForMember(x => x.TotalManHour, o => o.MapFrom(s => s.TotalWorkTime))
                .ForMember(x => x.TotalManHourOT, o => o.MapFrom(s => s.TotalOverTime))
                .ForMember(x => x.TotalManHourNTOT, o => o.MapFrom(s => s.TotalWorkTimeOverTime));

            #endregion

            #region BomTotalManHourSubView

            CreateMap<BomTotalManHourSubView, ActualBom>()
                .ForMember(x => x.BomCode, o => o.MapFrom(s => s.ItemCode))
                .ForMember(x => x.GroupCode, o => o.MapFrom(s => s.GroupMIS))
                .ForMember(x => x.TotalManHour, o => o.MapFrom(s => s.TotalWorkTime))
                .ForMember(x => x.TotalManHourOT, o => o.MapFrom(s => s.TotalOverTime))
                .ForMember(x => x.TotalManHourNTOT, o => o.MapFrom(s => s.TotalWorkTimeOverTime));

            #endregion

            #region ActualDetail

            CreateMap<ActualDetail, ActualDetailViewModel>()
                .ForMember(x => x.ActualTypeString,s => s.MapFrom(z => System.Enum.GetName(typeof(ActualType), z.ActualType)));

            #endregion

            #region WorkGroupHasNickName
            CreateMap<WorkGroupHasNickName, NickNameViewModel>()
                .ForMember(x => x.TypeName, o => o.MapFrom(s => System.Enum.GetName(typeof(ActualType), s.ActualType)));
            #endregion
        }
    }
}
