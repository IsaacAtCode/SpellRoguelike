using Ludiq.PeekCore;
using Serendipitous.Resources;
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
	public class StatusEffect
	{
		public object Source;
		public bool isFinished = false;
		public virtual void Apply() { }

		public virtual void Tick() { }

		public virtual void Remove() { }
	}

	public interface IStackable
	{
		void ApplyStack();
		void ApplyStacks(int i);
		void RemoveStack();
		void RemoveStacks(int i);
		void RemoveAllStacks();
	}
}
