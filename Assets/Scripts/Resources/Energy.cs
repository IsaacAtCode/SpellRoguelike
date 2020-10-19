using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous.Resources
{
	/// <summary>
	/// 
	/// </summary>

	public class Energy : Resource
	{
		public override float MaxValue { get => 100; }
		public override float RegenAmount { get => 5; }
		public override float RecoveryTime
		{
			get { return Mathf.Max(TickRate, 2); }
		}

		public override float TickRate => base.TickRate;

	}
}
