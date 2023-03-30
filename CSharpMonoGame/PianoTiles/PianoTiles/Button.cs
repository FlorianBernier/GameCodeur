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
        private Main mainGame;
        private SpriteBatch spriteBatch;
        private Vector2 pos { get; set; }
        private Rectangle buttonRectangle { get; set; }
        private Texture2D TextureOff { get; set; }
        private Texture2D TextureOn { get; set; }
        private bool IsPressed { get; set; }


        public Button(Main pGame, Vector2 pPos, Texture2D pTextureOff, Texture2D pTextureOn)
        {
            mainGame = pGame;
            pos = pPos;
            IsPressed = false;
            TextureOff = pTextureOff;
            TextureOn = pTextureOn;
            this.buttonRectangle = new Rectangle((int)pos.X, (int)pPos.Y, TextureOff.Width, TextureOff.Height);
        }
        public void ButtonPressed()
        {
            IsPressed = !IsPressed;
        }
        public void Load() {

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(GameTime gameTime)
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
