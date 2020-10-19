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
		[SerializeField] private float groundDistance = 0.01f;
		[SerializeField] private LayerMask groundLayers;

		public bool IsGrounded()
		{
			return Physics.CheckSphere(gameObject.transform.position, groundDistance, groundLayers);
		}
	}
}
