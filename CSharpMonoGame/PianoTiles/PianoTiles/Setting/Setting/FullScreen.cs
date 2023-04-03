using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PianoTiles
{
    public class FullScreen
    {
        private Main main;

        // Setting fullScreen
        KeyboardState previousState;
        int TargetWidth = 800;
        int TargetHeight = 480;
        // Setting Autre
        RenderTarget2D render;
        bool bSampling = false;

        // Le constructeur de la classe
        public FullScreen(Main main) : base()
        {
            this.main = main;
            // Setting fullScreen
            main.graphics.PreferredBackBufferWidth = TargetWidth;
            main.graphics.PreferredBackBufferHeight = TargetHeight;
            main.graphics.IsFullScreen = false;
        }

        public void Initialize()
        {
            // Initialisez votre classe ici
            PresentationParameters pp = main.graphics.GraphicsDevice.PresentationParameters;
            render = new RenderTarget2D(main.graphics.GraphicsDevice, TargetWidth, TargetHeight, false,
                SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents);
        }

        public void LoadContent()
        {
            // Chargez votre contenu ici

        }

        public void UnloadContent()
        {
            // Dechargez votre contenu ici
            render.Dispose();

        }


        private void UpdateFullScreen()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                main.Exit();

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.F3) && !previousState.IsKeyDown(Keys.F3))
            {
                bSampling = !bSampling;
            }

            if (state.IsKeyDown(Keys.F2) && !previousState.IsKeyDown(Keys.F2) && !main.graphics.IsFullScreen)
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
                main.graphics.PreferredBackBufferWidth = TargetWidth;
                main.graphics.PreferredBackBufferHeight = TargetHeight;
                main.graphics.ApplyChanges();
            }

            if (state.IsKeyDown(Keys.F1) && !previousState.IsKeyDown(Keys.F1))
            {
                if (!main.graphics.IsFullScreen)
                {
                    main.graphics.PreferredBackBufferWidth = main.graphics.GraphicsDevice.DisplayMode.Width;
                    main.graphics.PreferredBackBufferHeight = main.graphics.GraphicsDevice.DisplayMode.Height;
                }
                else
                {
                    main.graphics.PreferredBackBufferWidth = TargetWidth;
                    main.graphics.PreferredBackBufferHeight = TargetHeight;
                }

                main.graphics.ToggleFullScreen();
            }
            previousState = state;
        }
        public void Update(GameTime gameTime)
        {
            // Mettez à jour votre classe ici
            UpdateFullScreen();
        }

        public void DrawSet(GameTime gameTime)
        {
            main.GraphicsDevice.SetRenderTarget(render);
        }
        public void Draw(GameTime gameTime)
        {
            main.GraphicsDevice.SetRenderTarget(null);
            // Now, we draw the render target on the screen

            float ratio = 1;
            int marginV = 0;
            int marginH = 0;
            float currentAspect = main.Window.ClientBounds.Width / (float)main.Window.ClientBounds.Height;
            float virtualAspect = (float)TargetWidth / (float)TargetHeight;
            if (TargetHeight != this.main.Window.ClientBounds.Height)
            {
                if (currentAspect > virtualAspect)
                {
                    ratio = main.Window.ClientBounds.Height / (float)TargetHeight;
                    marginH = (int)((main.Window.ClientBounds.Width - TargetWidth * ratio) / 2);
                }
                else
                {
                    ratio = main.Window.ClientBounds.Width / (float)TargetWidth;
                    marginV = (int)((main.Window.ClientBounds.Height - TargetHeight * ratio) / 2);
                }
            }

            Rectangle dst = new Rectangle(marginH, marginV, (int)(TargetWidth * ratio), (int)(TargetHeight * ratio));

            if (!bSampling)
                main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);
            else
                main.spriteBatch.Begin();

            main.spriteBatch.Draw(render, dst, Color.White);

            main.spriteBatch.End();

        }
    }
}