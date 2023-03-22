using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace GameCodeur
{
    class SceneMenu : Scene
    {
        public SceneMenu(MainGame pGame) : base(pGame) 
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
            mainGame.spriteBatch.Begin();

            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "This is the menu !", new Vector2(1,1), Color.White);

            mainGame.spriteBatch.End();


            base.Draw(gameTime);
        }


    }
}
