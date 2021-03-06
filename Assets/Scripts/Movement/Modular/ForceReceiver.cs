﻿using Serendipitous.Character;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	[AddComponentMenu("Movement/Force Receiver")]
	[RequireComponent(typeof(MovementHandler))]
	public class ForceReceiver : MonoBehaviour, IMovementModifier
	{
		[FoldoutGroup("Components")]
		[SerializeField]
		private CharacterAttributes attributes = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private CharacterController controller = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private MovementHandler movementHandler = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private GroundCheck groundCheck = null;

		[PropertySpace]

		[ShowInInspector] 
		private float Mass => attributes.mass;
		[SerializeField] private float drag = 5f;

		private bool wasGroundedLastFrame;

		public Vector3 Value { get; private set; }

		private void OnEnable() => movementHandler.AddModifier(this);

		private void OnDisable() => movementHandler.RemoveModifier(this);

		private void Update()
		{
			if (!wasGroundedLastFrame && groundCheck.IsGrounded)
			{
				Value = new Vector3(Value.x, 0f, Value.z);
			}

			wasGroundedLastFrame = groundCheck.IsGrounded;

			if (Value.magnitude < 0.2f)
			{
				Value = Vector3.zero;
			}

			Value = Vector3.Lerp(Value, Vector3.zero, drag * Time.deltaTime);
		}

		public void AddForce(Vector3 force) => Value += force / Mass;

		private void OnValidate()
		{
			if (!attributes)
			{
				attributes = GetComponent<CharacterAttributes>();
			}

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
	}
}
