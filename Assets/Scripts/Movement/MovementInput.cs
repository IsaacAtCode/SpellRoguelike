using Serendipitous.Character;
using Serendipitous.PlayerInput;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	[RequireComponent(typeof(CharacterController))]
	public class MovementInput : MonoBehaviour
	{
		[FoldoutGroup("Components")]
		public CharacterAttributes ca;



		public float Velocity
		{
			get
			{
				if (IsCrouching)
				{
					return ca.crouchSpeed * ca.speedMulti;
				}
				if (IsSprinting)
				{
					return ca.sprintSpeed * ca.speedMulti;
				}

				return ca.walkSpeed * ca.speedMulti;
			}
		}

		public bool active = true;
		[Space]

		public float InputX;
		public float InputZ;
		public Vector3 desiredMoveDirection;
		public bool blockRotationPlayer;
		public float desiredRotationSpeed = 0.1f;
		//public Animator anim;
		public float inputMagnitude;
		public float allowPlayerRotation = 0.1f;
		public Camera cam;
		public CharacterController controller;
		[ShowInInspector]
		public bool IsGrounded => controller.isGrounded;

		[BoxGroup("Crouching")]
		public bool IsCrouching = false;
		[BoxGroup("Crouching")]
		public bool toggleCrouch = false;

		[BoxGroup("Sprinting")]
		public bool IsSprinting = false;
		[BoxGroup("Sprinting")]
		public bool toggleSprint = false;

		[ShowInInspector]
		[BoxGroup("Jumping")]
		public bool canJump = true;
		[ShowInInspector]
		[BoxGroup("Jumping")]
		public float JumpHeight { get => ca.jumpPower; }
		[ShowInInspector]
		[BoxGroup("Jumping")]
		public float AirJumpHeight { get => ca.airJumpPower; }
		[ShowInInspector]
		[BoxGroup("Jumping")]
		public int MaxMidAirJumps { get => ca.maxMidAirJumps; }
		[ShowInInspector]
		[BoxGroup("Jumping")]
		public int midAirJumpCount = 0;

		[BoxGroup("Gravity")]
		public Vector3 gravity = new Vector3(0f, -20f, 0f);


		[FoldoutGroup("Animation"),Range(0,1f)]
		public float HorizontalAnimSmoothTime = 0.2f;
		[FoldoutGroup("Animation"), Range(0, 1f)]
		public float VerticalAnimTime = 0.2f;
		[FoldoutGroup("Animation"), Range(0, 1f)]
		public float StartAnimTime = 0.3f;
		[FoldoutGroup("Animation"), Range(0, 1f)]
		public float StopAnimTime = 0.15f;

		public float verticalVel;
		public Vector3 moveVector;


		InputPlayer input;



		// Use this for initialization
		void Start()
		{
			//anim = this.GetComponentInChildren<Animator>();
			if (!cam)
			{
				cam = Camera.main;
			}
			if (!ca)
			{
				ca = GetComponent<CharacterAttributes>();
			}
			if (!controller)
			{
				controller = GetComponent<CharacterController>();
			}

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		// Update is called once per frame
		void Update()
		{
			InputMagnitude();


			//if (IsGrounded)
			//{
			//	verticalVel -= 0;
			//}
			//else
			//{
			//	verticalVel -= 1;
			//}
			//moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);

			controller.Move(moveVector);
		}

		void PlayerMoveAndRotation(float InputX, float InputZ)
		{
			var forward = cam.transform.forward;
			var right = cam.transform.right;

			forward.y = 0f;
			right.y = 0f;

			forward.Normalize();
			right.Normalize();

			desiredMoveDirection = forward * InputZ + right * InputX;

			if (blockRotationPlayer == false)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
				controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
			}
		}

		public void LookAt(Vector3 pos)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
		}

		public void RotateToCamera(Transform t)
		{
			var forward = cam.transform.forward;
			var right = cam.transform.right;

			desiredMoveDirection = forward;

			t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
		}

		void InputMagnitude()
		{
			//Calculate Input Vectors
			//InputX = active ? input.Player.Move.ReadValue<Vector2>().x : 0;
			//InputZ = active ? input.Player.Move.ReadValue<Vector2>().y : 0;

			InputX = input.Player.Move.ReadValue<Vector2>().x;
			InputZ = input.Player.Move.ReadValue<Vector2>().y;


			//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
			//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

			//Calculate the Input Magnitude
			inputMagnitude = new Vector2(InputX, InputZ).sqrMagnitude;

			//Physically move player

			if (inputMagnitude > allowPlayerRotation)
			{
				//anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
				PlayerMoveAndRotation(InputX, InputZ);
			}
			else if (inputMagnitude < allowPlayerRotation)
			{
				//anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
			}
		}


		private void Crouch()
		{
			if (toggleCrouch)
			{
				IsCrouching = !IsCrouching;
			}
		}

		private void Crouch(bool sprint)
		{
			if (!toggleCrouch)
			{
				IsCrouching = sprint;
			}
		}

		private void Sprint()
		{
			if (toggleSprint)
			{
				IsSprinting = !IsSprinting;
			}
		}

		private void Sprint(bool sprint)
		{
			if (!toggleSprint)
			{
				IsSprinting = sprint;
			}
		}

		private bool isJumping = false;

		private void Jump()
		{
			Vector3 jumpVector = new Vector3(0, JumpHeight, 0);



			if (isJumping)
			{
				if (IsGrounded)
				{
					isJumping = false;
				}
			}

			if (!isJumping)
			{
				controller.Move(jumpVector);
				isJumping = true;
			}



			//if (!IsGrounded && midAirJumpCount < MaxMidAirJumps)
			//{
			//	moveVector.y += AirJumpHeight;
			//	midAirJumpCount++;
			//}
		}









		private void Awake()
		{
			input = new InputPlayer();
		}

		private void OnEnable()
		{
			input.Enable();

			input.Player.Sprint.started += ctx => Sprint(true);
			input.Player.Sprint.performed += ctx => Sprint();
			input.Player.Sprint.canceled += ctx => Sprint(false);

			input.Player.Crouch.started += ctx => Crouch(true);
			input.Player.Crouch.performed += ctx => Crouch();
			input.Player.Crouch.canceled += ctx => Crouch(false);

			input.Player.Jump.started += ctx => Jump();
		}

		private void OnDisable()
		{
			input.Player.Sprint.started -= ctx => Sprint(true);
			input.Player.Sprint.performed -= ctx => Sprint();
			input.Player.Sprint.canceled -= ctx => Sprint(false);

			input.Player.Crouch.started -= ctx => Crouch(true);
			input.Player.Crouch.performed -= ctx => Crouch();
			input.Player.Crouch.canceled -= ctx => Crouch(false);

			input.Player.Jump.started -= ctx => Jump();

			input.Disable();
		}

		private void OnValidate()
		{
			if (!cam)
			{
				cam = Camera.main;
			}
			if (!ca)
			{
				ca = GetComponent<CharacterAttributes>();
			}
			if (!controller)
			{
				controller = GetComponent<CharacterController>();
			}

		}

	}
}
