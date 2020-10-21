﻿using Ludiq.PeekCore;
using Serendipitous.Resources;
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
	public class SpellEffect
	{
		public object Source;
		public bool isFinished = false;
		public virtual void Apply(BuffManager buffManager, bool isAOE = false) { }
		public virtual void Remove() { }
	}

	

}