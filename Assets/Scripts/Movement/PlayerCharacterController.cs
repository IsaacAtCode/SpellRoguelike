using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM;
using ECM.Controllers;
using Serendipitous.Input;
using ECM.Common;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	public class PlayerCharacterController : BaseCharacterController
	{

		public Camera playerCamera;

		InputPlayer input;

		[SerializeField]
		private float _walkSpeed = 5f;
		[SerializeField]
		private float _sprintSpeed = 10f;
		[SerializeField]
		private float _crouchSpeed = 2.5f;

		public float walkSpeed
		{
			get { return _walkSpeed; }
			set { _walkSpeed = Mathf.Max(0.0f, value); }
		}

		public float sprintSpeed
		{
			get { return _sprintSpeed; }
			set { _sprintSpeed = Mathf.Max(0.0f, value); }
		}

		public float crouchSpeed
		{
			get { return _crouchSpeed; }
			set { _crouchSpeed = Mathf.Max(0.0f, value); }
		}

		public float Speed
		{
			get
			{
				if (isCrouching)
				{
					return crouchSpeed;
				}
				if (isSprinting)
				{
					return sprintSpeed;
				}
				return walkSpeed;
			}
		}

		private void OnEnable()
		{
			input = new InputPlayer();

			input.Enable();

			input.Player.Sprint.started += ctx => Sprint();
			//input.Player.Sprint.performed += ctx => ToggleSprint();
			input.Player.Sprint.canceled += ctx => Sprint();

			input.Player.Crouch.started += ctx => Crouch();
			//input.Player.Crouch.performed += ctx => ToggleCrouch();
			input.Player.Crouch.canceled += ctx => Crouch();

			input.Player.Jump.performed += ctx => Jump();

		}

		private void OnDisable()
		{
			input.Player.Sprint.started -= ctx => Sprint();
			//input.Player.Sprint.performed -= ctx => ToggleSprint();
			input.Player.Sprint.canceled -= ctx => Sprint();

			input.Player.Crouch.started -= ctx => Crouch();
			//input.Player.Crouch.performed -= ctx => ToggleCrouch();
			input.Player.Crouch.canceled -= ctx => Crouch();

			input.Player.Jump.performed -= ctx => Jump();


			input.Disable();
		}

		protected override Vector3 CalcDesiredVelocity()
		{
			// Set 'BaseCharacterController' speed property based on this character state

			speed = Speed;

			// Return desired velocity vector

			return base.CalcDesiredVelocity();
		}



		protected override void HandleInput()
		{
			moveDirection = new Vector3
			{
				x = input.Player.Move.ReadValue<Vector2>().x,
				y = 0.0f,
				z = input.Player.Move.ReadValue<Vector2>().y
			};


			moveDirection = moveDirection.relativeTo(playerCamera.transform);
		}






	}
}
