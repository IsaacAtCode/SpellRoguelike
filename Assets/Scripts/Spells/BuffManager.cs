using Ludiq.PeekCore.ReflectionMagic;
using Serendipitous.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>

	public class BuffManager : MonoBehaviour
	{
		public List<SpellEffect> spellEffects = new List<SpellEffect>();


		//Resources
		//Stats

		public Health health;
		public Energy energy;



		private void OnValidate()
		{
			if (!health)
			{
				health = GetComponentInParent<Health>();
			}
		}

		private void Update()
		{
			if (spellEffects.Count > 0)
			{
				foreach (SpellEffect effect in spellEffects)
				{
					if (effect.isFinished)
					{
						RemoveSpellEffect(effect);
					}
				}
			}
		}




		public void AddSpellEffect(SpellEffect effect, bool isAOE = false)
		{
			spellEffects.Add(effect);
			effect.Apply(this, isAOE);

			//Sort Effects
		}

		public bool RemoveSpellEffect(SpellEffect effect)
		{
			if (spellEffects.Remove(effect))
			{
				effect.Remove();
				return true;
			}

			return false;
			
		}

		public bool RemoveAllEffectsFromSource(object source)
		{
			bool didRemove = false;

			for (int i = spellEffects.Count - 1; i >= 0 ; i--)
			{
				if (spellEffects[i].Source == source)
				{
					didRemove = true;

					spellEffects[i].Remove(); //Remove Behaviour

					spellEffects.RemoveAt(i);

				}
			}

			return didRemove;
		}

	}
}
