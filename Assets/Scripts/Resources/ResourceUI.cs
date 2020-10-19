using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Serendipitous
{
	/// <summary>
	/// 
	/// </summary>

	public class ResourceUI : MonoBehaviour
	{
		public Slider healthSlider;
		public Text healthText;

		public void UpdateSlider(float current, float max)
		{
			healthSlider.value = current / max;
			healthText.text = (int)current + "/" + (int)max;
		}
	}
}
