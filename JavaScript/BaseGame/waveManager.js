class Enemy
{
    constructor(pSprite)
    {
        this.sprite = pSprite;
        this.timer = 0;
        this.pendingDelay = 0;
        this.speed = 1;
        this.started = false;
    }

    update(dt)
    {
        this.sprite.update(dt);
    }

    draw(pCtx)
    {
        this.sprite.draw(pCtx);
    }
}

class EnemyWave
{
    constructor(pSprite, pNumber, pPendingDelay, pStartDistance, pX, pY)
    {
        this.enemyList = [];
        this.sprite = pSprite;
        this.startDistance = pStartDistance;
        this.started = false;
        this.number = pNumber;
        this.pendingDelay = pPendingDelay;
        this.x = pX;
        this.y = pY;
    }

    addEnemy(pEnemy)
    {
        this.enemyList.push(pEnemy);
    }

    update(dt)
    {
        for (let i = this.enemyList.length - 1; i >= 0; i--)
        {
            let enemy = this.enemyList[i];

            if (enemy.started == false)
            {
                enemy.timer += dt;
                if (enemy.timer >= enemy.pendingDelay)
                {
                    console.log("enemy demarre a " + enemy.timer);
                    enemy.started = true;
                }
            }

            if (enemy.started)
            {
                enemy.update(dt);
                enemy.sprite.x -= enemy.speed;
                if (enemy.sprite.x < 0 - enemy.sprite.tileSize.x)
                {
                    console.log("supression d'un enemy hors ecran");
                    this.enemyList.splice(i, 1);
                }

            }

        }
    }

    draw(pCtx)
    {
        this.enemyList.forEach(enemy => 
        {
            enemy.draw(pCtx);
        });
    }
}

class WaveManager
{
    constructor()
    {
        this.wavesList = [];
        this.currentWave = null;
        
    }

    addWave(pWave)
    {
        this.wavesList.push(pWave);
    }

    stopWave(pWave)
    {
        console.log("stop la vague précedente");
        let index = this.wavesList.indexOf(pWave);
        if (index != -1)
        {
            this.wavesList.splice(index, 1);
        }
    }

    startWave(pWave)
    {
        console.log("Vague démarée a " + pWave.startDistance);
        pWave.started = true;
        if (pWave.currentWave != null)
        {
            this.stopWave(pWave);
        }

        pWave.currentWave = pWave;

        for (let i = 0; i < pWave.number; i++)
        {
            console.log("créé enemy " + i);

            let mySprite = new Sprite(pWave.sprite.img);
            Object.assign(mySprite, pWave.sprite);

            let enemy = new Enemy(mySprite);
            enemy.sprite.x = pWave.x;
            enemy.sprite.y = pWave.y;
            enemy.pendingDelay = i * pWave.pendingDelay;
            pWave.addEnemy(enemy);

        }
    }

    update(dt, pDistance)
    {
        this.wavesList.forEach(wave => 
        {
            if (pDistance >= wave.startDistance && !this.started)
            {
                this.startWave(wave);
            }
        });
        if (this.currentWave != null)
        {
            this.currentWave.update(dt);
        }
    }

    draw(pCtx)
    {
        if (this.currentWave != null)
        {
            this.currentWave.draw(pCtx);
        }
    }

}






