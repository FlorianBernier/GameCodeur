using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCodeur
{
    class Sprite : IActor
    {
        // IActor
        public Vector2 Position { get; set; }
        public Rectangle BoudingBox { get; set; }

        // Sprite
        public Texture2D Texture { get; }
        public Sprite(Texture2D pTexture) 
        {
            Texture = pTexture;
        }
        public void Update(GameTime pGameTime)
        {
           BoudingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
