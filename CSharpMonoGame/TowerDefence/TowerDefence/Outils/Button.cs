using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TowerDefence
{
    public class Button
    {
        private Main main;

        private Texture2D _textureBtn;
        private Rectangle _rectangle;
        public bool _isClicked = false;


        public Button(Main main, Rectangle pRect) : base()
        {
            this.main = main;
            this._rectangle = pRect;
            
        }

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {
            _textureBtn = main.Content.Load<Texture2D>("BtnLineWhite");
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if (_rectangle.Contains(Mouse.GetState().Position))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    _isClicked = true;
                }
                else
                {
                    _isClicked = false;
                }
            }
            else
            {
                _isClicked = false;
            }
        }


        public void Draw(GameTime gameTime)
        {
            main.spriteBatch.Begin();

            Color buttonColor = Color.Gray;
            if (_isClicked)
            {
                buttonColor = Color.White;
                Debug.WriteLine(_isClicked);
            }

            main.spriteBatch.Draw(_textureBtn, _rectangle, buttonColor);
            

            main.spriteBatch.End();
        }
    }
}
