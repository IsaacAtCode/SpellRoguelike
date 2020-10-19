using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous.Resources
{
	/// <summary>
	/// Unit's Energy
	/// </summary>

	public class Energy : Resource
	{
		public override float MaxValue { get => 100; }
		private float _regenAmount = 5;
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
