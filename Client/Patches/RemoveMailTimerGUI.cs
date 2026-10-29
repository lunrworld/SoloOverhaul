using System.Reflection;
using SPT.Reflection.Patching;
using EFT.UI.Chat;

namespace SoloOverhaul.Patches
{
    internal class RemoveMailTimerGUI : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(AttachmentMessageView).GetMethod("SetButtonsStatus");
        }

        [PatchPostfix]
        private static void PostFix(AttachmentMessageView __instance)
        {
            __instance._timeToGetLabel.gameObject.SetActive(false);
        }
    }
}
