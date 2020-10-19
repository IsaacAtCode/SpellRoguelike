using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	[AddComponentMenu("Movement/Movement Input Processor")]
	[RequireComponent(typeof(MovementHandler))]
	public class MovementInputProcessor : MonoBehaviour, IMovementModifier
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
		[SerializeField] private float movementSpeed = 5f;
		[SerializeField] private float acceleration = 0.1f;

		//private float currentSpeed;

		private Vector3 previousVelocity;
		private Vector2 previousInputDirection;

		private Transform mainCameraTransform;

		float turnSmoothVelocity;
		[SerializeField] private float groundSmoothTime = 0.1f;
		[SerializeField] private float airSmoothTime = 0.3f;


		public Vector3 Value { get; private set; }

		private void OnEnable() => movementHandler.AddModifier(this);
		private void OnDisable() => movementHandler.RemoveModifier(this);

		private void Start() => mainCameraTransform = Camera.main.transform;

		private void Update()
		{
			Move();
		}

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

		public void SetMovementInput(Vector2 inputDirection)
		{
			previousInputDirection = inputDirection;
		}

		public void SetMovementSpeed(float speed)
		{
			movementSpeed = speed;
		}



		private void Move()
		{
			float targetSpeed = movementSpeed * previousInputDirection.magnitude;

			//currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

			Vector3 movementDirection;
			float turnSmoothTime;

			if (!groundCheck.IsGrounded())
			{
				turnSmoothTime = airSmoothTime;
			}
			else
			{
				turnSmoothTime = groundSmoothTime;
			}


			if (targetSpeed != 0f)
			{
				float targetAngle = Mathf.Atan2(previousInputDirection.x, previousInputDirection.y) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

				transform.rotation = Quaternion.Euler(0, angle, 0f);

				movementDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			}
			else
			{
				movementDirection = previousVelocity.normalized;
			}

			Value = movementDirection * targetSpeed;

			previousVelocity = new Vector3(controller.velocity.x, 0f, controller.velocity.z);

			//currentSpeed = previousVelocity.magnitude;
		}


	}
}
