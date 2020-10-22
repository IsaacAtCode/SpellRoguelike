using Serendipitous.Resources;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>

	[Serializable]
	public class DamageOverTime : SpellEffect
	{
		public float tickDamage = 10;
		public float tickInterval = 1f;
		public int tickCount = 5;

		private IEnumerator enumerator;

		private BuffManager manager;

		[ShowInInspector]
		[BoxGroup("Properties")]
		public float Duration{ get => tickInterval * tickCount; }
		[ShowInInspector]
		[BoxGroup("Properties")]
		public float TotalDamage { get => tickDamage * tickCount; }


		public override void Apply(BuffManager bManager, bool isAOE = false)
		{
			manager = bManager;

			enumerator = DoT(manager.health, isAOE);

			manager.StartCoroutine(enumerator);
		}

		public override void Remove()
		{
			Debug.Log("Removed " + this);
			isFinished = true;
			manager.StopCoroutine(enumerator);
		}

		IEnumerator DoT(Resource res, bool isAOE = false)
		{
			isFinished = false;
			int currentTick = 0;


			int dotCount = 0;

			if (isAOE)
			{
				dotCount = 999;
			}
			else
			{
				dotCount = tickCount;
			}


			while (currentTick <= dotCount)
			{
				if (!isFinished)
				{
					res.Damage(tickDamage);
					Debug.Log(res.name + " is damaged for " + tickDamage + " (" + currentTick + ").");
					yield return new WaitForSeconds(tickInterval);
					currentTick++;
				}
			}
			
			Debug.Log("Stopped burning");

			isFinished = true;
		}

		public DamageOverTime()
		{
			tickDamage = 10;
			tickInterval = 1f;
			tickCount = 5;
		}

		public DamageOverTime(float dmg, float inter, int count)
		{
			tickDamage = dmg;
			tickInterval = inter;
			tickCount = count;
		}

	}
}
