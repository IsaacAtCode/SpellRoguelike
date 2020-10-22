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

	[RequireComponent(typeof(Collider))]
	public class AOE : MonoBehaviour
	{
		public float radius = 7.5f;
		public float height = 3f;


		public DamageOverTime dot;

		private void OnEnable()
		{
			SetSize(radius, height);
		}

		private void SetSize(float rad, float h)
		{
			Vector3 newScale = new Vector3(rad*2, h, rad*2);
			transform.localScale = newScale;
		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") || other.CompareTag("Enemy"))
			{
				GameObject obj = other.gameObject;

				if (obj.GetComponentInChildren<BuffManager>())
				{
					obj.GetComponentInChildren<BuffManager>().AddSpellEffect(dot);

					Debug.Log("Entered AOE");

				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			
		}
	}
}
