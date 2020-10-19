using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous.Resources
{
	/// <summary>
	/// Unit's Health
	/// </summary>

	public class Health : Resource
	{
		public override float MaxValue { get => 100; }
		private float _regenAmount = 1;
		public override float RegenAmount { get => _regenAmount; set => _regenAmount = value; }

		private float _recoveryTime;
		public override float RecoveryTime
		{
			get => _recoveryTime;
			set => _recoveryTime = value;
		}

		public override float TickRate => base.TickRate;
	}
}
