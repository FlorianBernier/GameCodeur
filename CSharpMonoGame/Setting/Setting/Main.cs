using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Setting
{
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public BaseSetting mySetting;
        Texture2D imgTemplateBG;


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mySetting = new BaseSetting(this);
        }

        protected override void Initialize()
        {
            mySetting.Initialize();
            // TODO: Ajoutez ici votre code

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Ajoutez ici votre code
            imgTemplateBG = Content.Load<Texture2D>("Template800x480");
        }

        protected override void UnloadContent()
        {
            mySetting.UnloadContent();
            // TODO: Ajoutez ici votre code

        }

        protected override void Update(GameTime gameTime)
        {
            mySetting.Update(gameTime);
            // TODO: Ajoutez ici votre code

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            mySetting.Base(gameTime);

            // TODO: Ajoutez ici votre
            spriteBatch.Begin();

            spriteBatch.Draw(imgTemplateBG, new Vector2(0, 0), null, Color.White);

            spriteBatch.End();


            mySetting.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}