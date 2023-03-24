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
    class Hero : Sprite
    {
        public float Energy;
        public Hero(Texture2D texture2D): base(texture2D)
        {
            Energy = 100;
        }

        public override void TouchedBy(IActor pBy)
        {
            if (pBy is Meteor)
            {
                Energy -= 0.1f;
            }
        }

    }

    class Meteor : Sprite
    {
        public Meteor(Texture2D pTexture) : base(pTexture)
        {
            do
            {
                vx = (float)GameCodeur.Util.GetInt(-3, 3) / 5;
            } while (vx == 0);

            do
            {
                vy = (float)GameCodeur.Util.GetInt(-3, 3) / 5;
            } while (vy == 0);
        }
    }

    class SceneGamePlay : Scene
    {
        private KeyboardState oldKBS;
        private Hero MyShip;
        private Song music;

        public SceneGamePlay(MainGame pGame) : base(pGame)
        {
            music = AssetManager.MusicGamePlay;
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;
        }

        public override void Load()
        {
            oldKBS = Keyboard.GetState();

            Rectangle Screen = mainGame.Window.ClientBounds;

            for (int i = 0; i < 20; i++)
            {
                Meteor m = new Meteor(mainGame.Content.Load<Texture2D>("meteor"));
                m.Position = new Vector2(GameCodeur.Util.GetInt(1, Screen.Width - m.Texture.Width), 
                                         GameCodeur.Util.GetInt(1, Screen.Height - m.Texture.Height));
                listeActor.Add(m);
            }




            MyShip = new Hero(mainGame.Content.Load<Texture2D>("ship"));
            MyShip.Position = new Vector2((Screen.Width / 2) - MyShip.Texture.Width / 2, (Screen.Height / 2) - MyShip.Texture.Height / 2);

            listeActor.Add(MyShip);

            base.Load();
        }
        public override void Unload()
        {
            MediaPlayer.Stop();
            base.Unload();
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState newKBS = Keyboard.GetState();
            Rectangle Screen = mainGame.Window.ClientBounds;

            foreach (IActor actor in listeActor)
            {
                if (actor is Meteor m)
                {
                    if (m.Position.X < 0)
                    {
                        m.vx = 0 - m.vx;
                        m.Position = new Vector2(0, m.Position.Y);
                    }
                    if (m.Position.X + m.BoudingBox.Width > Screen.Width)
                    {
                        m.vx = 0 - m.vx;
                        m.Position = new Vector2(Screen.Width - m.BoudingBox.Width, m.Position.Y);
                    }

                    if (m.Position.Y < 0)
                    {
                        m.vy = 0 - m.vy;
                        m.Position = new Vector2(m.Position.X, 0);
                    }
                    if (m.Position.Y + m.BoudingBox.Height > Screen.Height)
                    {
                        m.vy = 0 - m.vy;
                        m.Position = new Vector2(m.Position.X, Screen.Height - m.BoudingBox.Height);
                    }
                    if (Util.collideByBox(m, MyShip))
                    {
                        MyShip.TouchedBy(m);
                        m.TouchedBy(MyShip);
                        m.ToRemove = true;
                    }
                }
            }

            Clean();

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Debug.WriteLine("Accerelation on Gameplay");
            }

            if (newKBS.IsKeyDown(Keys.Z) && !oldKBS.IsKeyDown(Keys.Z))
            {
                Debug.WriteLine("Z on Gameplay !");
            }
            if (newKBS.IsKeyDown(Keys.Up))
                MyShip.Move(0, -1);
            if (newKBS.IsKeyDown(Keys.Right))
                MyShip.Move(1, 0);
            if (newKBS.IsKeyDown(Keys.Down))
                MyShip.Move(0, 1);
            if (newKBS.IsKeyDown(Keys.Left))
                MyShip.Move(-1, 0);


            oldKBS = newKBS;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "GAME PLAY! "+ MyShip.Energy, new Vector2(1, 1), Color.White);

            base.Draw(gameTime);
        }


    }
}
