﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCodeur
{
    public class Sprite : IActor
    {
        // IActor
        public Vector2 Position { get; set; }
        public Rectangle BoudingBox { get; set; }
        public float vx;
        public float vy;
        public bool ToRemove {get; set;}

        // Sprite
        public Texture2D Texture { get; }

        public Sprite(Texture2D pTexture) 
        {
            Texture = pTexture;
            ToRemove = false;
        }
        
        public void Move(float pX, float pY)
        {
            Position = new Vector2(Position.X + pX, Position.Y + pY);
        }

        public virtual void TouchedBy(IActor pBy)
        {

        }

        public virtual void Update(GameTime pGameTime)
        {
            Move(vx, vy);
            BoudingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        }

        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
