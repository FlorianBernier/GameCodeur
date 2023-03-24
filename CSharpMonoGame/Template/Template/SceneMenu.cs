using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private Button MyButton;
        private Song music;
        public SceneMenu(MainGame pGame) : base(pGame) 
        {
            Debug.WriteLine("New SceneMenu");
        }

        public void onClickPlay(Button pSender)
        {
            mainGame.gameState.ChangeScene(GameState.SceneType.GamePlay);
        }

        public override void Load()
        {
            Debug.WriteLine("SceneMenu.Load");

            music = mainGame.Content.Load<Song>("cool");
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;

            Rectangle Screen = mainGame.Window.ClientBounds;
            MyButton = new Button(mainGame.Content.Load<Texture2D>("button"));
            MyButton.Position = new Vector2((Screen.Width/2) - MyButton.Texture.Width / 2,
                                            (Screen.Height/2) - MyButton.Texture.Height / 2);

            MyButton.onClick = onClickPlay;

            listeActor.Add(MyButton);

            oldKBS = Keyboard.GetState();
            oldGPS = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            base.Load();
        }
        public override void Unload()
        {
            Debug.WriteLine("SceneMenu.Unload");
            MediaPlayer.Stop();
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
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "This is the menu !", new Vector2(1,1), Color.White);

            base.Draw(gameTime);
        }


    }
}
