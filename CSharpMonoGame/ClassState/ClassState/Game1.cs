using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClassState
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
            Zombie zombie = new Zombie();

            zombie.DoSomething();

            zombie.WhatHappen = ZombieStimuli.SeeHuman;
            zombie.DoSomething();

            zombie.WhatHappen = ZombieStimuli.SeeNothing;
            zombie.DoSomething();

            zombie.WhatHappen = ZombieStimuli.SeeHuman;
            zombie.DoSomething();

            zombie.WhatHappen = ZombieStimuli.OnHuman;
            zombie.DoSomething();

            zombie.WhatHappen = ZombieStimuli.SeeNothing;
            zombie.DoSomething();

            zombie.DoSomething();
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