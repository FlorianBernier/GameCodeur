using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _3DIsometrique
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        List<Texture2D> lstTextures2D;
        List<Texture2D> lstTextures3D;
        TileMap myMap;
        Vector2 map2D_origin;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            myMap = new TileMap();
            myMap.set2DSize(32, 32);

            int[,] mapData = new int[,]
            {
                { 2,2,2,2,2,2,2,2,2,1 },
                { 2,2,2,2,2,2,2,2,1,2 },
                { 2,2,2,2,2,2,2,1,2,2 },
                { 2,2,2,2,2,2,1,2,2,1 },
                { 2,2,2,2,2,1,2,2,1,2 },
                { 2,2,2,2,1,2,2,1,2,2 },
                { 2,2,2,1,2,2,1,2,2,2 },
                { 2,2,1,2,2,1,1,1,1,1 },
                { 2,1,2,2,2,2,2,2,2,1 },
                { 1,1,1,1,1,1,1,1,1,1 },
            };

            myMap.setData(mapData);

            map2D_origin = new Vector2(10, 240 - ((myMap.tileHeight2D * myMap.mapHeight) / 2));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            for (int line = 0; line < myMap.mapWidth; line++)
            {
                for (int column = 0; column < myMap.mapHeight; column++)
                {
                    int id = myMap.getID(line, column);
                    if(id >= 0)
                    {
                        int x = column * myMap.tileWidth2D;
                        int y = line * myMap.tileHeight2D;
                        Vector2 pos = new Vector2(x, y);
                        Texture2D tx = lstTextures2D[id-1];
                        if (tx != null)
                        {
                            pos += map2D_origin;
                            spriteBatch.Draw(tx, pos, Color.White);
                        }

                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}