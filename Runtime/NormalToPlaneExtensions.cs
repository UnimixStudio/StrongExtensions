using UnityEngine;

namespace StrongExtensions
{
	public static class NormalToPlaneExtensions
	{
		public static Vector3 CalculateNormalToPlane(this Transform from, Vector3 to)
		{
			Vector3 directionFromTo = to - from.position;

			Vector3 normalToPlane = Vector3.Cross(directionFromTo, from.forward).normalized;

			return normalToPlane;
		}

		public static Vector3 CalculateNormalToPlane(this Transform from, Transform to) =>
			CalculateNormalToPlane(from, to.position);

		public static Vector3 CalculateNormalToPlane(this Component from, Transform to) =>
			CalculateNormalToPlane(from.transform, to);

		public static Vector3 CalculateNormalToPlane(this Transform from, Component to) =>
			CalculateNormalToPlane(from, to.transform);

		public static Vector3 CalculateNormalToPlane(this Component from, Component to) =>
			CalculateNormalToPlane(from.transform, (Component)to.transform);

		public static Vector3 CalculateNormalToPlane(this Component from, Vector3 to) =>
			CalculateNormalToPlane(from.transform, to);

		public static Vector3 CalculateNormalToPlane(this Transform from, GameObject to) =>
			CalculateNormalToPlane(from, to.transform);

		public static Vector3 CalculateNormalToPlane(this Component from, GameObject to) =>
			CalculateNormalToPlane(from.transform, to.transform);

		public static Vector3 CalculateNormalToPlane(this GameObject from, Transform to) =>
			CalculateNormalToPlane(from.transform, to);

		public static Vector3 CalculateNormalToPlane(this GameObject from, Component to) =>
			CalculateNormalToPlane(from.transform, to.transform);

		public static Vector3 CalculateNormalToPlane(this GameObject from, Vector3 to) =>
			CalculateNormalToPlane(from.transform, to);

		public static Vector3 CalculateNormalToPlane(this GameObject from, GameObject to) =>
			CalculateNormalToPlane(from.transform, to.transform);
	}
}