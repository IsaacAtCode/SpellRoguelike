using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Serendipitous.Spells
{
	/// <summary>
	/// Casts the equipped spell
	/// </summary>

	public class SpellCaster : MonoBehaviour
	{
		//public Transform leftHand;
		public Transform rightHand;

		public GameObject spellParent;

		public GameObject target;

		//public bool isRightHanded = true;

		//Transform spawnLocation, GameObject parent, Transform target)

		//public List<Spell> allSpells;
		//public Spell EquippedSpell;

		//public Spell spell;

		public Wall wall;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;

				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject.layer == 25)
					{
						wall.Spawn(hit.point, this.transform.position);
					}

				}

				
			}
		}

		private void CastSpell()
		{

		}

		private void CastProjectile()
		{

		}

		private void CastWall()
		{

		}

		private void CastArea()
		{

		}


	}
}
