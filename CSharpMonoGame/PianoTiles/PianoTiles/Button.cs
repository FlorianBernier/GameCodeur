using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoTiles
{
    public class Button
    {
        private Game mainGame;
        private SpriteBatch spriteBatch;
        private Vector2 pos { get; set; }
        private Rectangle buttonRectangle { get; set; }
        private Texture2D TextureOff { get; set; }
        private Texture2D TextureOn { get; set; }
        private bool IsPressed { get; set; }


        public Button(Game pGame, SpriteBatch spriteBatch, Vector2 pPos)
        {
            this.mainGame = pGame;
            this.pos = pPos;
            this.IsPressed = false;
            this.TextureOff = mainGame.Content.Load<Texture2D>("button");
            this.TextureOn = mainGame.Content.Load<Texture2D>("button");
            this.buttonRectangle = new Rectangle((int)pos.X, (int)pPos.Y, TextureOff.Width, TextureOff.Height);
        }
        public void ButtonPressed()
        {
            IsPressed = !IsPressed;
        }
        public void Update()
        {

        }
        public void Draw(Game mainGame)
        {
            if (IsPressed)
            {

                spriteBatch.Draw(TextureOn, pos, Color.White);

            }
            else
            {
                spriteBatch.Draw(TextureOff, pos, Color.White);

            }
        }
    }
}
