using HarmonyLib;
using SPT.Reflection.Patching;
using EFT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;


namespace SoloOverhaul.Patches
{
    internal class RemoveInsuranceScreen : ModulePatch 
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(MainMenuShowOperation).GetMethod("CG_method_80", BindingFlags.Public | BindingFlags.Instance);
        }

        [PatchTranspiler]
        protected static IEnumerable<CodeInstruction> PatchTranspiler(IEnumerable<CodeInstruction> originalInstructions)
        {
            MethodInfo showInsuranceScreenMethodInfo = typeof(MainMenuShowOperation).GetMethod("method_51", BindingFlags.Public | BindingFlags.Instance);
            MethodInfo showAcceptScreenMethodInfo = typeof(MainMenuShowOperation).GetMethod("method_52", BindingFlags.Public | BindingFlags.Instance);
            
            List<CodeInstruction> modifiedInstructions = originalInstructions.ToList();

            for (int i = 0; i < modifiedInstructions.Count; i++)
            {
                if ((modifiedInstructions[i].opcode == OpCodes.Call) && ((MethodInfo)modifiedInstructions[i].operand == showInsuranceScreenMethodInfo))
                {
                    modifiedInstructions[i].operand = showAcceptScreenMethodInfo;
                }

            }
            return modifiedInstructions;
        }
    }
}
