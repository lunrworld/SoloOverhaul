using BepInEx;
using BepInEx.Logging;
using SoloOverhaul.Patches;

namespace SoloOverhaul
{
    [BepInPlugin("com.lunarworld.solooverhaul", "LunarWorld-SoloOverhaul", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource LogSource;

        private void Awake()
        {
            new DisableInsuranceItem().Enable();
            new DisableInsuranceItemClass().Enable();
            new RemoveInsuranceScreen().Enable();
            new RemoveMailTimerGUI().Enable();
        }
    }
}
