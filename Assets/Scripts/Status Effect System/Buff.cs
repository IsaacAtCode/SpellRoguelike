using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous
{
	/// <summary>
	/// 
	/// </summary>

	public abstract class Buff
	{
		protected bool _isAOE = false;
		public bool IsAOE { get => _isAOE; set => _isAOE = value; }

		protected float Duration;
		protected int EffectStacks;
		public ScriptableBuff sBuff { get; }
		protected readonly GameObject Obj;
		public bool IsFinished;

		public Buff(ScriptableBuff buff, GameObject obj)
		{
			sBuff = buff;
			Obj = obj;
		}

		public void Tick(float delta)
		{
			Duration -= delta;
			if (Duration <= 0)
			{
				End();
				IsFinished = true;
			}
		}

		public void Activate()
		{
			if (sBuff.IsEffectStacked || Duration <=0)
			{
				ApplyEffect();
				EffectStacks++;
			}

			if (sBuff.IsDurationStacked || Duration <=0)
			{
				Duration += sBuff.Duration;
			}
		}

		protected abstract void ApplyEffect();

		public abstract void End();
	}
}
