using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
//using System.Drawing;

namespace Setting
{
    public class BaseSetting
    {
        private Main main;

        // Setting fullScreen
        KeyboardState previousState;
        int TargetWidth = 800;
        int TargetHeight = 480;

        // Image test
        Texture2D img;

        // Le constructeur de la classe
        public BaseSetting(Main main) : base() 
        {
            this.main = main;
            
            main.IsMouseVisible = true;

            // Setting fullScreen
            main.graphics.PreferredBackBufferWidth = TargetWidth;
            main.graphics.PreferredBackBufferHeight = TargetHeight;
            main.graphics.IsFullScreen = false;
        }

        public void Initialize()
        {
            // Initialisez votre classe ici
            
        }

        public void LoadContent()
        {
            // Chargez votre contenu ici
            img = main.Content.Load<Texture2D>("BaseSetting");
        }

        public void UnloadContent()
        {
            // Dechargez votre contenu ici
        }


        private void UpdateFullScreen()
        {
            KeyboardState state = Keyboard.GetState();
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

        public void Draw(GameTime gameTime)
        {
            // Dessinez votre classe ici
            main.spriteBatch.Draw(img, new Vector2(0,0), null, Color.White);
        }
    }
}