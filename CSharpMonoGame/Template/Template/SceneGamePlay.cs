using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace GameCodeur
{
    class SceneGamePlay : Scene
    {
        private KeyboardState oldKBS;


        public SceneGamePlay(MainGame pGame) : base(pGame)
        {

        }

        public override void Load()
        {
            oldKBS = Keyboard.GetState();
            base.Load();
        }
        public override void Unload()
        {
            base.Unload();
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState newKBS = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Debug.WriteLine("Accerelation on Gameplay");
            }

            if (newKBS.IsKeyDown(Keys.Z) && !oldKBS.IsKeyDown(Keys.Z))
            {
                Debug.WriteLine("Z on Gameplay !");
            }



            oldKBS = newKBS;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            mainGame.spriteBatch.Begin();

            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "GAME PLAY !", new Vector2(1, 1), Color.White);

            mainGame.spriteBatch.End();


            base.Draw(gameTime);
        }


    }
}
