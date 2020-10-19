using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// Moves object in Value direction
	/// </summary>

	public interface IMovementModifier
	{
		Vector3 Value { get; }
	}
}
