using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ClassSingleton
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
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
            MaClass instance1 = MaClass.GetInstance();
            MaClass instance2 = MaClass.GetInstance();

            Debug.WriteLine("Assignation de Soanara dans instance1");
            instance1.Value = "Soanara";

            Debug.WriteLine($"instance1 = {instance1.Value}");
            Debug.WriteLine($"instance2 = {instance1.Value}");


            Debug.WriteLine("Assignation de Héresie dans instance1");
            instance1.Value = "Héresie";

            Debug.WriteLine($"instance1 = {instance1.Value}");
            Debug.WriteLine($"instance2 = {instance1.Value}");

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