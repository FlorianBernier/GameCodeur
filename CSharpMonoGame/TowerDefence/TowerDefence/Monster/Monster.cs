using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TowerDefence
{
    public class Monster
    {
        private Main main;
        private Map map;

        private Texture2D _monster1;

        private Vector2 _position;
        private Vector2 _velocity;

        private bool _isMovingRight = true;

        public Monster(Main main, Map map) : base()
        {
            this.main = main;
            this.map = map;
        }

        public void Initialize()
        {
            _position = new Vector2(64, 0); 
            _velocity = new Vector2(0, 50);

        }

        public void LoadContent()
        {

            _monster1 = main.Content.Load<Texture2D>("Monster1");
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            // Convertir la position du monstre en indices de tuile
            int tileX = (int)Math.Floor(_position.X / map.tileWidth);
            int tileY = (int)Math.Floor((_position.Y + 64)/ map.tileHeight);

            // Vérifier si la tuile actuelle est un chemin
            if (map.map.Layers[0].Tiles[tileY * map.mapWidth + tileX].Gid != 27)
            {
                // Si ce n'est pas le cas, changer de direction
                _isMovingRight = false;
               
                if (_velocity.Y > 0)
                {
                    _velocity.X = 50; // tourner à gauche avec une vitesse horizontale négative
                    _velocity.Y = 0;
                }
               
            }

            // Vérifier la prochaine tuile dans la direction actuelle
            int nextTileX = tileX + (_isMovingRight ? 1 : -1); // ajouter ou soustraire 1 pour la direction
            nextTileX += _isMovingRight ? 1 : -1; // ajouter ou soustraire 32 pour la moitié de la taille du monstre
            nextTileX /= 2; // diviser par 2 pour obtenir l'indice de tuile correct

            int nextTileY = tileY;

            // Vérifier si la prochaine tuile est un chemin valide
            if (map.map.Layers[0].Tiles[nextTileY * map.mapWidth + nextTileX].Gid != 27)
            {
                // Si ce n'est pas le cas, changer de direction
                _isMovingRight = !_isMovingRight;
                //_velocity.X *= -1; // inverser la vitesse horizontale pour changer de direction
            }

            // Mettre à jour la position du monstre
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime)
        {
            main.spriteBatch.Draw(_monster1, _position, Color.White);
        }
    }
}
