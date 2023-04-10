using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace TowerDefence
{
    public class MenuInGame
    {
        private Main main;

        // Menu
        private Texture2D menu;

        // Btn
        private List<Button> _listBtn;

        // Life
        public int _life = 100;
        // Or
        public int _or = 500;
        // Argent
        public int _argent = 0;

        

        public MenuInGame(Main main) : base()
        {
            this.main = main;
            

            _listBtn = new List<Button> { };
            for (int i = 0; i < 7; i++)
            {
                _listBtn.Add(new Button(main, new Rectangle(1, 61 + 60 * i, 98, 58)));

                _listBtn.Add(new Button(main, new Rectangle(701, 89 + 60 * i, 30, 30)));
                _listBtn.Add(new Button(main, new Rectangle(734, 89 + 60 * i, 30, 30)));
                _listBtn.Add(new Button(main, new Rectangle(769, 89 + 60 * i, 30, 30)));
            }

            
        }

        public void Initialize()
        {
            foreach (Button button in _listBtn)
            {
                button.Initialize();
            }
        }

        public void LoadContent()
        {
            menu = main.Content.Load<Texture2D>("Interface");
            foreach (Button button in _listBtn)
            {
                button.LoadContent();
            }
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (Button button in _listBtn)
            {
                button.Update(gameTime);
            }
            
            
        }

        public void Draw(GameTime gameTime)
        {

            
            main.spriteBatch.Begin();

            main.spriteBatch.Draw(menu, new Vector2(0,0), Color.White);

            main.spriteBatch.DrawString(main._font, ""+_or, new Vector2(50, 10), Color.White);
            main.spriteBatch.DrawString(main._font, ""+_argent, new Vector2(50, 35), Color.White);
            main.spriteBatch.DrawString(main._font, ""+main._TD._wave, new Vector2(750, 10), Color.White);
            main.spriteBatch.DrawString(main._font, ""+_life, new Vector2(750, 35), Color.White);

            main.spriteBatch.Draw()

            main.spriteBatch.End();

            foreach (Button button in _listBtn)
            {
                button.Draw(gameTime);
            }
        }
    }
}
