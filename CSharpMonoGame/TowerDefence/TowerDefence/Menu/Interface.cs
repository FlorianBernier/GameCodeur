using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace TowerDefence
{
    public class Interface
    {
        private Main main;
        private Texture2D menu;

        // Btn
        private List<Button> _listBtn;
        
        


        public Interface(Main main) : base()
        {
            this.main = main;
            _listBtn = new List<Button>
            {
                new Button(main, new Rectangle(1, 61, 98, 58)),
                new Button(main, new Rectangle(1, 121, 98, 58)),
                new Button(main, new Rectangle(1, 181, 98, 58)),
                new Button(main, new Rectangle(1, 241, 98, 58)),
                new Button(main, new Rectangle(1, 301, 98, 58)),
                new Button(main, new Rectangle(1, 361, 98, 58)),
                new Button(main, new Rectangle(1, 421, 98, 58)),

                new Button(main, new Rectangle(701, 89, 30, 30)),
                new Button(main, new Rectangle(734, 89, 30, 30)),
                new Button(main, new Rectangle(769, 89, 30, 30)),

                new Button(main, new Rectangle(701, 149, 30, 30)),
                new Button(main, new Rectangle(734, 149, 30, 30)),
                new Button(main, new Rectangle(769, 149, 30, 30)),

                new Button(main, new Rectangle(701, 209, 30, 30)),
                new Button(main, new Rectangle(734, 209, 30, 30)),
                new Button(main, new Rectangle(769, 209, 30, 30)),

                new Button(main, new Rectangle(701, 269, 30, 30)),
                new Button(main, new Rectangle(734, 269, 30, 30)),
                new Button(main, new Rectangle(769, 269, 30, 30)),

                new Button(main, new Rectangle(701, 329, 30, 30)),
                new Button(main, new Rectangle(734, 329, 30, 30)),
                new Button(main, new Rectangle(769, 329, 30, 30)),

                new Button(main, new Rectangle(701, 389, 30, 30)),
                new Button(main, new Rectangle(734, 389, 30, 30)),
                new Button(main, new Rectangle(769, 389, 30, 30)),

                new Button(main, new Rectangle(701, 449, 30, 30)),
                new Button(main, new Rectangle(734, 449, 30, 30)),
                new Button(main, new Rectangle(769, 449, 30, 30)),
            };


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
