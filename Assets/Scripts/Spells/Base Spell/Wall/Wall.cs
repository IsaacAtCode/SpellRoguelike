using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous
{
	/// <summary>
	/// 
	/// </summary>

	public class Wall : MonoBehaviour
	{
		[BoxGroup("Components"), SerializeField]
		private Animator anim;
		[BoxGroup("Components"), SerializeField]
		private GameObject wallModel;
		//Replace with prefab

		[BoxGroup("Stats")]
		public float width = 1;
		[BoxGroup("Stats")]
		public float height = 3;
		[BoxGroup("Stats")]
		public float length = 8;

		[BoxGroup("Stats")]
		public float undergroundOffset = 0.2f;

		private Vector3 Scale
		{
			get
			{
				return new Vector3(length, height, width);
			}
		}

		[BoxGroup("Lifetime")]
		public float growTime = 2.5f;
		[BoxGroup("Lifetime")]
		public float lifeTime = 10f;

		private bool isSpawning = false;





		public void Spawn(Vector3 position, Vector3 target)
		{
			isSpawning = true;




			GameObject wall = Instantiate(wallModel, this.transform);
			wall.name = "Wall";



			//Set Scale of WallModel
			wall.transform.localScale = Scale;

			Vector3 newPos = new Vector3(position.x,  height / 2 - undergroundOffset, position.z);


			//Set WorldPosition
			wall.transform.position = newPos;

			//Set Rotation
			Vector3 newTarget = new Vector3(target.x, wall.transform.position.y, target.y);

			wall.transform.LookAt(newTarget);

			isSpawning = false;

			DestroyWall(wall);

		}

		IEnumerator DestroyWall(GameObject wallToDestroy)
		{
			float duration = lifeTime;

			while (duration > 0)
			{
				duration -= 0.5f;

				yield return new WaitForSeconds(0.5f);

				if (duration <= 0)
				{
					Destroy(wallToDestroy);
				}

			}
		}

		//Make sure always grounded


	}
}
