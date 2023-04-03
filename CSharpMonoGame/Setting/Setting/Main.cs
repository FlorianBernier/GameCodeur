using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Setting
{
    public class Camera2D
    {
        public Vector2 Position { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        private readonly Viewport _viewport;

        public Camera2D(Viewport viewport)
        {
            _viewport = viewport;
            Zoom = 1f;
            Rotation = 0f;
            Position = Vector2.Zero;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0f));
        }
    }
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public BaseSetting mySetting;
        Texture2D imgTemplateBG;

        private Camera2D _camera;
        private float _cameraSpeed = 0.1f;

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
            _camera = new Camera2D(GraphicsDevice.Viewport);
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

            var mouseState = Mouse.GetState();

            if (mouseState.MiddleButton == ButtonState.Pressed)
            {
                _camera.Position += new Vector2((mouseState.X - graphics.PreferredBackBufferWidth / 2) * _cameraSpeed,
                                              (mouseState.Y - graphics.PreferredBackBufferHeight / 2) * _cameraSpeed);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            mySetting.Base(gameTime);

            // TODO: Ajoutez ici votre
            spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            spriteBatch.Draw(imgTemplateBG, new Vector2(0, 0), null, Color.White);

            spriteBatch.End();


            mySetting.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}