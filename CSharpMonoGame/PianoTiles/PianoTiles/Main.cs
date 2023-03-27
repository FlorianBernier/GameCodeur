using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace PianoTiles
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Random rand;

        Texture2D backGround1;
        Texture2D backGround2;
        Texture2D backGround3;
        Texture2D grille;
        Texture2D button;
        bool buttonOn = false;
        private Song sound1;


        Texture2D note;
        Texture2D noteOn;

        Vector2 notePos;
        int noteSpeed;
        bool noteClick = false;



        
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            notePos = new Vector2 (297, -300);
            noteSpeed = 2;

            rand = new Random();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backGround1 = this.Content.Load<Texture2D>("backGround1");
            backGround2 = this.Content.Load<Texture2D>("backGround2");
            backGround3 = this.Content.Load<Texture2D>("backGround3");

            button = this.Content.Load<Texture2D>("button");
            grille = this.Content.Load<Texture2D>("grille");

            note = this.Content.Load<Texture2D>("note");
            noteOn = this.Content.Load<Texture2D>("noteClicked");
            sound1 = Content.Load<Song>("pianoTiles1");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState mouseState = Mouse.GetState();
            Rectangle buttonRectangle = new Rectangle(50, 50, button.Width, button.Height);
            if (buttonRectangle.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                buttonOn = true;
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(sound1);
            }

            if (buttonOn)
            {
                notePos.Y = notePos.Y + noteSpeed;
                if (notePos.Y >= 480)
                {
                    notePos.Y = 0 + noteSpeed;
                }
            }

            Rectangle noteRectangle = new Rectangle((int)notePos.X, (int)notePos.Y, note.Width, note.Height);
            if (noteRectangle.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
            {
                noteClick = true;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            Rectangle backgroundRectangle = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            spriteBatch.Draw(backGround1, backgroundRectangle, Color.White);

            Rectangle gridRectangle = new Rectangle((_graphics.PreferredBackBufferWidth - grille.Width) / 2, (_graphics.PreferredBackBufferHeight - grille.Height) / 2,grille.Width, grille.Height);
            spriteBatch.Draw(grille, gridRectangle, Color.White);

            spriteBatch.Draw(button, new Vector2(50,50), Color.White);

            if (buttonOn)
            {
                if (noteClick == false)
                {
                    if ((notePos.Y > 0) && (notePos.Y < 480))
                    {
                        spriteBatch.Draw(note, notePos, null, Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(noteOn, notePos, null, Color.White);
                }
            }
            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}