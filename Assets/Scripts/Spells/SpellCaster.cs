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

		public List<Spell> allSpells;
		public Spell EquippedSpell;


		private void Update()
		{

			if (Mouse.current.leftButton.isPressed)
			{
				if (!EquippedSpell.cooldown.IsActive)
				{
					EquippedSpell.cooldown.Start();
					Projectile proj = Instantiate(EquippedSpell.projectile, rightHand.transform.position, rightHand.transform.rotation, spellParent.transform).GetComponent<Projectile>();
					proj.StartMove(target.transform, 5f);
				}
				

				

			}

			if (EquippedSpell.cooldown.IsActive)
			{
				EquippedSpell.cooldown.Update(Time.deltaTime);
			}

		}

		public void Cast(Spell spell) // On left click behaviour
		{

		}

		public void SecondaryCast(Spell spell) //On right click behaviour
		{

		}

		public void AlternativeCast(Spell spell) // On alt + left click behaviour
		{

		}

	}
}
