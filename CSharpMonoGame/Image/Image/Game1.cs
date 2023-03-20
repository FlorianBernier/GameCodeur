using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;

namespace Image
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D img;
        Vector2 position;
        int speed;

        Texture2D img2;
        Vector2 position2;
        int speed2;
        float scale;
        float scaleSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Ajoutez ici votre code
            position = new Vector2 (100, 0);
            speed = 5;

            position2 = new Vector2(100, 200);
            speed2 = 5;
            scale = 1.0f;
            scaleSpeed = -0.01f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Ajoutez ici votre code
            img = this.Content.Load<Texture2D>("personnage");
            img2 = this.Content.Load<Texture2D>("slimePurple");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Ajoutez ici votre code
            position.X = position.X + speed;
            if (position.X + img.Width > GraphicsDevice.Viewport.Width)
            {
                speed = 0 - speed;
            }
            if (position.X < 0)
            {
                speed = 0 - speed;
            }

            position2.X = position2.X + speed2;
            if (position2.X + img2.Width > GraphicsDevice.Viewport.Width)
            {
                speed2 = 0 - speed2;
            }
            if (position2.X < 0)
            {
                speed2 = 0 - speed2;
            }

            scaleSpeed += scaleSpeed;
            if (scale <= 0.5f)
            {
                scale = 0.5f;
                scaleSpeed = 0 - scaleSpeed;
            }
            if (scale > 1.0f)
            {
                scale = 1.0f;
                scaleSpeed = 0 - scaleSpeed; 
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Ajoutez ici votre code
            _spriteBatch.Begin();
            _spriteBatch.Draw(img, position, Color.White);
            SpriteEffects effect;
            effect = SpriteEffects.None;
            if (speed2 > 0)
                effect = SpriteEffects.FlipHorizontally;
            _spriteBatch.Draw(img2, position2, null, Color.White, 0, Vector2.Zero, new Vector2(scale, 1.0f), effect, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}