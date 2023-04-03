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
            Position = new Vector2(400,240);
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(Zoom) *
                   Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0f));
        }
    }
    public class MoveCamera
    {
        private Main main;
        public Camera2D _camera;
        private float _cameraSpeed = 0.02f;
        private MouseState _previousMouseState;


        public MoveCamera(Main main) : base()
        {
            this.main = main;
        }

        public void Initialize()
        {
            _camera = new Camera2D(main.GraphicsDevice.Viewport);
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();

            if (mouseState.MiddleButton == ButtonState.Pressed)
            {
                _camera.Position += new Vector2((mouseState.X - main.graphics.PreferredBackBufferWidth / 2) * _cameraSpeed,
                                              (mouseState.Y - main.graphics.PreferredBackBufferHeight / 2) * _cameraSpeed);
            }
            var scrollDelta = mouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue;
            if (scrollDelta > 0)
            {
                _camera.Zoom += 0.1f; // Augmente le zoom de 0.1 unité
            }
            else if (scrollDelta < 0 && _camera.Zoom > 0.1f) // Vérifie si le zoom est supérieur à 0.1 pour éviter un zoom négatif
            {
                _camera.Zoom -= 0.1f; // Diminue le zoom de 0.1 unité
            }

            _previousMouseState = mouseState;
        }

        public void Draw(GameTime gameTime)
        {
            
        }
    }
}
