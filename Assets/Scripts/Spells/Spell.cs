using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class Spell
	{
		[BoxGroup("Information")]
		[VerticalGroup("Information/Info/Text"), LabelWidth(75)]
		public string name;

		[BoxGroup("Information")]
		[VerticalGroup("Information/Info/Text"), LabelWidth(75), MultiLineProperty]
		public string description;

		[BoxGroup("Information")]
		[HorizontalGroup("Information/Info", 75), PreviewField(70, ObjectFieldAlignment.Right), HideLabel]
		public Sprite icon;

		

		public DamageType damageType;

		public ResourceCost resourceCost;

		public Cooldown cooldown = new Cooldown(1);

		public List<SpellEffect> effects = new List<SpellEffect>();



		public GameObject projectile;

		public void Cast(Transform spawnLocation, GameObject parent, Vector3 direction)
		{
			
		}

		public void SecondCast()
		{

		}

		public void CastAlt()
		{

		}

		public void SecondCastAlt()
		{

		}

		public Spell()
		{
			name = "New Spell";
		}

		public Spell (string spellName, DamageType dType)
		{
			name = spellName;
			damageType = dType;
		}

		public Spell (Spell s)
		{
			name = s.name;
			description = s.description;
			icon = s.icon;

			damageType = s.damageType;
			resourceCost = s.resourceCost;
			cooldown = s.cooldown;
		}

	}

	public enum ResourceCost
	{
		Health,
		Energy,
		Stamina,
	}
}
