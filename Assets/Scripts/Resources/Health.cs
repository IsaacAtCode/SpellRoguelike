using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous.Resources
{
	/// <summary>
	/// 
	/// </summary>

	public class Health : Resource
	{
		public override float MaxValue { get => 100; }
		public override float RegenAmount { get => 1; }
		public override float RecoveryTime
		{
			get { return Mathf.Max(TickRate, 5); }
		}

		public override float TickRate => base.TickRate;
	}
}
