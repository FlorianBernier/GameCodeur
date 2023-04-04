using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    public class Interface
    {
        private Main main;
        private Texture2D menu;


        public Interface(Main main) : base()
        {
            this.main = main;
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {
            menu = main.Content.Load<Texture2D>("Interface");
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            main.spriteBatch.Begin();

            main.spriteBatch.Draw(menu, new Vector2(0,0), Color.White);

            main.spriteBatch.End();
        }
    }
}
