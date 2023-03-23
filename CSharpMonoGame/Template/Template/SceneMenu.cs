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
    class SceneMenu : Scene
    {
        KeyboardState oldKBS;
        GamePadState oldGPS;
        public SceneMenu(MainGame pGame) : base(pGame) 
        {
            Debug.WriteLine("New SceneMenu");
        }

        public override void Load()
        {
            Debug.WriteLine("SceneMenu.Load");

            oldKBS = Keyboard.GetState();
            oldGPS = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            base.Load();
        }
        public override void Unload()
        {
            Debug.WriteLine("SceneMenu.Unload");
            base.Unload();
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState newKBS = Keyboard.GetState();
            GamePadCapabilities Capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            GamePadState newGPS;
            bool ButA = false;

            if (Capabilities.IsConnected)
            {
                newGPS = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
                if (newGPS.IsButtonDown(Buttons.A) == true && oldGPS.IsButtonDown(Buttons.A) == false)
                {
                    ButA = true;
                }
            }

            MouseState newMS = Mouse.GetState();
            if (newMS.LeftButton == ButtonState.Pressed)
            {

            }

            if ((newKBS.IsKeyDown(Keys.E) && !oldKBS.IsKeyDown(Keys.E)) || ButA)
            {
                mainGame.gameState.ChangeScene(GameState.SceneType.GamePlay);
            }

            oldKBS = newKBS;
            if (Capabilities.IsConnected)
            {
                newGPS = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            }

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
