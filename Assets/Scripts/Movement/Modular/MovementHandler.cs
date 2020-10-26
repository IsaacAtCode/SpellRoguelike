using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>
	[RequireComponent(typeof(CharacterController))]
	[AddComponentMenu("Movement/Movement Handler")]
	public class MovementHandler : MonoBehaviour
	{
		[FoldoutGroup("Components")]
		[SerializeField]
		private CharacterController controller = null;

		[ShowInInspector]
		private readonly List<IMovementModifier> modifiers = new List<IMovementModifier>();

		private void Update() => Move();

		private void OnValidate()
		{
			if (!controller)
			{
				controller = GetComponent<CharacterController>();
			}
		}

		public void AddModifier(IMovementModifier modifier) => modifiers.Add(modifier);
		public void RemoveModifier(IMovementModifier modifier) => modifiers.Remove(modifier);

		private void Move()
		{
			Vector3 movement = Vector3.zero;

			foreach (IMovementModifier modifier in modifiers)
			{
				movement += modifier.Value;
				//Debug.Log(modifier.Value);
			}

			controller.Move(movement * Time.deltaTime);
			//Debug.Log("Moving " + movement);
		}
	}
}
