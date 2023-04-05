using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TowerDefence
{
    public class Button
    {
        private Main main;

        private Texture2D _btnG;
        private Texture2D _btn30x30;
        private Rectangle _rectangle;
        private bool _isClicked = false;


        public Button(Main main) : base()
        {
            this.main = main;
            _rectangle = new Rectangle(1, 1, 98, 58);
        }

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {
            _btnG = main.Content.Load<Texture2D>("BtnG");
            _btn30x30 = main.Content.Load<Texture2D>("BtnWhite30x30");

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

            main.spriteBatch.Draw(_btnG, _rectangle, buttonColor);


            main.spriteBatch.End();
        }
    }
}
