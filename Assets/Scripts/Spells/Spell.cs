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
		public string SpellName;
		[MultiLineProperty]
		public string SpellDescription;
		[MultiLineProperty]
		public string SpellTooltip;

		public DamageType damageType;

		public ResourceCost resourceCost;


		public Cooldown cooldown = new Cooldown(1);

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
			SpellName = "New Spell";
		}

		public Spell (string spellName, DamageType dType)
		{
			SpellName = spellName;
			damageType = dType;
		}


	}

	public enum ResourceCost
	{
		Health,
		Energy,
		Stamina,
	}
}
