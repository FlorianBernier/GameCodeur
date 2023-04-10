using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TiledSharp;

namespace TowerDefence
{
    public class Map
    {
        public Main main;
        // Map
        public TmxMap map;
        public Texture2D tileset;
        public int tileWidth;
        public int tileHeight;
        public int mapWidth;
        public int mapHeight;
        public int tilesetColumns;
        public int tilesetLines;




        public Map(Main main) : base()
        {
            this.main = main;
        }


        public void MapInitialize()
        {
                
        }

        public void MapLoadContent()
        {
            map = new TmxMap("Content/mapTD.tmx");
            tileset = main.Content.Load<Texture2D>(map.Tilesets[0].Name.ToString());

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            mapWidth = map.Width;
            mapHeight = map.Height;

            tilesetColumns = tileset.Width / tileWidth;
            tilesetLines = tileset.Height / tileHeight;

    

        }

        public void MapUnloadContent()
        {

        }

        public void MapUpdate(GameTime gameTime)
        {
            
        }


        public void MapDraw(GameTime gameTime)
        {
            int nbLayers = map.Layers.Count;
            int line;
            int column;

            for (int nLayer = 0; nLayer < nbLayers; nLayer++)
            {
                line = 0;
                column = 0;

                for (int i = 0; i < map.Layers[nLayer].Tiles.Count; i++)
                {
                    int gid = map.Layers[nLayer].Tiles[i].Gid;

                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;
                        int tilesetColumn = tileFrame % tilesetColumns;
                        int tilesetLine = (int)Math.Floor((double)tileFrame / (double)tilesetColumns);

                        float x = column * map.TileWidth;
                        float y = line * map.TileHeight;

                        Rectangle tilesetRect = new Rectangle(tileWidth * tilesetColumn, tileHeight * tilesetLine, tileWidth, tileHeight);

                        main.spriteBatch.Draw(tileset, new Vector2(x, y), tilesetRect, Color.White);

                        

                    }
                    column++;
                    if (column == mapWidth)
                    {
                        column = 0;
                        line++;
                    }
                }
            }
        }
    }
}