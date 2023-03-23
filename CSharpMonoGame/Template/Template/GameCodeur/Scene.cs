using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace GameCodeur
{
    abstract public class Scene
    {
        protected MainGame mainGame;
        protected List<IActor> listeActor;
        public Scene(MainGame pGame) 
        {
            mainGame = pGame;
            listeActor = new List<IActor>();
        }

        public virtual void Load()
        {

        }
        public virtual void Unload() 
        { 
        
        }
        public virtual void Update(GameTime gameTime) 
        {
            foreach (IActor actor in listeActor) 
            {
                actor.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActor actor in listeActor)
            {
                actor.Draw(mainGame.spriteBatch);
            }
        }
    }
}
