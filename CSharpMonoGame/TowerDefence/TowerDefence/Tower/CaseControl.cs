using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TowerDefence
{



    public class CaseControl
    {
        private Main main;

        private Texture2D _textureCase;
        private Rectangle[,] _rectCase;
        private int[,] _caseHasTexture;
        private bool[,] _caseHover;



        public CaseControl(Main main) : base()
        {
            this.main = main;
        }

        public void Initialize()
        {
            {
                _rectCase = new Rectangle[15, 15];
                _caseHover = new bool[15, 15];
                _caseHasTexture = new int[15, 15]
                {
                    { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                    { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,0,0,0,1,0,0,0,1,0,0,0,1,0 },
                    { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                    { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                };
               

                // initialiser les rectangles des cases

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        _rectCase[i, j] = new Rectangle(i * 64, j * 64, 64, 64);
                    }
                }
            }
        }

        public void LoadContent()
        {
            _textureCase = main.Content.Load<Texture2D>("BtnLineWhite");
        }

        public void UnloadContent()
        {
            _textureCase.Dispose();
        }

        public void Update(GameTime gameTime, Camera2D pCamera)
        {
            MouseState mouseState = Mouse.GetState();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Rectangle caseRect = _rectCase[i, j];

                    int caseX = (int)Math.Floor((double)((mouseState.X - pCamera.GetViewMatrix().M41) / pCamera.GetViewMatrix().M11) / caseRect.Width);
                    int caseY = (int)Math.Floor((double)((mouseState.Y - pCamera.GetViewMatrix().M42) / pCamera.GetViewMatrix().M11) / caseRect.Height);

                    if (i == caseX && j == caseY)
                    {
                        _caseHover[i, j] = true;
                    }
                    else
                    {
                        _caseHover[i, j] = false;
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            // afficher les cases
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Rectangle destinationRectangle = new Rectangle(i * 64, j * 64, 64, 64);
                    if (_caseHasTexture[j, i] == 0 && _caseHover[i, j])
                    {
                       main.spriteBatch.Draw(_textureCase, destinationRectangle, Color.White);
                    }
                }
            }
        }
    }
}
