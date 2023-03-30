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
        int TargetWidth = 2000;
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

        public void Initialize_BaseSetting()
        {
            // Initialisez votre classe ici
        }

        public void LoadContent_BaseSetting()
        {
            // Chargez votre contenu ici
        }

        public void UnloadContent_BaseSetting()
        {
            // Dechargez votre contenu ici
        }

        public void Update_BaseSetting(GameTime gameTime)
        {
            // Mettez à jour votre classe ici
        }

        public void Draw_BaseSetting(GameTime gameTime)
        {
            // Dessinez votre classe ici
        }
    }
}