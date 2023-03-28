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
        Vector2 map3D_origin;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            myMap = new TileMap();
            myMap.set2DTileSize(32, 32);
            myMap.set3DTileSize(64, 32);

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

            map2D_origin = new Vector2(10, (_graphics.PreferredBackBufferHeight/2) - ((myMap.tileHeight2D * myMap.mapHeight) / 2));

            map3D_origin = new Vector2(10 + (myMap.tileHeight2D * myMap.mapWidth) + (myMap.tileWidth3D * (myMap.mapWidth/2)), ((myMap.tileHeight2D * myMap.mapHeight) / 2));
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
            lstTextures3D.Add(tx);
            tx = Content.Load<Texture2D>("dirt3D");
            lstTextures3D.Add(tx);
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

            for (int line = 0; line < myMap.mapWidth; line++)
            {
                for (int column = 0; column < myMap.mapHeight; column++)
                {
                    int id = myMap.getID(line, column);
                    if (id >= 0)
                    {
                        int x = column * myMap.tileWidth2D;
                        int y = line * myMap.tileHeight2D;
                        Vector2 pos = new Vector2(x, y);
                        pos = myMap.To3D(pos);
                        Texture2D tx = lstTextures3D[id - 1];
                        // Calcul de la pos en 3D Iso 
                        if (tx != null)
                        {
                            pos += map3D_origin;
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