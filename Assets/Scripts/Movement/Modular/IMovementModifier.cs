using UnityEngine;

namespace Serendipitous.Movement
{
	/// <summary>
	/// Each script with this interface has a value that it outputs to the movement handler
	/// </summary>

	public interface IMovementModifier
	{
		Vector3 Value { get; }
	}
}
