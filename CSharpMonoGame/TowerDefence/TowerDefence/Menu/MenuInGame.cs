using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace TowerDefence
{
    public class MenuInGame
    {
        private Main main;
        private Texture2D menu;

        // Btn
        private List<Button> _listBtn;
        
        


        public MenuInGame(Main main) : base()
        {
            this.main = main;
            _listBtn = new List<Button> { };
            

            for(int i = 0; i < 7; i++)
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

            main.spriteBatch.End();

            foreach (Button button in _listBtn)
            {
                button.Draw(gameTime);
            }
        }
    }
}
