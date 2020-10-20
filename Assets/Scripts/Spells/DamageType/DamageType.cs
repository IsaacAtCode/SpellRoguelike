using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Serendipitous
{
	/// <summary>
	/// 
	/// </summary>

	[CreateAssetMenu(fileName = "DamageType", menuName = "DamageType/New Damage Type")]
	public class DamageType : ScriptableObject
	{
		public string Name;

		[BoxGroup("Colour")]
		public Color colorPrimary;

		[BoxGroup("Colour")]
		public Color colorSecondary;

		[ShowInInspector]
		public Dictionary<DamageType, float> weaknesses = new Dictionary<DamageType, float>();


		public float CheckWeakness(DamageType type)
		{
			if (weaknesses.TryGetValue(type, out float value))
			{
				return value;
			}


			return 1f;
		}

	}
}