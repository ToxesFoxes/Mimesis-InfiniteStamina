using System.Reflection;
using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(InfiniteStamina.Core), "InfiniteStamina", "1.0.0", "ToxesFoxes", null)]
[assembly: MelonGame("ReLUGames", "MIMESIS")]

namespace InfiniteStamina
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("=================================================");
            MelonLogger.Msg("InfiniteStamina Mod v1.0.0 - Initializing...");
            MelonLogger.Msg("=================================================");
            MelonLogger.Msg("Author: github.com/ToxesFoxes");
            MelonLogger.Msg("Target: StatManager");

            try
            {
                var harmony = new HarmonyLib.Harmony("com.toxesfoxes.infinitestamina.mod");

                MelonLogger.Msg("Applying Harmony patches...");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                
                MelonLogger.Msg("=================================================");
                MelonLogger.Msg("SUCCESS: All Harmony patches applied!");
                MelonLogger.Msg("=================================================");
                MelonLogger.Msg("Active patches:");
                MelonLogger.Msg("  [1] GetCurrentStamina() - Prefix");
                MelonLogger.Msg("  [2] RegenerateStamina() - Prefix");
                MelonLogger.Msg("=================================================");
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error("=================================================");
                MelonLogger.Error("FAILED to apply Harmony patches!");
                MelonLogger.Error("Exception: " + ex.Message);
                MelonLogger.Error("Stack: " + ex.StackTrace);
                MelonLogger.Error("=================================================");
                MelonLogger.Error("Please report this error with full log!");
            }
        }
    }

    // Патч 1: Для GetCurrentStamina - всегда возвращает 10000 (максимальная выносливость)
    [HarmonyPatch(typeof(StatManager), "GetCurrentStamina")]
    public class GetCurrentStamina_Patch
    {
        static bool Prefix(StatManager __instance, ref long __result)
        {
            try
            {
                CommonStats stats = __instance.GetStats();
                __result = 10000;
                return false;
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Error in GetCurrentStamina_Patch: {ex.Message}");
                return true;
            }
        }
    }

    // Патч 2: Для RegenerateStamina - всегда устанавливает выносливость в 10000
    [HarmonyPatch(typeof(StatManager), "RegenerateStamina")]
    public class RegenerateStamina_Patch
    {
        static bool Prefix(StatManager __instance, ref long delta)
        {
            try
            {
                __instance.SetMutableStat(MutableStatType.Stamina, 10000);
                return false;
            }
            catch (Exception ex)
            {
                MelonLogger.Error($"Error in GetCurrentStamina_Patch: {ex.Message}");
                return true;
            }
        }
    }
}