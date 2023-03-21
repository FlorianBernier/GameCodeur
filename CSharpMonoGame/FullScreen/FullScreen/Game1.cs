using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace FullScreen
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;

        RenderTarget2D render;
        bool bSampling = false;

        Texture2D imgTemplateBG;
        Texture2D imgMark;

        KeyboardState previousState;

        int TargetWidth = 800;
        int TargetHeight = 480;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = TargetWidth;
            graphics.PreferredBackBufferHeight = TargetHeight;
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
        }

        private void InitializeFullScreen()
        {
            PresentationParameters pp = graphics.GraphicsDevice.PresentationParameters;
            render = new RenderTarget2D(graphics.GraphicsDevice,
                TargetWidth, TargetHeight,
                false,
                SurfaceFormat.Color,
                DepthFormat.None,
                pp.MultiSampleCount,
                RenderTargetUsage.DiscardContents);
        }
        protected override void Initialize()
        {
            InitializeFullScreen();
            // TODO: Ajoutez ici votre code

            base.Initialize();
        }

        private void LoadFullScreen()
        {
            imgTemplateBG = Content.Load<Texture2D>("Template800x480");
            imgMark = Content.Load<Texture2D>("mark");
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadFullScreen();
            // TODO: Ajoutez ici votre code

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            render.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.F3) && !previousState.IsKeyDown(Keys.F3))
            {
                bSampling = !bSampling;
            }

            if (state.IsKeyDown(Keys.F2) && !previousState.IsKeyDown(Keys.F2) && !graphics.IsFullScreen)
            {
                if (state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift))
                {
                    TargetHeight /= 2;
                    TargetWidth /= 2;
                }
                else
                {
                    TargetHeight *= 2;
                    TargetWidth *= 2;
                }
                graphics.PreferredBackBufferWidth = TargetWidth;
                graphics.PreferredBackBufferHeight = TargetHeight;
                graphics.ApplyChanges();
            }

            if (state.IsKeyDown(Keys.F1) && !previousState.IsKeyDown(Keys.F1))
            {
                if (!graphics.IsFullScreen)
                {
                    graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
                    graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;
                }
                else
                {
                    graphics.PreferredBackBufferWidth = TargetWidth;
                    graphics.PreferredBackBufferHeight = TargetHeight;
                }

                graphics.ToggleFullScreen();
            }

            previousState = state;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            GraphicsDevice.SetRenderTarget(render);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // ===================
            // Draw your game here
            // ===================

            _spriteBatch.Draw(imgTemplateBG, new Vector2(0, 0), null, Color.White);

            // ===================

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);

            // Now, we draw the render target on the screen

            float ratio = 1;
            int marginV = 0;
            int marginH = 0;
            float currentAspect = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
            float virtualAspect = (float)TargetWidth / (float)TargetHeight;
            if (TargetHeight != this.Window.ClientBounds.Height)
            {
                if (currentAspect > virtualAspect)
                {
                    ratio = Window.ClientBounds.Height / (float)TargetHeight;
                    marginH = (int)((Window.ClientBounds.Width - TargetWidth * ratio) / 2);
                }
                else
                {
                    ratio = Window.ClientBounds.Width / (float)TargetWidth;
                    marginV = (int)((Window.ClientBounds.Height - TargetHeight * ratio) / 2);
                }
            }

            Rectangle dst = new Rectangle(marginH,marginV,(int)(TargetWidth*ratio),(int)(TargetHeight*ratio));

            if (!bSampling)
                _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);
            else
                _spriteBatch.Begin();

            _spriteBatch.Draw(render, dst, Color.White);

            // Display marks on the actual screen (with the actual resolution)
            // Up - Left
            _spriteBatch.Draw(imgMark, Vector2.Zero, null, Color.White);
            // Up - Right
            _spriteBatch.Draw(imgMark, new Vector2(Window.ClientBounds.Width-imgMark.Width,0), null, Color.White);
            // Down - Left
            _spriteBatch.Draw(imgMark, new Vector2(0, Window.ClientBounds.Height - imgMark.Height), null, Color.White);
            // Down - Right
            _spriteBatch.Draw(imgMark, new Vector2(Window.ClientBounds.Width - imgMark.Width, Window.ClientBounds.Height - imgMark.Height), null, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}