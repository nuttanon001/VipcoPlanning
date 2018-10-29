using VipcoPlanning.Models.Planning;

namespace VipcoPlanning.ViewModels
{
    public class FabricationManHourViewModel : FabricationManHour
    {
        public string FabricationString { get; set; }

        //StadardTime-PerAssembly
        public string PerAssemblyString { get; set; }
    }
}