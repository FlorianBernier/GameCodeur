using Microsoft.Xna.Framework;
using System.Collections.Generic;
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
            _listMonster.ForEach(m => m.Initialize());
        }

        public void LoadContent()
        {
            _listMonster.ForEach(m => m.LoadContent());
        }

        public void UnloadContent()
        {
            _listMonster.ForEach(m => m.UnloadContent());
        }

        public void Update(GameTime gameTime)
        {
            _listMonster.ForEach(m => m.Update(gameTime));
            _listMonster.RemoveAll(monster => monster.getToRemove());
        }

        public void Draw(GameTime gameTime)
        {
            _listMonster.ForEach(m => m.Draw(gameTime));
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

