using Serendipitous.Character;
using Serendipitous.PlayerInput;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	public class PlayerMovement : MonoBehaviour
	{
		[FoldoutGroup("Components"), SerializeField]
		private CharacterAttributes attributes;
		[FoldoutGroup("Components"), SerializeField]
		private MovementInputProcessor inputProcessor;
		[FoldoutGroup("Components"), SerializeField]
		private ForceReceiver forceReceiver;
		[FoldoutGroup("Components"), SerializeField]
		private GroundCheck groundCheck;


		[FoldoutGroup("Animation"), SerializeField]
		private Animator anim;
		[FoldoutGroup("Animation"), Range(0, 1f)]
		public float StartAnimTime = 0.3f;
		[FoldoutGroup("Animation"), Range(0, 1f)]
		public float StopAnimTime = 0.15f;

		//Movement
		[FoldoutGroup("Movement")]
		public bool canMove = true;

		[ShowInInspector, FoldoutGroup("Movement")]
		public float MovementSpeed
		{
			get
			{
				if (canMove)
				{


					if (IsCrouching)
					{
						return attributes.crouchSpeed * attributes.speedMulti;
					}
					if (IsSprinting)
					{
						return attributes.sprintSpeed * attributes.speedMulti;
					}

					return attributes.walkSpeed * attributes.speedMulti;
				}

				return 0;
			}
		}

		public Vector2 MoveDirection{ get => inputs.Player.Move.ReadValue<Vector2>(); }



		//Sprinting
		private bool _isSprinting;
		[ShowInInspector, BoxGroup("Movement/Sprinting")]
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
		[BoxGroup("Movement/Sprinting")]
		public bool toggleSprint;


		//Crouching
		bool _isCrouching = false;
		[ShowInInspector, BoxGroup("Movement/Crouching")]
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
		[BoxGroup("Movement/Crouching")]
		public bool toggleCrouch;


		//Jumping
		[SerializeField]
		private int jumpCount = 0;

		private void Update()
		{
			Move();
		}


		private void Move()
		{
			inputProcessor.SetMovementInput(MoveDirection);

			anim.SetFloat("InputX", MoveDirection.x);
			anim.SetFloat("InputY", MoveDirection.y);


			if (MoveDirection.magnitude > 0.1f)
			{
				inputProcessor.SetMovementSpeed(MovementSpeed);
				anim.SetFloat("Speed", MovementSpeed, StartAnimTime, Time.deltaTime);
			}
			else
			{
				inputProcessor.SetMovementSpeed(0);
				anim.SetFloat("Speed", 0, StopAnimTime, Time.deltaTime);
			}
		}



		private void Sprint(bool toSprint, bool toggle = false)
		{
			if (toggle)
			{
				IsSprinting = !IsSprinting;
			}
			else
			{
				IsSprinting = toSprint;
			}
		}


		private void Crouch(bool toCrouch, bool toggle = false)
		{
			if (toggle)
			{
				IsCrouching = !IsCrouching;
			}
			else
			{
				IsCrouching = toCrouch;
			}
		}


		private void Jump()
		{
			float currJumpHeight;

			if (groundCheck.IsGrounded)
			{
				jumpCount = 0;

				anim.ResetTrigger("Jump");
			}

			if (jumpCount <= attributes.maxMidAirJumps)
			{
				if (jumpCount < 1)
				{
					currJumpHeight = attributes.airJumpPower;
				}
				else
				{
					currJumpHeight = attributes.jumpPower;
				}

				Vector3 jumpAmount = new Vector3(0, currJumpHeight, 0);

				anim.SetTrigger("Jump");

				forceReceiver.AddForce(jumpAmount);
				jumpCount++;

				anim.SetInteger("JumpCount", jumpCount);
			}
		}









		#region Input

		InputPlayer inputs;

		private void Awake()
		{
			inputs = new InputPlayer();	
		}

		private void OnEnable()
		{
			inputs.Enable();

			inputs.Player.Jump.started += ctx => Jump();

			inputs.Player.Sprint.started += ctx => Sprint(true);
			inputs.Player.Sprint.performed += ctx => Sprint(IsSprinting, toggleSprint);
			inputs.Player.Sprint.canceled += ctx => Sprint(false);

			inputs.Player.Crouch.started += ctx => Crouch(true);
			inputs.Player.Crouch.performed += ctx => Crouch(IsCrouching, toggleCrouch);
			inputs.Player.Crouch.canceled += ctx => Crouch(false);
		}

		private void OnDisable()
		{
			inputs.Player.Jump.started -= ctx => Jump();

			inputs.Player.Sprint.started -= ctx => Sprint(true);
			inputs.Player.Sprint.performed -= ctx => Sprint(IsSprinting, toggleSprint);
			inputs.Player.Sprint.canceled -= ctx => Sprint(false);

			inputs.Player.Crouch.started -= ctx => Crouch(true);
			inputs.Player.Crouch.performed -= ctx => Crouch(IsCrouching, toggleCrouch);
			inputs.Player.Crouch.canceled -= ctx => Crouch(false);

			inputs.Disable();
		}


		#endregion

		private void OnValidate()
		{
			if (!attributes)
			{
				attributes = GetComponent<CharacterAttributes>();
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
			if (!anim)
			{
				anim = GetComponentInChildren<Animator>();
			}

		}
	}
}
