using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	[AddComponentMenu("Movement/Gravity")]
	[RequireComponent(typeof(MovementHandler))]
	public class Gravity : MonoBehaviour, IMovementModifier
	{
		[FoldoutGroup("Components")]
		[SerializeField]
		private CharacterController controller = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private MovementHandler movementHandler = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private GroundCheck groundCheck = null;

		[Header("Settings")]
		[SerializeField] private float groundedPullMagnitide = 50f;
		private readonly float gravityMagnitude = Physics.gravity.y;
		private bool wasGroundedLastframe;
		public Vector3 Value { get; private set; }

		private void OnEnable() => movementHandler.AddModifier(this);
		private void OnDisable() => movementHandler.RemoveModifier(this);
		private void Update() => ProcessGravity();

		private void OnValidate()
		{
			if (!controller)
			{
				controller = GetComponent<CharacterController>();
			}
			if (!movementHandler)
			{
				movementHandler = GetComponent<MovementHandler>();
			}
			if (!groundCheck)
			{
				groundCheck = GetComponent<GroundCheck>();
			}
		}

		private void ProcessGravity()
		{
			if (groundCheck.IsGrounded)
			{
				Value = new Vector3(Value.x, -groundedPullMagnitide, Value.z);
			}
			else if (wasGroundedLastframe)
			{
				Value = Vector3.zero;
			}
			else
			{
				Value = new Vector3(Value.x, Value.y + gravityMagnitude * Time.deltaTime, Value.z);
			}
			wasGroundedLastframe = groundCheck.IsGrounded;
		}
	}
}
