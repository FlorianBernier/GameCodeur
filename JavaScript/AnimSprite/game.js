
let keyRight = false;
let keyLeft = false;
let keyUp = false;
let keyDown = false;

let imageLoader = new ImageLoader();
let gameReady = false;
let lstSprites = [];

let spriteEnemy;
let spritePlayer;

function rnd(min, max)
{
    return Math.floor(Math.random() * (min - max)) + min;
}

function KeyDown(t)
{
    t.preventDefault();
    if (t.code == "ArrowRight")
    {
        keyRight = true;
    }
    if (t.code == "ArrowUp")
    {
        keyUp = true;
    }
    if (t.code == "ArrowLeft")
    {
        keyLeft = true;
    }
    if (t.code == "ArrowDown")
    {
        keyDown = true;
    }
}

function KeyUp(t)
{
    t.preventDefault();
    if (t.code == "ArrowRight")
    {
        keyRight = false;
    }
    if (t.code == "ArrowUp")
    {
        keyUp = false;
    }
    if (t.code == "ArrowLeft")
    {
        keyLeft = false;
    }   
    if (t.code == "ArrowDown")
    {
        keyDown = false;
    }
}

function load()
{
    document.addEventListener("keydown", KeyDown, false);
    document.addEventListener("keyup", KeyUp, false);

    imageLoader.add("images/enemyred.png");
    imageLoader.add("images/player.png");

    imageLoader.start(startGame);
}

function startGame()
{
    console.log("StartGame");

    lstSprites = [];

    // Player
    let imagePlayer = imageLoader.getImage("images/player.png");
    spritePlayer = new Sprite(imagePlayer);
    spritePlayer.setTileSheet(30, 16);
    spritePlayer.x = 25*4;
    spritePlayer.currentFrame = 12;
    spritePlayer.setScale(4, 4)
    spritePlayer.addAnimation("TURN_RIGHT", [0,1,2,3,4,5,6,7,8], 0.1, false);
    spritePlayer.addAnimation("TURN_UP", [9,10,11,12,13,14,15,16,17,18,19,20], 0.1, false);
    spritePlayer.startAnimation("TURN_RIGHT");

    // Enemy Red
    let imageEnnemy = imageLoader.getImage("images/enemyred.png");
    spriteEnemy = new Sprite(imageEnnemy);
    spriteEnemy.setTileSheet(24, 24);
    spriteEnemy.currentFrame = 3;
    spriteEnemy.setScale(4, 4)
    spriteEnemy.addAnimation("TURN", [0,1,2,3,4,5], 0.1);
    spriteEnemy.startAnimation("TURN");


    lstSprites.push(spritePlayer);
    lstSprites.push(spriteEnemy);

    gameReady = true;
}

function update(dt)
{
    if (!gameReady)
    {
        return;
    }
    // Suite quand le jeu est prêt
    
    lstSprites.forEach(sprite => 
    {
        sprite.update(dt)
    });
    if (spritePlayer.currentAnimation.name == "TURN_RIGHT" && spritePlayer.currentAnimation.end)
    {
        spritePlayer.startAnimation("TURN_UP");
    }

}

function draw(pCtx)
{
    if (!gameReady)
    {
        let ratio = imageLoader.getLoadedRatio();
        pCtx.fillStyle = "rgb(255,255,255)";
        pCtx.fillRect(1, 1, 400, 100)
        pCtx.fillStyle = "rgb(0,255,0)"; 
        pCtx.fillRect(1, 1, 400*ratio, 100)
        return;
    }
    // Suite quand le jeu est prêt
    lstSprites.forEach(sprite => 
    {
        sprite.draw(pCtx);
    });
}




