
let keyRight = false;
let keyLeft = false;
let keyUp = false;
let keyDown = false;

let imageLoader = new ImageLoader();
let gameReady = false;

let sceneJeu = new SceneJeu();
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

    imageLoader.add("images/background.png");
    imageLoader.add("images/enemyball.png");

    
    imageLoader.start(startGame);
}

function startGame()
{
    console.log("StartGame");

    lstSprites = [];
    
    sceneJeu.load(imageLoader);

    gameReady = true;
}

function update(dt)
{
    if (!gameReady)
    {
        return;
    }
    // Suite quand le jeu est prêt
    sceneJeu.update(dt);
    

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
    sceneJeu.draw(pCtx);
}




