using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3DIsometrique
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Texture2D> lstTextures2D;
        List<Texture2D> lstTextures3D;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            lstTextures2D = new List<Texture2D>();
            lstTextures3D = new List<Texture2D>();

            Texture2D tx;
            tx = Content.Load<Texture2D>("stone2D");
            lstTextures2D.Add(tx);
            tx = Content.Load<Texture2D>("dirt2D");
            lstTextures2D.Add(tx);


            tx = Content.Load<Texture2D>("stone3D");
            lstTextures2D.Add(tx);
            tx = Content.Load<Texture2D>("dirt3D");
            lstTextures2D.Add(tx);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}