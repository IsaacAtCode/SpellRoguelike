using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.PlayerInput
{
	/// <summary>
	/// 
	/// </summary>

	public class CursorManager : MonoBehaviour
	{
		public KeyCode escapeKeyCode;

		private void Start()
		{
			LockCursor();
		}


		private void Update()
		{
			if (Input.GetKeyDown(escapeKeyCode))
			{
				UnlockCursor();
			}
		}


		public void LockCursor()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		public void UnlockCursor()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
