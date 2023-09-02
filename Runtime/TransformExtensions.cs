using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.AI;

namespace StrongExtensions
{
	public static class TransformExtensions
	{
		public static void AddChild(this Transform parent, Transform child) =>
			child.SetParent(parent);

		public static void CenterOnChildren(this Transform parent)
		{
			Vector3 position = Vector3.zero;

			foreach(Transform child in parent)
			{
				position += child.position;
				child.parent = null;
			}

			position /= parent.childCount;

			parent.position = position;

			foreach(Transform child in parent)
				child.parent = parent;
		}

		public static Transform[] GetActiveChildren(this Transform parent) =>
			parent
				.Cast<Transform>()
				.Where(child => child.gameObject.activeSelf)
				.ToArray();

		public static Vector3 Center(this IEnumerable<Transform> transforms)
		{
			if (transforms == null)
				throw new ArgumentNullException(nameof(transforms));

			Transform[] array = transforms as Transform[] ?? transforms.ToArray();

			if (array.Length <= 0)
				throw new ArgumentOutOfRangeException(nameof(transforms));

			Vector3 position = array.Aggregate(Vector3.zero, (current, transform) => current + transform.position);

			position /= array.Length;

			return position;
		}

		public static Vector3 Center(this IEnumerable<Vector3> points)
		{
			if (points == null)
				throw new ArgumentNullException(nameof(points));

			Vector3[] array = points as Vector3[] ?? points.ToArray();

			if (array.Length <= 0)
				throw new ArgumentOutOfRangeException(nameof(points));

			Vector3 position = array.Aggregate(Vector3.zero, (current, point) => current + point);

			position /= array.Length;

			return position;
		}

		public static SerializableTransform ToSerializable(this Transform transform) =>
			new()
			{
				Position = transform.position,
				Rotation = transform.rotation,
				LocalScale = transform.localScale
			};

		public static void Deserialize(this Transform transform, SerializableTransform serializableTransform)
		{
			transform.position = serializableTransform.Position;
			transform.rotation = serializableTransform.Rotation;
			transform.localScale = serializableTransform.LocalScale;
		}

		public static bool TryGetClosest(this GameObject origin, IEnumerable<GameObject> from, out GameObject closest)
		{
			return TryGetClosest(origin, from.Select(Transforms), out closest);

			Transform Transforms(GameObject go) => go.transform;
		}

		public static bool TryGetClosest(this GameObject origin, IEnumerable<Transform> from, out GameObject closest)
		{
			bool closestFound = TryGetClosest(origin.transform, from, out Transform near);

			closest = near.gameObject;

			return closestFound;
		}

		public static bool TryGetClosest(this Transform transform, IEnumerable<Transform> from, out Transform closest)
		{
			closest = default;

			if (from.IsEmpty())
				return false;

			closest = from
				.Except(transform)
				.OrderBy(Distance)
				.FirstOrDefault();

			return closest != default;

			float Distance(Transform other)
			{
				Vector3 firstPosition = transform.position;
				Vector3 secondPosition = other.position;

				Vector3 direction = firstPosition - secondPosition;

				return direction.sqrMagnitude;
			}
		}

		public static Vector3 FindPointOnNavmesh
		(
			this Transform origin,
			Vector3 direction,
			float maxDistance = float.MaxValue,
			int allAreas = NavMesh.AllAreas
		)
		{
			Vector3 position = origin.position + direction;

			bool foundPoint = NavMesh.SamplePosition(position, out NavMeshHit hit, maxDistance, allAreas);

			if (foundPoint)
				position = hit.position;

			return position;
		}

		public static void PlaceOnNavMesh
			(this Transform origin, float maxDistance = float.MaxValue, int allAreas = NavMesh.AllAreas)
		{
			Vector3 position = origin.position;

			bool foundPoint = NavMesh.SamplePosition(position, out NavMeshHit hit, maxDistance, allAreas);

			if (foundPoint)
				position = hit.position;

			origin.position = position;
		}
	}

	[Serializable]
	public class SerializableTransform
	{
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 LocalScale;

		public static implicit operator SerializableTransform(Component component) =>
			component.transform.ToSerializable();

		public static implicit operator SerializableTransform(GameObject gameObject) =>
			gameObject.transform.ToSerializable();

		public static implicit operator SerializableTransform(Transform transform) =>
			transform.ToSerializable();
	}
}
