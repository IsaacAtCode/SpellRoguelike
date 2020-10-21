using Serendipitous.Spells;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Serendipitous.AreaOfEffect
{
	/// <summary>
	/// 
	/// </summary>

	public class AOE : MonoBehaviour
	{
		public DamageOverTime dot;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") || other.CompareTag("Enemy"))
			{
				GameObject obj = other.gameObject;

				if (obj.GetComponentInChildren<BuffManager>())
				{
					obj.GetComponentInChildren<BuffManager>().AddSpellEffect(dot);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			
		}
	}
}
