using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Serendipitous
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class UnityFloatEvent : UnityEvent<float> { }

	[Serializable]
	public class UnityFloat2Event : UnityEvent<float, float> { }


	[Serializable]
	public class UnityBoolEvent : UnityEvent<bool> { }

	[Serializable]
	public class UnityIntEvent : UnityEvent<int> { }

	[Serializable]
	public class UnityStringEvent : UnityEvent<string> { }


}
