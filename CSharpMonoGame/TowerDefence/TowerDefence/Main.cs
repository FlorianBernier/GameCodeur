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
        // Monogame
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        // Font
        public SpriteFont _font;

        // Setting
        public SettingBase _settingBase;
        public FullScreen _fullScreen;
        public MoveCamera _moveCamera;

        // Menu
        public MenuInGame _menuInGame;

        // Map
        public Map _map;

        // TD
        public TD _TD;

        // camera
        public Camera2D _camera;

        public double _timer;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            //
            _camera = new Camera2D(GraphicsDevice.Viewport);

            // Setting
            _settingBase = new SettingBase(this);
            _fullScreen = new FullScreen(this);
            _moveCamera = new MoveCamera(this);

            // Menu
            _menuInGame = new MenuInGame(this);

            // Map
            _map = new Map(this);

            // TD
            _TD = new TD(this, this._map);

            

            // TODO: Ajoutez ici votre code
            _fullScreen.Initialize();
            _moveCamera.Initialize();
            _menuInGame.Initialize();
            _TD.Initialize();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Monogame
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Font
            _font = Content.Load<SpriteFont>("MyFont");



            // TODO: Ajoutez ici votre code
            _map.MapLoadContent();
            _menuInGame.LoadContent();
            _TD.LoadContent();

        }

        protected override void UnloadContent()
        {
            // TODO: Ajoutez ici votre code
            _fullScreen.UnloadContent();
            _TD.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            
            // TODO: Ajoutez ici votre code
            _fullScreen.Update(gameTime);
            _moveCamera.Update(gameTime);
            _map.MapUpdate(gameTime);
            _menuInGame.Update(gameTime);
            _TD.Update(gameTime, _camera);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            // TODO: Ajoutez ici votre
            _settingBase.Draw(gameTime);
            _fullScreen.DrawSet(gameTime);


            spriteBatch.Begin(transformMatrix:_camera.GetViewMatrix());

            _map.MapDraw(gameTime);
            _TD.Draw(gameTime);

            spriteBatch.End();


            _menuInGame.Draw(gameTime);
            

            _fullScreen.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}