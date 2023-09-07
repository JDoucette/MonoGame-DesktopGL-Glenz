// Jason Allen Doucette
// September 6, 2023

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common
{
	public static class Util
	{
		public static Texture2D CreateDotTexture(GraphicsDevice graphicsDevice)
		{
			const int sizeEdge = 8;
			const int numTexels = sizeEdge * sizeEdge;
			Color[] colorDataArray = new Color[numTexels];
			for (int i = 0; i < numTexels; i++)
				colorDataArray[i] = new Color(255, 255, 255, 255);
			Texture2D text = new Texture2D(graphicsDevice, sizeEdge, sizeEdge);
			text.SetData<Color>(colorDataArray);
			return text;
		}

		public static void RenderGlenzRectangle(SpriteBatch spriteBatch, Texture2D texture)
		{
			spriteBatch.Begin();
			Rectangle rect = new Rectangle(0, 0, 700, 400);
			Color color = new Color(0, 0, 0, 128);
			spriteBatch.Draw(texture, rect, color);
			spriteBatch.End();
		}
	}
}
