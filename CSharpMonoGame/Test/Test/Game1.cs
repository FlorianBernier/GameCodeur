using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class Game1 : Game
    {
        Point gameResolution = new Point(480, 800); // This can be whatever resolution your game renders at

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        RenderTarget2D renderTarget;
        Rectangle renderTargetDestination;

        Color letterboxingColor = new Color(0, 0, 0);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            graphics.PreferredBackBufferWidth = gameResolution.X;
            graphics.PreferredBackBufferHeight = gameResolution.Y;

            graphics.ApplyChanges();

            renderTarget = new RenderTarget2D(GraphicsDevice, gameResolution.X, gameResolution.Y);
            renderTargetDestination = GetRenderTargetDestination(gameResolution, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            // Game update code

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(letterboxingColor);

            // Game draw code

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(letterboxingColor);

            spriteBatch.Begin();
            spriteBatch.Draw(renderTarget, renderTargetDestination, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void ToggleFullScreen()
        {
            if (!graphics.IsFullScreen)
            {
                graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            }
            else
            {
                graphics.PreferredBackBufferWidth = gameResolution.X;
                graphics.PreferredBackBufferHeight = gameResolution.Y;
            }
            graphics.IsFullScreen = !graphics.IsFullScreen;
            graphics.ApplyChanges();

            renderTargetDestination = GetRenderTargetDestination(gameResolution, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        Rectangle GetRenderTargetDestination(Point resolution, int preferredBackBufferWidth, int preferredBackBufferHeight)
        {
            float resolutionRatio = (float)resolution.X / resolution.Y;
            float screenRatio;
            Point bounds = new Point(preferredBackBufferWidth, preferredBackBufferHeight);
            screenRatio = (float)bounds.X / bounds.Y;
            float scale;
            Rectangle rectangle = new Rectangle();

            if (resolutionRatio < screenRatio)
                scale = (float)bounds.Y / resolution.Y;
            else if (resolutionRatio > screenRatio)
                scale = (float)bounds.X / resolution.X;
            else
            {
                // Resolution and window/screen share aspect ratio
                rectangle.Size = bounds;
                return rectangle;
            }
            rectangle.Width = (int)(resolution.X * scale);
            rectangle.Height = (int)(resolution.Y * scale);
            return CenterRectangle(new Rectangle(Point.Zero, bounds), rectangle);
        }

        static Rectangle CenterRectangle(Rectangle outerRectangle, Rectangle innerRectangle)
        {
            Point delta = outerRectangle.Center - innerRectangle.Center;
            innerRectangle.Offset(delta);
            return innerRectangle;
        }
    }
}