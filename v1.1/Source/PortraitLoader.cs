using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace PortraitLoader
{
	[StaticConstructorOnStartup]
	public static class PortraitLoader
	{
		public static List<PortraitData> Init()
		{
			List<PortraitData> list = new List<PortraitData>();
			foreach (PortraitXmlLoader loader in DefDatabase<PortraitXmlLoader>.AllDefs)
			{
				foreach (KeyValuePair<string, string> keyValuePair in loader.PortraitData)
				{
					list.Add(new PortraitData
					{
						DefinitionKey = keyValuePair.Key,
						TexturePath = keyValuePair.Value
					});
				}
			}
			return list;
		}

		public static PortraitData CurPortrait;
		public static Texture2D CurTexture;
		public static List<PortraitData> Portraits = Init();
	}
}