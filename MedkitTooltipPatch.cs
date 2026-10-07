using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Jastos7.MedkitChangeHealthMod
{
    [HarmonyPatch(typeof(TooltipFactory), "ItemCommons")]
    internal class MedkitTooltipPatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ChangeMedkitTooltip(
            IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);

            for (int i = 1; i < codes.Count; i++)
            {
                CodeInstruction instruction = codes[i];

                if (instruction.opcode == OpCodes.Ldc_R4 && 
                    instruction.operand is float value &&
                    value == 50f)
                {
                    if (codes[i - 1].opcode == OpCodes.Ldstr &&
                        codes[i - 1].operand is string text &&
                        text == "HealthFormat")
                    {
                        instruction.operand = ConfigMod.MedkitHealth.Value;
                    }
                }
            }
            return codes;
        }
    }
}
