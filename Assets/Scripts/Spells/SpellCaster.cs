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

		public Cooldown cooldown =  new Cooldown(2);

		public GameObject projectile;


		private void Update()
		{

			if (Mouse.current.leftButton.isPressed)
			{
				Cast();
			}

			if (cooldown.IsActive)
			{
				cooldown.Update(Time.deltaTime);
			}

		}

		public void Cast() // On left click behaviour
		{
			if (!cooldown.IsActive)
			{
				cooldown.Start();
				Projectile proj = Instantiate(projectile, rightHand.transform.position, rightHand.transform.rotation, spellParent.transform).GetComponent<Projectile>();
				proj.StartMove(target.transform, 5f);
			}
		}

		public void SecondaryCast(Spell spell) //On right click behaviour
		{

		}

		public void AlternativeCast(Spell spell) // On alt + left click behaviour
		{

		}

	}
}
