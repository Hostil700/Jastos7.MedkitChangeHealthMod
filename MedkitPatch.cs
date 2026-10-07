using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Jastos7.MedkitChangeHealthMod
{
    [HarmonyPatch(typeof(Survival), nameof(Survival.Use))]
    internal class MedkitPatch
    {
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> ChangeMedkitHealth(
            IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4)
                {
                    if (instruction.operand is float value && value == 50f)
                    {
                        instruction.operand = ConfigMod.MedkitHealth.Value;
                    }
                }
            }

            return instructions;
        }
    }
}
