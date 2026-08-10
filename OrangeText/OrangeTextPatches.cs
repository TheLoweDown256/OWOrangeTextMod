using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace OrangeText
{
    [HarmonyPatch]
    public static class OrangeTextPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(TextTranslation), nameof(TextTranslation._Translate))]
        public static void TextTranslation__Translate_Postfix(string key, TextTranslation __instance, ref string __result)
        {
            __result = OrangeText.Instance.ProcessText(__result);
        }


        [HarmonyPostfix]
        [HarmonyPatch(typeof(TextTranslation), nameof(TextTranslation._Translate_ShipLog))]
        public static void TextTranslation__Translate_ShipLog_Postfix(string key, TextTranslation __instance, ref string __result)
        {
            __result = OrangeText.Instance.ProcessText(__result);
        }


        /*[HarmonyPostfix]
        [HarmonyPatch(typeof(TextTranslation), nameof(TextTranslation._Translate_UI))]
        public static void TextTranslation__Translate_UI_Postfix(int key, TextTranslation __instance, ref string __result)
        {
            __result = OrangeText.Instance.ProcessText(__result);
        }*/
    }
}
