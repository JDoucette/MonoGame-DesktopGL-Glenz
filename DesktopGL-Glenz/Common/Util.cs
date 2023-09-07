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
			Color[] colorDataArray = new Color[1];
			colorDataArray[0] = new Color(255, 255, 255, 255);
			Texture2D text = new Texture2D(graphicsDevice, 1, 1);
			text.SetData<Color>(colorDataArray);
			return text;
		}
	}
}
