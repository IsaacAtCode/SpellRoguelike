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
		[BoxGroup("Information")]
		[VerticalGroup("Information/Info/Text"), LabelWidth(75)]
		public string Name;

		[BoxGroup("Information")]
		[VerticalGroup("Information/Info/Text"), LabelWidth(75), MultiLineProperty]
		public string Description;

		[BoxGroup("Information")]
		[HorizontalGroup("Information/Info", 75), PreviewField(70, ObjectFieldAlignment.Right), HideLabel]
		public Sprite Icon;

		[BoxGroup("Colour")]
		public Color ColorPrimary;

		[BoxGroup("Colour")]
		public Color ColorSecondary;

		[ShowInInspector]
		[BoxGroup("Weaknesses")]
		public Dictionary<DamageType, float> weaknesses = new Dictionary<DamageType, float>();

		[BoxGroup("Innate Buff")]
		public ScriptableBuff innateBuff;




		[BoxGroup("Effects")]
		public ParticleType particleType;
		[BoxGroup("Effects")]
		public Color particleColor;

		[BoxGroup("Audio")]
		public AudioClip audio; 

		public float CheckWeakness(DamageType type)
		{
			if (weaknesses.TryGetValue(type, out float value))
			{
				return value;
			}
			return 1f;
		}

	}

	public enum ParticleType
	{
		None,
		Explosion,
	}
}