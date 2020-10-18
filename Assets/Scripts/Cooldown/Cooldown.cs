using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Serendipitous
{
	/// <summary>
	/// Script used for Cooldowns. Can Get total time, time remaining and percetn value
	/// </summary>

	[System.Serializable]
	public class Cooldown
	{
		[ShowInInspector]
		public float TimeRemaining { get; private set; }
		[ShowInInspector]
		public float TotalTime { get; private set; }
		public bool IsActive { get; private set; }
		public int TimesCounted { get; private set; }

		public float TimeElapsed => TotalTime - TimeRemaining;
		public float PercentElapsed => TimeElapsed / TotalTime;
		public bool IsCompleted => TimeRemaining <= 0;

		public delegate void TimerCompleteHandler();

		public event TimerCompleteHandler TimerCompleteEvent;

		public Cooldown(float time)
		{
			TotalTime = time;
			TimeRemaining = TotalTime;
		}

		public void Start()
		{
			if (IsActive) { TimesCounted++; }
			TimeRemaining = TotalTime;
			IsActive = true;
			if (TimeRemaining <= 0)
			{
				TimerCompleteEvent?.Invoke();
			}
		}

		public void Start(float time)
		{
			TotalTime = time;
			Start();
		}

		public void Update(float timeDelta)
		{
			if (TimeRemaining > 0 && IsActive)
			{
				TimeRemaining -= timeDelta;
				if (TimeRemaining <= 0)
				{
					IsActive = false;
				}

				TimerCompleteEvent?.Invoke();
				TimesCounted++;
			}
		}

		public void Invoke()
		{
			TimerCompleteEvent?.Invoke();
		}

		public void Pause()
		{
			IsActive = false;
		}

		public void AddTime(float time)
		{
			TimeRemaining += time;
			TotalTime += time;
		}


	}
}
