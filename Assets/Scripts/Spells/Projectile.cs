﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>

	public class Projectile : MonoBehaviour
	{
		public Transform target;
		public float speed;
		public float accel = 1f;

		public void StartMove(Transform newTarget, float newSpeed)
		{
			target = newTarget;
			speed = newSpeed;
		}


		private void Update()
		{

			if (Vector3.Distance(transform.position, target.position) < 0.1f)
			{
				Debug.Log("Hit");
				Destroy(this.gameObject);
			}

			if (target && speed != 0)
			{
				speed += accel * Time.deltaTime;

				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, target.position, step);
			}


		}
	}
}