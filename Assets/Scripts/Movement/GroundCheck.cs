using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// 
	/// </summary>

	[AddComponentMenu("Movement/Ground Check")]
	public class GroundCheck : MonoBehaviour
	{
		[SerializeField] private float groundDistance = 0.1f;
		[SerializeField] private LayerMask groundLayers;

		[ShowInInspector]
		public bool IsGrounded
		{
			get
			{
				return CheckGround();
			}
		}


		public bool CheckGround()
		{
			return Physics.CheckSphere(gameObject.transform.position, groundDistance, groundLayers);
		}
	}
}
