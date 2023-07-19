using UnityEditor;

namespace StrongExtensions
{
	public static class EditorExtensions
	{
		public static void SetDirty(this UnityEngine.Object obj) =>
			EditorUtility.SetDirty(obj);
	}
}
