using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace GameCodeur
{
    public class GameState
    {
        public enum SceneType
        {
            Menu,
            GamePlay,
            GameOver
        }
        protected MainGame mainGame;
        public Scene CurrentScene { get; set; }

        public GameState(MainGame pGame)
        {
            mainGame = pGame;
        }

        public void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.Unload();
                CurrentScene = null;
            }

            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new SceneMenu(mainGame);
                    break;
                case SceneType.GamePlay:
                    CurrentScene = new SceneGamePlay(mainGame);
                    break;
                case SceneType.GameOver:
                    CurrentScene = new SceneGameOver(mainGame);
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }
    }

}
