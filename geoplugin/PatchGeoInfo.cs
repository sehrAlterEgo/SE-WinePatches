using System;
using System.Reflection;
using HarmonyLib;
using Sandbox;
using Sandbox.Engine.Analytics;
using VRage.Plugins;

namespace PatchGeoInfoPlugin
{
	public class PatchGeoInfo : IPlugin
    {
	    public void Init(object gameInstance)
        {
             Harmony harmony = new Harmony("Test");
             MySandboxGame.Log.WriteLine("Initializing Wine Patcher Plugin...");

             Type targetType = AccessTools.TypeByName("VRage.Platform.Windows.Win32.WinApi");
             if (targetType == null)
                 throw new Exception("Unable to find WinApi");
             Type targetParamType = targetType.GetNestedType("GeoTypeEnum");
             if (targetParamType == null)
                 throw new Exception("Unable to find GeoTypeEnum");
             MethodInfo target = AccessTools.DeclaredMethod(targetType, "GetGeoInfo", new Type[] { targetParamType });
             if (target == null)
                 throw new Exception("Unable to find GetGeoInfo");
             HarmonyMethod prefix = new HarmonyMethod(typeof(PatchGeoInfo), "Patch_GetGeoInfo");
             //typeof(PatchGeoInfoPlugin).GetMethod("Patch_GetGeoInfo", BindingFlags.Static | BindingFlags.Public);
             if (prefix == null)
                 throw new Exception("Unable to find Patch_GetGeoInfo");
             harmony.Patch(target, prefix);
             MySandboxGame.Log.WriteLine("GeoInfo Patched.");
        }

        public void Update()
        {
        }

        public void Dispose()
        {
        }
        public static bool Patch_GetGeoInfo(ref string __result)
        {
            __result = "0";
            return false;
        }
    }
}
