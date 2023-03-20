using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LunarLander
{
    public class Lander
    {
        public Vector2 position { get; set; } = Vector2.Zero;
        public Vector2 velocity { get; set; } = Vector2.Zero;
        public float angle { get; set; } = 270;
        public bool enginOn { get; set; } = false;
        public float speed { get; set; } = 0.02f;

        private float speedMax = 2f;
        public Texture2D img { get; set; }
        public Texture2D imgEngine { get; set; }

        public void update()
        {
            velocity += new Vector2(0, 0.005f);

            if (Math.Abs(velocity.X) >= speedMax )
            {
                velocity = new Vector2((velocity.X < 0 ? 0 - speedMax : speedMax), velocity.Y);
            }
            if (Math.Abs(velocity.Y) >= speedMax)
            {
                velocity = new Vector2(velocity.X, (velocity.Y < 0 ? 0 - speedMax : speedMax));
            }


            position += velocity;
        }
    }




    // Classe principale du jeu
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Lander lander;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Ajoutez ici votre code

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Ajoutez ici votre code 
            lander = new Lander();

            lander.img = Content.Load<Texture2D>("ship");
            lander.imgEngine = Content.Load<Texture2D>("engine");

            lander.position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Ajoutez ici votre code
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                lander.angle += 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                lander.angle -= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                lander.enginOn = true;

                float angle_radian = MathHelper.ToRadians(lander.angle);
                float force_x = (float)Math.Cos(angle_radian) * lander.speed;
                float force_y = (float)Math.Sin(angle_radian) * lander.speed;
                lander.velocity += new Vector2(force_x, force_y);


            }
            else
            {
                lander.enginOn = false;
            }

            lander.update();

            if (lander.position.X < 0 )
            {
                lander.position = new Vector2(0, lander.position.Y);
                lander.velocity = new Vector2(0 - lander.velocity.X, lander.velocity.Y);
            }
            if (lander.position.X > GraphicsDevice.Viewport.Width)
            {
                lander.position = new Vector2(GraphicsDevice.Viewport.Width, lander.position.Y);
                lander.velocity = new Vector2(0 - lander.velocity.X, lander.velocity.Y);
            }

            if (lander.position.Y < 0)
            {
                lander.position = new Vector2(lander.position.X, GraphicsDevice.Viewport.Height);
            }

            if (lander.position.Y > GraphicsDevice.Viewport.Height)
            {
                lander.position = new Vector2(lander.position.X, 0);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Ajoutez ici votre code
            _spriteBatch.Begin();

            Vector2 originImg = new Vector2(lander.img.Width / 2, lander.img.Height / 2);
            _spriteBatch.Draw(lander.img, lander.position, null, Color.White, MathHelper.ToRadians(lander.angle), originImg, new Vector2(1,1), SpriteEffects.None, 0);

            if (lander.enginOn)
            {
                Vector2 originImgEngine = new Vector2(lander.imgEngine.Width / 2, lander.imgEngine.Height / 2);
                _spriteBatch.Draw(lander.imgEngine, lander.position, null, Color.White, MathHelper.ToRadians(lander.angle), originImgEngine, new Vector2(1, 1), SpriteEffects.None, 0);

            }

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}