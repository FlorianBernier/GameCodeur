using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Setting
{
    public class SettingBase
    {
        private Main main;
        


        public SettingBase(Main main) : base()
        {
            this.main = main;
            main.IsMouseVisible = true;

        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {
            
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            main.GraphicsDevice.Clear(Color.Black);
        }
    }
}
