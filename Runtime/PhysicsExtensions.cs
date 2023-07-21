using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StrongExtensions
{
	public static class PhysicsExtensions
	{
		private const int MinBufferSize = 30;
		private static RaycastHit[] _internalSphereCastHitsBuffer = new RaycastHit[MinBufferSize];
		
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
		
		public static IEnumerable<RaycastHit> ConeCastAll
		(
			Vector3 origin,
			float maxRadius,
			Vector3 direction,
			float maxDistance,
			float coneAngle,
			int minValuesCount = 30
		)
		{
			if (minValuesCount > _internalSphereCastHitsBuffer.Length)
			{
				_internalSphereCastHitsBuffer = new RaycastHit[minValuesCount];
			}
			
			Vector3 vector3 = origin - new Vector3(0, 0, maxRadius);

			int castsCount = Physics.SphereCastNonAlloc(vector3, maxRadius, direction, _internalSphereCastHitsBuffer,
				maxDistance);

			return castsCount == 0
				? Array.Empty<RaycastHit>()
				: _internalSphereCastHitsBuffer.Take(castsCount)
					.Where(hit => Vector3.Angle(direction, hit.point - origin) < coneAngle).ToList();
		}

		public static void ClearHitsCache()
		{
			if (_internalSphereCastHitsBuffer.Length > MinBufferSize)
			{
				_internalSphereCastHitsBuffer = new RaycastHit[MinBufferSize];
			}
		}
	}
}