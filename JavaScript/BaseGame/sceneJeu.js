class SceneJeu
{
    constructor()
    {
        this.imageLoader = null;
        this.imgBackGround = null;
        this.wavesManager = new WaveManager();
    }

    load(pImageLoader)
    {
        this.imageLoader = pImageLoader;
        this.imgBackGround = this.imageLoader.getImage("images/background.png");
        this.backGround = new ScrollingBackGround(this.imgBackGround);
        this.backGround.speed = 1.5;

        let imgEnemyBall = this.imageLoader.getImage("images/enemyball.png");
        let spriteEnemyBall = new Sprite(imgEnemyBall);
        spriteEnemyBall.setTileSheet(17,14);
        spriteEnemyBall.addAnimation("IDLE", [0,1,2,3,4,5,6,7,8,9,10], 0.1, true);
        spriteEnemyBall.startAnimation("IDLE");

        this.wavesManager.addWave(new EnemyWave(spriteEnemyBall, 5, 0.5, 320+250, 320, 50));
        this.wavesManager.addWave(new EnemyWave(spriteEnemyBall, 10, 0.5, 320+1000, 320, 150));

    }

    update(dt)
    {
        this.backGround.update(dt);
        this.wavesManager.update(dt, this.backGround.distance);
    }

    draw(pCtx)
    {
        pCtx.save();
        pCtx.scale(2,2);

        // Dessine le fond qui scrolle
        this.backGround.draw(pCtx);
        this.wavesManager.draw(pCtx);

        pCtx.restore();
    }

}























