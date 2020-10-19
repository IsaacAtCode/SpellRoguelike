using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous
{
	/// <summary>
	/// Storage for Area Info
	/// </summary>

	[CreateAssetMenu(fileName = "AreaInfo", menuName = "AreaInfo/New Area")]
	public class AreaInfo : ScriptableObject
	{
		public string Skybox;
		public Color SkyColour;
		public Color FogColor;

		public List<GameObject> Assets; //Add specific Assets instead if list
	}
}