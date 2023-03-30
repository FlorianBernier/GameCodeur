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

            mySetting.LoadContent();
            // TODO: Ajoutez ici votre code
        }

        protected override void UnloadContent()
        {
            // TODO: Ajoutez ici votre code
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mySetting.Update(gameTime);
            // TODO: Ajoutez ici votre code

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);


            // TODO: Ajoutez ici votre code
            spriteBatch.Begin();

            mySetting.Draw(gameTime);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}