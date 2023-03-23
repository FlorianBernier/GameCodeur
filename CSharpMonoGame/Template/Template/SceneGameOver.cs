﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace GameCodeur
{
    class SceneGameOver : Scene
    {
        public SceneGameOver(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneMenu");
        }

        public override void Load()
        {
            Debug.WriteLine("SceneMenu.Load");
            base.Load();
        }
        public override void Unload()
        {
            Debug.WriteLine("SceneMenu.Unload");
            base.Unload();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "GAME OVER !", new Vector2(1, 1), Color.White);

            base.Draw(gameTime);
        }


    }
}