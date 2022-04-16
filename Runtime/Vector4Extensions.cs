using UnityEngine;

namespace StrongExtensions
{
	public static class Vector4Extensions
	{
		public static Vector4 Abs(this Vector4 vector) =>
			new Vector4(vector.x.Abs(), vector.y.Abs(), vector.z.Abs(), vector.w.Abs());
	}
}