using Serendipitous.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	public class PlayerMove : CharacterMove
	{
		private InputPlayer input;

		private void Awake()
		{
			input = new InputPlayer();
		}

		private void OnEnable()
		{
			input.Enable();

			input.Player.Sprint.started += ctx => StartSprint();
			input.Player.Sprint.performed += ctx => ToggleSprint();
			input.Player.Sprint.canceled += ctx => EndSprint();

			input.Player.Crouch.started += ctx => StartCrouch();
			input.Player.Crouch.performed += ctx => ToggleCrouch();
			input.Player.Crouch.canceled += ctx => EndCrouch();

			input.Player.Jump.performed += ctx => Jump();

		}

		private void OnDisable()
		{
			input.Player.Sprint.started -= ctx => StartSprint();
			input.Player.Sprint.performed -= ctx => ToggleSprint();
			input.Player.Sprint.canceled -= ctx => EndSprint();

			input.Player.Crouch.started -= ctx => StartCrouch();
			input.Player.Crouch.performed -= ctx => ToggleCrouch();
			input.Player.Crouch.canceled -= ctx => EndCrouch();

			input.Player.Jump.performed -= ctx => Jump();


			input.Disable();
		}

		private void Update()
		{
			newInput = input.Player.Move.ReadValue<Vector2>();

			Move();

			//Debug.Log(controller.velocity);
		}


		private void StartSprint()
		{
			if (!toggleSprint)
			{
				//Debug.Log("Start Sprint");

				IsSprinting = true;
				//Sprint();
			}
		}

		private void EndSprint()
		{
			if (!toggleSprint)
			{
				//Debug.Log("End Sprint");

				IsSprinting = false;
				//Sprint();
			}
		}

		private void ToggleSprint()
		{
			if (toggleSprint)
			{
				//Debug.Log("Toggled Sprint");

				IsSprinting = !IsSprinting;
				//Sprint();
			}
		}

		private void StartCrouch()
		{
			if (!toggleCrouch)
			{
				IsCrouching = true;
				////Crouch();
			}
		}

		private void EndCrouch()
		{
			if (!toggleCrouch)
			{
				IsCrouching = false;
				////Crouch();
			}
		}

		private void ToggleCrouch()
		{
			if (toggleCrouch)
			{
				IsCrouching = !IsCrouching;
				////Crouch();
			}
		}

	}
}
