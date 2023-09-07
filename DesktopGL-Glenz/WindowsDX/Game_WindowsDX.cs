// Jason Allen Doucette
// September 6, 2023

using Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsDX
{
	public class Game_WindowsDX : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Texture2D textDot;
		private Texture2D textSquare;
		private RenderTarget2D renderTarget;

		public Game_WindowsDX()
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
			Util.LoadContent(GraphicsDevice, ref spriteBatch, ref renderTarget, ref textDot, ref textSquare);
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			Util.Draw(GraphicsDevice, renderTarget, spriteBatch, textDot, textSquare);
			base.Draw(gameTime);
		}
	}
}