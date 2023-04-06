using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TowerDefence
{
    public class TD
    {
        private Main main;
        private Map _map;

        // Monster
        public List<Monster> _listMonster;
        private Timer _monsterCreationTimer;
        private int _monsterCount = 0;
        

        public TD(Main main, Map map) : base()
        {
            this.main = main;
            _map = map;

            // Monster
            _listMonster = new List<Monster>();
            

            // Créer un timer qui déclenche la méthode CreateNewMonster toutes les 1000 millisecondes (soit 1 seconde)
            _monsterCreationTimer = new Timer(1000);
            _monsterCreationTimer.Elapsed += (sender, e) => CreateNewMonster();
            _monsterCreationTimer.Start();
        }

        public void Initialize()
        {
            foreach (Monster monster in _listMonster)
            {
                monster.Initialize();
            }
        }

        public void LoadContent()
        {
            foreach (Monster monster in _listMonster)
            {
                monster.LoadContent();
            }

        }

        public void UnloadContent()
        {
            foreach (Monster monster in _listMonster)
            {
                monster.UnloadContent();
            }

        }

        public void Update(GameTime gameTime)
        {
            foreach (Monster monster in _listMonster)
            {
                monster.Update(gameTime);
            }

        }

        public void Draw(GameTime gameTime)
        {
            foreach (Monster monster in _listMonster)
            {
                monster.Draw(gameTime);
            }

        }

        private void CreateNewMonster()
        {
            if (_monsterCount < 40)
            {
                // Créer un nouveau monstre et l'ajouter à la liste
                var newMonster = new Monster(main, _map);
                newMonster.Initialize();
                newMonster.LoadContent();
                _listMonster.Add(newMonster);

                // Incrémenter le compteur de monstres
                _monsterCount++;
            }
            else
            {
                // Arrêter le timer si 20 monstres ont été créés
                _monsterCreationTimer.Stop();
            }
        }
    }
}

