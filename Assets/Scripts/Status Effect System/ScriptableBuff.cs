using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous
{
	/// <summary>
	/// Base class for every status effect
	/// </summary>

	public abstract class ScriptableBuff : ScriptableObject
	{
		public float Duration;

		public bool IsDurationStacked;

		public bool IsEffectStacked;
	}
}