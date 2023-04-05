using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TowerDefence
{
    public class Button
    {
        private Main main;

        private Texture2D _btnRight;
        private Texture2D _btnLeft;
        private Rectangle _rectRight;
        private Rectangle _rectLeft;
        private bool _isClicked = false;


        public Button(Main main, Rectangle pRect) : base()
        {
            this.main = main;
            this._rectRight = pRect;
            this._rectLeft = pRect;
        }

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {
            _btnRight = main.Content.Load<Texture2D>("BtnG");

            _btnLeft = main.Content.Load<Texture2D>("BtnWhite30x30");

        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if (_rectRight.Contains(Mouse.GetState().Position))
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

            if (_rectLeft.Contains(Mouse.GetState().Position))
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

            main.spriteBatch.Draw(_btnRight, _rectRight, buttonColor);

            main.spriteBatch.Draw(_btnLeft, _rectRight, buttonColor);



            main.spriteBatch.End();
        }
    }
}
