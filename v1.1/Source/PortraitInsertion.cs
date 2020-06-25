using HarmonyLib;
using UnityEngine;
using Verse;

namespace PortraitLoader
{
	[HarmonyPatch(typeof(Dialog_InfoCard), "FillCard")]
	internal class HarmonyPortraitInsertion
	{
		private static bool Prefix(Rect cardRect, Dialog_InfoCard __instance, Thing ___thing)
		{
			Pawn p = ___thing as Pawn;
			if (p == null)
			{
				return true;
			}
			PortraitData portraitData = PortraitLoader.Portraits.Find((PortraitData x) => x.DefinitionKey == p.kindDef.defName);
			if (portraitData != null)
			{
				if (PortraitLoader.CurPortrait != portraitData)
				{
					PortraitLoader.CurPortrait = portraitData;
					PortraitLoader.CurTexture = ContentFinder<Texture2D>.Get(PortraitLoader.CurPortrait.TexturePath, false);
					if (PortraitLoader.CurTexture == null)
					{
						Log.Message("Texture missing " + PortraitLoader.CurPortrait.TexturePath, false);
						PortraitLoader.CurTexture = ContentFinder<Texture2D>.Get(BaseContent.BadTexPath, true);
					}
				}
				Rect rect = GenUI.AtZero(cardRect);
				rect.width = 440f;
				rect.height = 540f;
				rect.x = cardRect.width - rect.width;
				rect.y = cardRect.center.y - rect.height / 2f;
				GUI.DrawTexture(rect, PortraitLoader.CurTexture, (ScaleMode)1, true);
			}
			return true;
		}
	}
}
