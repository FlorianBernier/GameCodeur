using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace TowerDefence
{
    public class TD
    {
        private Main main;
        private Map _map;

        // CaseControl
        private CaseControl _caseControl;

        // Monster
        public List<Monster> _listMonster;
        private TimerMiliseconde _monsterCreationTimer;
        public int _wave = 1;
        private TimerMiliseconde _waveTimer;
        private int _MonsterByWave = 15;
        private int _monsterCount = 0;

        //public SpriteFont _font; 

        public TowerFilter towers;


        public TD(Main main, Map map) : base()
        {
            this.main = main;
            _map = map;

            // CaseControl
            _caseControl = new CaseControl(main);

            // Monster
            _listMonster = new List<Monster>();

            
            

            // Créer un timer qui déclenche la méthode CreateNewMonster toutes les 1000 millisecondes (soit 1 seconde)
            _monsterCreationTimer = new TimerMiliseconde(500);
            _waveTimer = new TimerMiliseconde(5000);
            _waveTimer.stop();


            towers = new TowerFilter();

            towers
                .addTower()
                .addTower()
                .addTower();

        }

        public void Initialize()
        {
            _caseControl.Initialize();
        }

        public void LoadContent()
        {
            _caseControl.LoadContent();
        }

        public void UnloadContent()
        {
            _listMonster.ForEach(m => m.UnloadContent());
            _caseControl.UnloadContent();
        }

        public void Update(GameTime gameTime, Camera2D pCamera)
        {
            CreateNewMonster();
            _listMonster.ForEach(m => m.Update(gameTime));
            _listMonster.RemoveAll(monster => monster.getToRemove());
            _caseControl.Update(gameTime, pCamera);
        }

        public void Draw(GameTime gameTime)
        {
            _listMonster.ForEach(m => m.Draw(gameTime));

            _caseControl.Draw(gameTime);
        }

        private void CreateNewMonster()
        {
            if (_monsterCount < _MonsterByWave && _monsterCreationTimer.elapsed())
            {
                // Créer un nouveau monstre et l'ajouter à la liste
                var newMonster = new Monster(main, _map);
                newMonster.Initialize();
                newMonster.LoadContent((_wave%4) + 1);
                _listMonster.Add(newMonster);

                // Incrémenter le compteur de monstres
                _monsterCount++;                    
                _monsterCreationTimer.restart();
            }

            if (_monsterCount == _MonsterByWave && !_waveTimer.hasStart && _listMonster.Count == 0)
            {
                _waveTimer.restart();
            }

            if (_waveTimer.elapsed() && _waveTimer.hasStart)
            {
                _wave++;
                _waveTimer.stop();
                _monsterCount = 0;
                _MonsterByWave += 2; 
                _monsterCreationTimer.changeTimer(Max(500 - 50 *_wave, 500));
            }


        }

        public int Max(int x, int y)
        {
            return x >= y ? x : y;
        }

    }
}

