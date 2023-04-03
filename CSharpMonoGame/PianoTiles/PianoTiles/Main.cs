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
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        // Setting
        public SettingBase _settingBase;
        public FullScreen _fullScreen;
        public MoveCamera _moveCamera;

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
        int noteSpawnDelay = 400; 
        int timeSinceLastSpawn = 0;

        List<Vector2> notePositions = new List<Vector2>();


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Setting
            _settingBase = new SettingBase(this);
            _fullScreen = new FullScreen(this);
            _moveCamera = new MoveCamera(this);
        }

        protected override void Initialize()
        {
            _fullScreen.Initialize();
            _moveCamera.Initialize();
            // TODO: Add your initialization logic here
            rand = new Random();

            notePositions.Add(new Vector2(297, -300)); 
            notePositions.Add(new Vector2(349, -375)); 
            notePositions.Add(new Vector2(401, -450)); 
            notePositions.Add(new Vector2(453, -525));

            noteSpeed = 1;

            

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

        protected override void UnloadContent()
        {
            _fullScreen.UnloadContent();
            // TODO: Ajoutez ici votre code

        }

        protected override void Update(GameTime gameTime)
        {
            _fullScreen.Update(gameTime);
            _moveCamera.Update(gameTime);
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
            _settingBase.Draw(gameTime);
            _fullScreen.DrawSet(gameTime);

            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: _moveCamera._camera.GetViewMatrix());

            Rectangle backgroundRectangle = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            spriteBatch.Draw(backGround1, backgroundRectangle, Color.White);

            Rectangle gridRectangle = new Rectangle((graphics.PreferredBackBufferWidth - grille.Width) / 2, (graphics.PreferredBackBufferHeight - grille.Height) / 2,grille.Width, grille.Height);
            spriteBatch.Draw(grille, gridRectangle, Color.White);

            spriteBatch.Draw(button, new Vector2(50,50), Color.White);
            //myButton.Draw(gameTime);

            if (buttonOn)
            {
                foreach (int i in Enumerable.Range(0, notePositions.Count))
                {
                    Vector2 notePosition = notePositions[i];
                    spriteBatch.Draw(note, notePosition, null, Color.White);
                }
            }

            
            spriteBatch.End();

            _fullScreen.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}