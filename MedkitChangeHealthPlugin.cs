using BepInEx;
using BepInEx.Logging;
using HarmonyLib;


namespace Jastos7.MedkitChangeHealthMod
{
    [BepInPlugin("com.jastos7.medkitchangehealth", "Medkit Change Health", "1.1.0")]
    public class MedkitChangeHealthPlugin : BaseUnityPlugin
    {

        public static ManualLogSource Log;
        void Awake()
        {
            Log = Logger;
            Log.LogInfo("Medkit Change Health 1.1.0 loaded.");
            ConfigMod.MedkitHealth = Config.Bind<float>(
                "General",
                "MedkitHealth",
                100f,
                "How much health the medkit should restore. Warning: You need to restart the game for changes to take effect."
            );
            Log.LogInfo("Medkits will restore " + ConfigMod.MedkitHealth.Value + "HP.");
            Harmony harmony = new Harmony("com.jastos7.medkitchangehealth");
            harmony.PatchAll();
        }
    }
}
