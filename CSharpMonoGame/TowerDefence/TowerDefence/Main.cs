using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Configuration;
using TiledSharp;

namespace TowerDefence
{
    public class Main : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        // Setting
        public SettingBase _settingBase;
        public FullScreen _fullScreen;
        public MoveCamera _moveCamera;

        // Interface
        public Interface _interface;

        // Map
        public Map _map;

        

        // TD
        public TD _TD;


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Setting
            _settingBase = new SettingBase(this);
            _fullScreen = new FullScreen(this);
            _moveCamera = new MoveCamera(this);

            // Interface
            _interface = new Interface(this);

            // Map
            _map = new Map(this);

            

            // TD
            _TD = new TD(this, this._map);

        }

        protected override void Initialize()
        {
            _fullScreen.Initialize();
            _moveCamera.Initialize();
            // TODO: Ajoutez ici votre code
            _interface.Initialize();

            
            _TD.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Ajoutez ici votre code
            _map.MapLoadContent();
            _interface.LoadContent();

            
            _TD.LoadContent();
        }

        protected override void UnloadContent()
        {
            _fullScreen.UnloadContent();
            // TODO: Ajoutez ici votre code
            _TD.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _fullScreen.Update(gameTime);
            _moveCamera.Update(gameTime);
            // TODO: Ajoutez ici votre code
            _interface.Update(gameTime);

            
            _TD.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _settingBase.Draw(gameTime);
            _fullScreen.DrawSet(gameTime);
            // TODO: Ajoutez ici votre

            


            spriteBatch.Begin(transformMatrix: _moveCamera._camera.GetViewMatrix());

            _map.MapDraw(gameTime);
            
            _TD.Draw(gameTime);

            spriteBatch.End();


            _interface.Draw(gameTime);
            

            _fullScreen.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}