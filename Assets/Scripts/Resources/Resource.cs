using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous.Resources
{
	/// <summary>
	/// 
	/// </summary>

	public class Resource : MonoBehaviour
	{
		[BoxGroup("Testing")]
		public bool DoDamage = false;
		[BoxGroup("Testing")]
		public float damageAmount = 10;

		[BoxGroup("Testing")]
		public bool DoHeal = false;
		[BoxGroup("Testing")]
		public float healAmount = 25;

		[BoxGroup("Value")]
		[ShowInInspector]
		public virtual float MaxValue { get; set; }

		private float _currentValue;
		[BoxGroup("Value")]
		[ShowInInspector]
		public virtual float CurrentValue
		{
			get { return _currentValue; }
			set
			{
				_currentValue = Mathf.Clamp(value, 0, MaxValue);
				OnValueChange?.Invoke(CurrentValue, MaxValue);
			}
		}
		[ShowInInspector]
		public virtual float RegenAmount { get; protected set; }
		[ShowInInspector]
		public virtual float RecoveryTime { get; protected set; }

		public virtual float TickRate { get; } = 1f;

		public bool canRegen = true;
		private bool isRegen = false;

		private IEnumerator coroutine;

		public UnityFloat2Event OnValueChange;

		public float Percentage
		{
			get { return CurrentValue / MaxValue; }
		}


		private void Start()
		{
			Heal(MaxValue);
		}

		private void Update()
		{
			if (DoDamage)
			{
				Damage(damageAmount);
				DoDamage = false;
			}

			if (DoHeal)
			{
				Heal(healAmount);
				DoHeal = false;
			}

			if (CurrentValue != MaxValue && !isRegen)
			{
				coroutine = Regen();
				StartCoroutine(coroutine);
			}
		}

		public virtual void Damage(float amount)
		{
			if (isRegen)
			{
				StopCoroutine(coroutine);
				isRegen = !isRegen;
			}

			CurrentValue = Mathf.Max(0, CurrentValue - amount);

		}

		IEnumerator Regen()
		{
			isRegen = true;
			yield return new WaitForSeconds(RecoveryTime);

			while (CurrentValue < MaxValue)
			{
				CurrentValue += RegenAmount;
				yield return new WaitForSeconds(TickRate);
			}
			isRegen = false;

		}

		public virtual void Heal(float amount)
		{
			CurrentValue += amount;
		}
	}
}
