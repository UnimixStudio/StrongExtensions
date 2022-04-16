using UnityEngine;

namespace StrongExtensions
{
	public static class Vector2Extensions
	{
		public static Vector2 WithX(this Vector2 value, float x)
		{
			value.x = x;
			return value;
		}

		public static Vector2 WithY(this Vector2 value, float y)
		{
			value.y = y;
			return value;
		}	
		public static Vector2 WithInversedX(this Vector2 value)
		{
			value.x = -value.x;
			return value;
		}

		public static Vector2 WithInversedY(this Vector2 value)
		{
			value.y = -value.y;
			return value;
		}

		public static Vector3 To3(this Vector2 value) =>
			value;

		public static Vector3 To3(this Vector2 value, float z) =>
			value.To3().WithZ(z);

		public static Vector3 ToPlaneY(this Vector2 value) =>
			new Vector3(value.x, 0, value.y);

		public static float Angle(this Vector2 from, Vector2 to) =>
			Vector2.Angle(from, to);

		public static Vector2 Abs(this Vector2 vector) =>
			new Vector2(vector.x.Abs(), vector.y.Abs());

		public static Vector2 Inverted(this Vector2 vector) =>
			new Vector2(vector.y, vector.x);

		public static float GetLength(this Vector2[] path)
		{
			float length = 0f;
			for (int i = 1; i < path.Length; i++)
				length += Vector2.Distance(path[i - 1], path[i]);
			return length;
		}
	}
}