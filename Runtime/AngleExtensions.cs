using UnityEngine;

namespace StrongExtensions
{
	public static class AngleExtensions
	{
		public static float AngleTo(this GameObject gameObject, GameObject target) =>
			AngleTo(gameObject.transform, target.transform);

		public static float AngleTo(this GameObject gameObject, Transform target) =>
			AngleTo(gameObject.transform, target);

		public static float AngleTo(this GameObject gameObject, Component target) =>
			AngleTo(gameObject.transform, target.transform);

		public static float AngleTo(this Component component, GameObject target) =>
			AngleTo(component.transform, target.transform);

		public static float AngleTo(this Component component, Component target) =>
			AngleTo(component.transform, target.transform);

		public static float AngleTo(this Component component, Transform target) =>
			AngleTo(component.transform, target);

		public static float AngleTo(this Transform transform, GameObject target) =>
			AngleTo(transform, target.transform);

		public static float AngleTo(this Transform transform, Component target) =>
			AngleTo(transform, target.transform);

		public static float AngleTo(this Transform transform, Transform target)
		{
			Vector3 direction = target.position - transform.position;
			return Vector3.Angle(transform.forward, direction);
		}

		public static float AngleTo(this Transform transform, Transform target, Vector3 normal)
		{
			Vector3 direction = target.position - transform.position;
			Vector3 projectedForward = Vector3.ProjectOnPlane(transform.forward, normal);
			Vector3 projectedDirection = Vector3.ProjectOnPlane(direction, normal);

			return Vector3.Angle(projectedForward, projectedDirection);
		}

		public static float AngleTo(this GameObject gameObject, Transform target, Vector3 normal) =>
			AngleTo(gameObject.transform, target, normal);

		public static float AngleTo(this GameObject gameObject, Component target, Vector3 normal) =>
			AngleTo(gameObject.transform, target.transform, normal);

		public static float AngleTo(this Component component, GameObject target, Vector3 normal) =>
			AngleTo(component.transform, target.transform, normal);

		public static float AngleTo(this Component component, Component target, Vector3 normal) =>
			AngleTo(component.transform, target.transform, normal);

		public static float AngleTo(this Component component, Transform target, Vector3 normal) =>
			AngleTo(component.transform, target, normal);

		public static float AngleTo(this Transform transform, GameObject target, Vector3 normal) =>
			AngleTo(transform, target.transform, normal);

		public static float AngleTo(this Transform transform, Component target, Vector3 normal) =>
			AngleTo(transform, target.transform, normal);
	}
}
