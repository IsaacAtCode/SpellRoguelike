using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	public class CharacterMove : MonoBehaviour
	{
		[FoldoutGroup("Components")]
		[SerializeField]
		private CharacterController controller = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private MovementInputProcessor inputProcessor = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private ForceReceiver forceReceiver = null;
		[FoldoutGroup("Components")]
		[SerializeField]
		private GroundCheck groundCheck = null;

		[BoxGroup("Speed")]
		public float walkSpeed = 5;
		[BoxGroup("Speed")]
		public float sprintSpeed = 10f;
		[BoxGroup("Speed")]
		public float crouchSpeed = 2.5f;

		[BoxGroup("Sprinting")]
		public bool toggleSprint = false;
		[BoxGroup("Crouching")]
		public bool toggleCrouch = false;

		[ShowInInspector]
		public float Speed
		{
			get
			{
				if (IsCrouching)
				{
					return crouchSpeed;
				}
				if (IsSprinting)
				{
					return sprintSpeed;
				}
				return walkSpeed;
			}
		}

		bool _isCrouching = false;
		[ShowInInspector]
		[BoxGroup("Crouching")]
		public bool IsCrouching
		{
			get { return _isCrouching; }
			set
			{
				if (toggleSprint && value == true)
				{
					IsSprinting = false;
				}

				_isCrouching = value;
			}
		}

		private bool _isSprinting;
		[ShowInInspector]
		[BoxGroup("Sprinting")]
		public bool IsSprinting
		{
			get { return _isSprinting; }
			set
			{
				if (toggleCrouch && value == true)
				{
					IsCrouching = false;
				}

				_isSprinting = value;
			}
		}

		[BoxGroup("Jumping")]
		[SerializeField]
		private int jumpCount = 0;
		[BoxGroup("Jumping")]
		public float jumpHeight = 15;
		[BoxGroup("Jumping")]
		public int maxJumps = 1;

		protected Vector2 newInput;

		private void OnValidate()
		{
			if (!controller)
			{
				controller = GetComponent<CharacterController>();
			}

			if (!inputProcessor)
			{
				inputProcessor = GetComponent<MovementInputProcessor>();
			}

			if (!forceReceiver)
			{
				forceReceiver = GetComponent<ForceReceiver>();
			}

			if (!groundCheck)
			{
				groundCheck = GetComponent<GroundCheck>();
			}
		}

		protected virtual void Move()
		{
			inputProcessor.SetMovementInput(newInput);
			if (newInput.magnitude > 0.1f)
			{
				inputProcessor.SetMovementSpeed(Speed);
			}
			else
			{
				inputProcessor.SetMovementSpeed(0f);
			}
		}

		protected virtual void Jump()
		{
			Vector3 jumpAmount = new Vector3(0, jumpHeight, 0);

			if (groundCheck.IsGrounded())
			{
				jumpCount = 0;
			}

			if (groundCheck.IsGrounded() || jumpCount <= maxJumps)
			{
				forceReceiver.AddForce(jumpAmount);
				jumpCount++;
			}
		}




	}
}
