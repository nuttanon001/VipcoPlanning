using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoPlanning.Models.Planning;
namespace VipcoPlanning.ViewModels
{
    public class EngineerManHourViewModel:EngineerManHour
    {
         public string ShopDrawingString {get;set;}
          //StadardTime-ShopDrawingCheck
           public string ShopDrawingCheckString {get;set;}
          //StadardTime-CuttingPlan
           public string CuttingPlanString {get;set;}
          //StadardTime-CuttingPlanCheck
           public string CuttingPlanCheckString {get;set;}
          //StadardTime-Packing
           public string PackingString {get;set;}
          //StadardTime-PackingCheck
           public string PackingCheckString {get;set;}
    }
}
