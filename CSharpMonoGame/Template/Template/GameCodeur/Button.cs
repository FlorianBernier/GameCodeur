using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCodeur
{
    public delegate void OnClick(Button pSender);
    public class Button : Sprite
    {
        public bool isHover { get; private set; }
        private MouseState oldMS;
        public OnClick onClick { get; set; }

        public Button(Texture2D pTexture) : base(pTexture) 
        {
        
        }

        public override void Update(GameTime gameTime)
        {
            MouseState newMS = Mouse.GetState();
            Point MousePos = newMS.Position;

            if (BoudingBox.Contains(MousePos)) 
            {
                if (!isHover)
                {
                    isHover = true;
                    Debug.WriteLine("The button is now hover");
                }
            }
            else
            {
                if (isHover)
                {
                    Debug.WriteLine("The button is no more hover");
                }
                isHover = false;
            }

            if (isHover)
            {
                if (newMS.LeftButton == ButtonState.Pressed && oldMS.LeftButton == ButtonState.Released)
                {
                    Debug.WriteLine("Button is clicked");
                    if (onClick != null)
                        onClick(this);
                }
            }

            oldMS = newMS;
            base.Update(gameTime);
        }
    }
}
