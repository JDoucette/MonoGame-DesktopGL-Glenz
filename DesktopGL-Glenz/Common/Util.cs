// Jason Allen Doucette
// September 6, 2023

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Common
{
	public static class Util
	{
		public static Texture2D CreateDotTexture(GraphicsDevice graphicsDevice, int sizeEdge)
		{
			int numTexels = sizeEdge * sizeEdge;
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
			Rectangle rect = new Rectangle(20, 10, 80, 40);
			Color color = new Color(0, 0, 0, 160);
			spriteBatch.Draw(texture, rect, color);
			spriteBatch.End();
		}

		public static void RenderDots(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Texture2D dot)
		{
			const int numDots = 256;
			Point size = new Point(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
			Random rng = new Random(0);
			spriteBatch.Begin();
			for (int i=0; i<numDots; i++)
			{
				int x = rng.Next(size.X);
				int y = rng.Next(size.Y);
				int r = rng.Next(256);
				int g = r;
				int b = r;
				spriteBatch.Draw(dot, new Vector2(x, y), new Color(r, g, b));
			}
			spriteBatch.End();
		}

		public static void RenderTextureFullScreen(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Texture2D texture)
		{
			spriteBatch.Begin(samplerState: SamplerState.PointClamp);  // pixelated
			Rectangle rectFullScreen = new Rectangle(0, 0,
				graphicsDevice.Viewport.Width, 
				graphicsDevice.Viewport.Height);
			spriteBatch.Draw(texture, rectFullScreen, Color.White);
			spriteBatch.End();
		}

		internal static RenderTarget2D CreateRenderTarget(GraphicsDevice graphicsDevice, int width, int height)
		{
			// 1.
			//return new RenderTarget2D(graphicsDevice, width, height);

			// 2.
			//return new RenderTarget2D(graphicsDevice, width, height, 
			//	mipMap: false, 
			//	preferredFormat: SurfaceFormat.Color, 
			//	preferredDepthFormat: DepthFormat.Depth16);

			// 3.
			return new RenderTarget2D(graphicsDevice, width, height,
				mipMap: false,
				preferredFormat: SurfaceFormat.Color,
				preferredDepthFormat: DepthFormat.Depth16,
				preferredMultiSampleCount: 0,
				usage: RenderTargetUsage.PreserveContents);

			// 4.
			//return new RenderTarget2D(graphicsDevice, width, height,
			//	mipMap: false,
			//	preferredFormat: SurfaceFormat.Color,
			//	preferredDepthFormat: DepthFormat.Depth16,
			//	preferredMultiSampleCount: 1,  // in DesktopGL, not WindowsDX, this ceases rendering
			//	usage: RenderTargetUsage.PreserveContents);
		}
	}
}
