using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Drawing;

namespace Setting
{
    public class BaseSetting
    {
        private Main main;

        KeyboardState previousState;
        int TargetWidth = 800;
        int TargetHeight = 480;

        public BaseSetting(Main main) : base() 
        {
            this.main = main;
            // Le constructeur vide de la classe
            main.graphics.PreferredBackBufferWidth = TargetWidth;
            main.graphics.PreferredBackBufferHeight = TargetHeight;
            main.graphics.IsFullScreen = false;
            main.IsMouseVisible = true;
        }

        public void Initialize()
        {
            // Initialisez votre classe ici
        }

        public void LoadContent()
        {
            // Chargez votre contenu ici
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
        }
    }
}