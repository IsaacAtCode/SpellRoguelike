using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Character
{
	/// <summary>
	/// 
	/// </summary>

	public class CharacterAttributes : MonoBehaviour
	{
		[FoldoutGroup("Movement")]
		[BoxGroup("Movement/Move")]
		public float walkSpeed = 5f;
		[BoxGroup("Movement/Move")]
		public float sprintSpeed = 10f;
		[BoxGroup("Movement/Move")]
		public float crouchSpeed = 2.5f;
		[BoxGroup("Movement/Move")]
		public float speedMulti = 1f;

		[BoxGroup("Movement/Jump")]
		public float jumpPower = 15f;
		[BoxGroup("Movement/Jump")]
		public int maxMidAirJumps = 1;
		[BoxGroup("Movement/Jump")]
		public float airJumpPower = 10f;

		[BoxGroup("Mass")]
		public float mass = 1f;

	}
}
