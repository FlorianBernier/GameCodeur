using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TowerDefence
{
    public class Monster
    {
        private Main main;
        private Map map;
        private bool toRemove = false;

        private Texture2D _textureMonster;

        private Vector2 _position;
        private Vector2 _velocity;


        private bool _isMovingDown = true;
        private bool _isMovingRight = false;
        private bool _isMovingUp = false;
        private bool _isMovingLeft = false;

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

            _textureMonster = main.Content.Load<Texture2D>("Monster1");
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            // Convertir la position du monstre en indices de tuile
            int tileX = (int)Math.Floor((_position.X +32) / map.tileWidth);
            int tileY = (int)Math.Floor((_position.Y + 32) / map.tileHeight);

            // Vérifier la prochaine tuile dans la direction actuelle
            int nextTileX = tileX;
            int nextTileY = tileY;


            // Vérifier la direction du mouvement actuel
            if (_isMovingDown)
            {
                nextTileY++; // prochaine tuile en bas
            }
            else if (_isMovingRight)
            {
                nextTileX++; // prochaine tuile à droite
            }
            else if (_isMovingUp)
            {
                nextTileY--; // prochaine tuile en haut
            }
            else if (_isMovingLeft)
            {
                nextTileX--; // prochaine tuile à gauche
            }


            // Vérifier si la prochaine tuile est dans les limites de la carte
            if (nextTileX >= 0 && nextTileX < map.mapWidth && nextTileY >= 0 && nextTileY < map.mapHeight)
            {
                // Vérifier si la prochaine tuile est un chemin valide
                if (map.map.Layers[0].Tiles[nextTileY * map.mapWidth + nextTileX].Gid != 27)
                {
                    // Si ce n'est pas le cas, changer de direction
                    if (_isMovingDown)
                    {
                        _isMovingRight = true;
                        _isMovingDown = false;
                    }
                    else if (_isMovingRight)
                    {
                        _isMovingUp = true;
                        _isMovingRight = false;
                    }
                    else if (_isMovingUp)
                    {
                        _isMovingLeft = true;
                        _isMovingUp = false;
                    }
                    else if (_isMovingLeft)
                    {
                        _isMovingDown = true;
                        _isMovingLeft = false;
                    }
                }
            }
            else 
            {
                // Si la prochaine tuile est en dehors des limites de la carte, arrêter le mouvement
                _isMovingDown = false;
                _isMovingRight = false;
                _isMovingUp = false;
                _isMovingLeft = false;
                _velocity.X = 0;
                _velocity.Y = 0;
                toRemove = true;
            }

            // Définir la vitesse en fonction de la direction
            if (_isMovingDown)
            {
                _velocity.X = 0;
                _velocity.Y = 50;
            }
            else if (_isMovingRight)
            {
                _velocity.X = 50;
                _velocity.Y = 0;
            }
            else if (_isMovingUp)
            {
                _velocity.X = 0;
                _velocity.Y = -50;
            }
            else if (_isMovingLeft)
            {
                _velocity.X = -50;
                _velocity.Y = 0;
            }


            // Mettre à jour la position du monstre
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            
        }
        public bool getToRemove()
        {
            return toRemove;
        }


        public void Draw(GameTime gameTime)
        {
            main.spriteBatch.Draw(_textureMonster, _position, Color.White);
        }
    }
}
