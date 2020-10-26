using Serendipitous.Resources;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>

	public class StatusEffectManager : MonoBehaviour
	{
		[SerializeField]
		private readonly Dictionary<ScriptableBuff, Buff> _buffs = new Dictionary<ScriptableBuff, Buff>();

		private void Update()
		{
			foreach (var buff in _buffs.Values.ToList())
			{
				buff.Tick(Time.deltaTime);

				if (buff.IsFinished)
				{
					_buffs.Remove(buff.sBuff);
				}
			}
		}


		public void AddBuff(Buff buff)
		{
			if (_buffs.ContainsKey(buff.sBuff))
			{
				_buffs[buff.sBuff].Activate();
			}
			else
			{
				_buffs.Add(buff.sBuff, buff);
				buff.Activate();
			}
		}





	}
}
