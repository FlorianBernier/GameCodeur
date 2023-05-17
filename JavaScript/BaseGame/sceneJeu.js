class SceneJeu
{
    constructor()
    {
        this.imageLoader = null;
        this.imgBackGround = null;
    }

    load(pImageLoader)
    {
        this.imageLoader = pImageLoader;
        this.imgBackGround = this.imageLoader.getImage("images/background.png");
        this.backGround = new ScrollingBackGround(this.imgBackGround);
        this.backGround.speed = 1.5;
    }

    update(dt)
    {
        this.backGround.update(dt);
    }

    draw(pCtx)
    {
        pCtx.save();
        pCtx.scale(2,2);

        // Dessine le fond qui scrolle
        this.backGround.draw(pCtx);

        pCtx.restore();
    }

}























