// Jason Allen Doucette
// September 6, 2023

using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DesktopGL
{
	public class Game_DesktopGL : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Texture2D textDot;
		private Texture2D textSquare;
		private RenderTarget2D renderTarget;

		public Game_DesktopGL()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			textDot = Util.CreateDotTexture(GraphicsDevice, 1);
			textSquare = Util.CreateDotTexture(GraphicsDevice, 8);
			const int pixelZoom = 6;
			renderTarget = Util.CreateRenderTarget(GraphicsDevice, 800 / pixelZoom, 480 / pixelZoom);
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			// low res target
			GraphicsDevice.SetRenderTarget(renderTarget);
			GraphicsDevice.Clear(Color.Red);
			Util.RenderDots(GraphicsDevice, spriteBatch, textDot);
			Util.RenderGlenzRectangle(spriteBatch, textSquare);

			// back buffer
			GraphicsDevice.SetRenderTarget(null);
			GraphicsDevice.Clear(Color.DarkBlue);
			Util.RenderTextureFullScreen(GraphicsDevice, spriteBatch, (Texture2D)renderTarget);

			base.Draw(gameTime);
		}
	}
}