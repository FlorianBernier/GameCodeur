using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

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

        
        int noteSpeed;
        int noteClick = -1;

        int[] columns = new int[] { 297, 349, 401, 453 }; 
        int noteSpawnDelay = 300; 
        int timeSinceLastSpawn = 0;

        List<Vector2> notePositions = new List<Vector2>();


        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rand = new Random();

            notePositions.Add(new Vector2(297, -300)); 
            notePositions.Add(new Vector2(349, -375)); 
            notePositions.Add(new Vector2(401, -450)); 
            notePositions.Add(new Vector2(453, -525));

            noteSpeed = 2;

            

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
                for (int i = 0; i < notePositions.Count; i++)
                {
                    notePositions[i] = new Vector2(notePositions[i].X, notePositions[i].Y + noteSpeed);
                    // Si la note est en dessous de la position 480, on la supprime de la liste
                    if (notePositions[i].Y >= 480)
                    {
                        notePositions.RemoveAt(i);
                        i--; // Pour s'assurer que la note suivante est bien traitée
                    }
                }
            }

            for (int i = 0; i < notePositions.Count; i++)
            {
                notePositions[i] = new Vector2(notePositions[i].X, notePositions[i].Y + noteSpeed);
                Rectangle noteRect = new Rectangle((int)notePositions[i].X, (int)notePositions[i].Y, note.Width, note.Height);
                if (noteRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    notePositions.RemoveAt(i);
                    noteClick = i;
                }
                if (notePositions[i].Y >= 480)
                {
                    notePositions.RemoveAt(i);
                    i--;
                }
            }

            timeSinceLastSpawn += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastSpawn >= noteSpawnDelay)
            {
                int column = rand.Next(4); // Génère un nombre aléatoire entre 0 et 3
                notePositions.Add(new Vector2(columns[column], -note.Height));
                timeSinceLastSpawn = 0;
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
                foreach (int i in Enumerable.Range(0, notePositions.Count))
                {
                    Vector2 notePosition = notePositions[i];
                    spriteBatch.Draw(note, notePosition, null, Color.White);
                }
            }

            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}