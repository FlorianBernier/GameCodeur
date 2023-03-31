using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


// Observer (gestion des touche clavier / souris) 
namespace ClassObserver
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
            Magasin appleStore = new Magasin();
            Client soanara = new Client("Soanara");
            Client heresie = new Client("Heresie");

            appleStore.Register(soanara);
            appleStore.Register(heresie);

            appleStore.DoSomething();
            appleStore.DoSomething();
            appleStore.DoSomething();
            appleStore.DoSomething();

            appleStore.Unregister(heresie);

            appleStore.DoSomething();
            appleStore.DoSomething();
            appleStore.DoSomething();
            appleStore.DoSomething();




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