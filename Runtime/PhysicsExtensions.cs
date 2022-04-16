using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StrongExtensions
{
	public static class PhysicsExtensions
	{
		public static IEnumerable<RaycastHit> ConeCastAll
		(
			Vector3 origin,
			float maxRadius,
			Vector3 direction,
			float maxDistance,
			float coneAngle,
			RaycastHit[] sphereCastHits
		)
		{
			Vector3 vector3 = origin - new Vector3(0, 0, maxRadius);

			return Physics.SphereCastNonAlloc(vector3, maxRadius, direction, sphereCastHits, maxDistance) <= 0
				? sphereCastHits
				: sphereCastHits.Where(hit => Vector3.Angle(direction, hit.point - origin) < coneAngle);
		}
	}
}