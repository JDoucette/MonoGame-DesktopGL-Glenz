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
			// defaults:
			//return new RenderTarget2D(graphicsDevice, width, height);

			// custom:
			return new RenderTarget2D(graphicsDevice, width, height,
				mipMap: false,  // default
				preferredFormat: SurfaceFormat.Color,  // default

				// ATTEMPTING TO REPRO GLITCH:
				// This does NOT repro the glitch, but it DOES cause nothing to be rendered, which is even worse. :)
				preferredDepthFormat: DepthFormat.Depth16,  // anything other than default None is required for glitch
				preferredMultiSampleCount: 1,  // 0 is default, 1 is required for glitch

				usage: RenderTargetUsage.DiscardContents);  // this doesn't impact
		}

		public static void Draw(GraphicsDevice graphicsDevice, RenderTarget2D renderTarget, SpriteBatch spriteBatch,
			Texture2D textDot, Texture2D textSquare)
		{
			// low res target
			graphicsDevice.SetRenderTarget(renderTarget);
			graphicsDevice.Clear(Color.Red);
			Util.RenderDots(graphicsDevice, spriteBatch, textDot);
			Util.RenderGlenzRectangle(spriteBatch, textSquare);

			// back buffer
			graphicsDevice.SetRenderTarget(null);
			graphicsDevice.Clear(Color.DarkBlue);
			Util.RenderTextureFullScreen(graphicsDevice, spriteBatch, (Texture2D)renderTarget);
		}

		internal static void LoadContent(GraphicsDevice graphicsDevice, 
			ref SpriteBatch spriteBatch, ref RenderTarget2D renderTarget, ref Texture2D textDot, ref Texture2D textSquare)
		{
			spriteBatch = new SpriteBatch(graphicsDevice);
			textDot = Util.CreateDotTexture(graphicsDevice, 1);
			textSquare = Util.CreateDotTexture(graphicsDevice, 8);
			const int pixelZoom = 6;
			renderTarget = Util.CreateRenderTarget(graphicsDevice, 800 / pixelZoom, 480 / pixelZoom);
		}
	}
}
