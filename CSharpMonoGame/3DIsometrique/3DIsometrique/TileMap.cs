using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIsometrique
{
    class TileMap
    {
        public int mapWidth {  get; set; }
        public int mapHeight { get; set; }
        public int tileWidth2D { get; set; }
        public int tileHeight2D { get; set; }
        public int tileWidth3D { get; set; }
        public int tileHeight3D { get; set; }
        private int[,] _data;

        public TileMap()
        {

        }

        public void set2DTileSize(int pTileWidth, int pTileHeight)
        {
            tileWidth2D = pTileWidth;
            tileHeight2D = pTileHeight;
        }

        public void set3DTileSize(int pTileWidth, int pTileHeight)
        {
            tileWidth3D = pTileWidth;
            tileHeight3D = pTileHeight;
        }

        public void setData(int[,] pArray)
        {

            Trace.WriteLine("SetData : begin ==============");

            _data = pArray;
            mapHeight = pArray.GetLength(0);
            mapWidth = pArray.GetLength(1);
            Trace.WriteLine("Height: " + mapHeight);
            Trace.WriteLine("Width: " + mapWidth);
            Trace.WriteLine("SetData : end ================");

        }

        public int getID(int pLine, int pColumn)
        {
            if (pLine >= 0 && pLine<mapHeight && pColumn >= 0 && pColumn<mapWidth)
            {
                return _data[pLine, pColumn];
            }
            Console.WriteLine("ERROR: getID bad parameters");
            return -1;
        }
        public Vector2 To3D(Vector2 pCoord2D)
        {
            Vector2 newcoord = new Vector2();
            newcoord.X = pCoord2D.X - pCoord2D.Y;
            newcoord.Y = (pCoord2D.X + pCoord2D.Y) / 2;
            return newcoord;
        }
    }
}
