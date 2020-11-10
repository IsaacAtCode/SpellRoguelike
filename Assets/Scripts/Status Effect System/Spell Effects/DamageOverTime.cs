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
	public class DamageOverTime : StatusEffect
	{
		public float tickDamage = 10;
		public float tickInterval = 1f;
		public int tickCount = 5;

		private IEnumerator enumerator;

		private StatusEffectManager manager;

		[ShowInInspector]
		[BoxGroup("Properties")]
		public float Duration{ get => tickInterval * tickCount; }
		[ShowInInspector]
		[BoxGroup("Properties")]
		public float TotalDamage { get => tickDamage * tickCount; }


		public override void Apply()
		{
			//manager = bManager;

			//enumerator = DamageOverTimeCoroutine(tickDamage, tickCount, tickInterval, isAOE);

			manager.StartCoroutine(enumerator);
		}

		public override void Remove()
		{
			Debug.Log("Removed " + this);
			isFinished = true;
			manager.StopCoroutine(enumerator);
		}

		IEnumerator DamageOverTimeCoroutine(float damagePerTick, int count, float interval, bool isAOE = false)
		{
			isFinished = false;
			int currentTick = 0;

			while (currentTick <= count)
			{
				if (!isFinished)
				{
					// res.Damage(damagePerTick);
					Debug.Log(damagePerTick + " (" + currentTick + ").");
					yield return new WaitForSeconds(interval);
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
