using UnityEngine;

namespace StrongExtensions
{
	public static class RenderTextureExtensions
	{
		//RendererTexture extension Copy method
		public static RenderTexture Copy
			(this RenderTexture original, RenderTextureFormat format = RenderTextureFormat.ARGB32)
		{
			var copy = new RenderTexture(original.width, original.height, original.depth, format);
			Graphics.Blit(original, copy);
			return copy;
		}
	}
}
