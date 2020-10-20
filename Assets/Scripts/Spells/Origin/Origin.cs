using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serendipitous.Spells
{
	/// <summary>
	/// 
	/// </summary>
	
	[Serializable]
	public abstract class Origin
	{
		[HorizontalGroup("Target")]
		public TargetType targetType;

		[ShowInInspector]
		[HorizontalGroup("Target", 75), HideLabel, ]
		public int TargetInt 
		{
			get => (int)targetType; 
		}

		[BoxGroup("Variables")]
		public float duration = 30f; //Seconds

		public abstract void Cast(Transform SpawnLocation, Vector3 location);

	}

	public enum SpellType
	{
		Projectile,
		Area,
		Summon,
	}

	[Flags]
	public enum TargetType
	{
		SelfCast = 0,
		NoTarget = 1,
		TargetUnit = 2,
		TargetPoint = 4,
		TargetArea = 8,
	}

	//Self Cast = 0
	//NoTarget = 1 / 3 / 5 / 7 / 9 / 11 / 13 / 15
	//TargetUnit = 2 / 3 / 6 / 7 / 10 / 11 / 14 / 15
	//Target Point = 4 / 5 / 6 / 7 / 12 / 13 / 14 / 15
	//Target Area = 8 / 9 / 10 / 11 / 12 / 13 / 14 / 15

	//	All possible combinations of values with TargetType:
	//         0 - SelfCast
	//         1 - NoTarget
	//         2 - TargetUnit
	//         3 - NoTarget, TargetUnit
	//         4 - TargetPoint
	//         5 - NoTarget, TargetPoint
	//         6 - TargetUnit, TargetPoint
	//         7 - NoTarget, TargetUnit, TargetPoint
	//         8 - TargetArea
	//         9 - NoTarget, TargetArea
	//        10 - TargetUnit, TargetArea
	//        11 - NoTarget, TargetUnit, TargetArea
	//        12 - TargetPoint, TargetArea
	//        13 - NoTarget, TargetPoint, TargetArea
	//        14 - TargetUnit, TargetPoint, TargetArea
	//        15 - NoTarget, TargetUnit, TargetPoint, TargetArea
	//        16 - 16



}
