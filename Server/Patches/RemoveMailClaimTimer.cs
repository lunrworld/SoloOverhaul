using SPTarkov.Reflection.Patching;
using SPTarkov.Server.Core.Controllers;
using SPTarkov.Server.Core.Services.Commerce;
using SPTarkov.Server.Core.Models.Spt.Dialog;
using System.Reflection;


namespace SoloOverhaul.Patches
{
    internal class RemoveMailClaimTimer : AbstractPatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(MailSendService).GetMethod("SendMessageToPlayer");
        }

        [PatchPrefix]
        private static void Prefix(SendMessageDetails messageDetails)
        {
            messageDetails.ItemsMaxStorageLifetimeSeconds = 50L * 365 * 24 * 60 * 60;
        }
    }
}
