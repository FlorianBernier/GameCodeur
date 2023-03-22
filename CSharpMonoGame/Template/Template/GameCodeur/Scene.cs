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
        public Scene(MainGame pGame) 
        {
            mainGame = pGame;
        }

        public virtual void Load()
        {

        }
        public virtual void Unload() 
        { 
        
        }
        public virtual void Update(GameTime gameTime) 
        {
        
        }
        public virtual void Draw(GameTime gameTime)
        {

        }
    }
}
