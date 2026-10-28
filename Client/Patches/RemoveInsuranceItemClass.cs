using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.UI.Insurance;
using SPT.Reflection.Patching;

namespace SoloOverhaul.Patches
{
    internal class DisableInsuranceItemClass : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(EFT.UI.Insurance.InsuranceCompany).GetMethod(
                nameof(EFT.UI.Insurance.InsuranceCompany.ItemTypeAvailableForInsurance),
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new Type[] { typeof(InsuredItem) },
                null);
        }


        [PatchPrefix]
        protected static bool PatchPrefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }
}