using System.Reflection;
using HarmonyLib;
using Verse;

namespace PortraitLoader
{
	[StaticConstructorOnStartup]
	internal class Main
	{
		static Main()
		{
			new Harmony("PortraitLoader.HarmonyPatch").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
