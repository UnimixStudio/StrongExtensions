using UnityEngine;

namespace StrongExtensions
{
	public static class TextureExtensions
	{
		public static Texture2D To2D(this Texture texture, bool mipChain = false, int depthBuffer = 32)
		{
			int width = texture.width;
			int height = texture.height;

			var texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain);

			RenderTexture currentRenderTexture = RenderTexture.active;
			RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, depthBuffer);

			Graphics.Blit(texture, renderTexture);

			RenderTexture.active = renderTexture;

			var rect = new Rect(0, 0, width, height);

			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();

			RenderTexture.active = currentRenderTexture;
			RenderTexture.ReleaseTemporary(renderTexture);

			return texture2D;
		}
	}
}
