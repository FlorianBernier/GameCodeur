
let keyRight = false;
let keyLeft = false;
let keyUp = false;
let keyDown = false;

let imageLoader = new ImageLoader();
let gameReady = false;
let lstSprites = [];

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
}

function KeyUp(t)
{
    t.preventDefault();
    if (t.code == "ArrowRight")
    {
        keyRight = false;
    }
}

function load()
{
    document.addEventListener("keydown", KeyDown, false);
    document.addEventListener("keyup", KeyUp, false);

    imageLoader.add("images/cardBack_blue1.png")
    imageLoader.add("images/cardBack_blue2.png")
    imageLoader.add("images/cardBack_blue3.png")
    imageLoader.add("images/cardBack_blue4.png")
    *imageLoader.add("images/cardBack_blue5.png")

    imageLoader.add("images/cardBack_green1.png")
    imageLoader.add("images/cardBack_green2.png")
    imageLoader.add("images/cardBack_green3.png")
    imageLoader.add("images/cardBack_green4.png")
    imageLoader.add("images/cardBack_green5.png")

    imageLoader.add("images/cardBack_red1.png")
    imageLoader.add("images/cardBack_red2.png")
    imageLoader.add("images/cardBack_red3.png")
    imageLoader.add("images/cardBack_red4.png")
    imageLoader.add("images/cardBack_red5.png")
    
    imageLoader.add("images/cardClubs2.png")
    imageLoader.add("images/cardClubs3.png")
    imageLoader.add("images/cardClubs4.png")
    imageLoader.add("images/cardClubs5.png")
    imageLoader.add("images/cardClubs6.png")
    imageLoader.add("images/cardClubs7.png")
    imageLoader.add("images/cardClubs8.png")
    imageLoader.add("images/cardClubs9.png")
    imageLoader.add("images/cardClubs10.png")
    imageLoader.add("images/cardClubsA.png")
    imageLoader.add("images/cardClubsJ.png")
    imageLoader.add("images/cardClubsK.png")
    imageLoader.add("images/cardClubsQ.png")

    imageLoader.add("images/cardDiamonds10.png")
    imageLoader.add("images/cardDiamonds2.png")
    imageLoader.add("images/cardDiamonds3.png")
    imageLoader.add("images/cardDiamonds4.png")
    imageLoader.add("images/cardDiamonds5.png")
    imageLoader.add("images/cardDiamonds6.png")
    imageLoader.add("images/cardDiamonds7.png")
    imageLoader.add("images/cardDiamonds8.png")
    imageLoader.add("images/cardDiamonds9.png")
    imageLoader.add("images/cardDiamondsA.png")
    imageLoader.add("images/cardDiamondsJ.png")
    imageLoader.add("images/cardDiamondsK.png")
    imageLoader.add("images/cardDiamondsQ.png")

    imageLoader.add("images/cardHearts10.png")
    imageLoader.add("images/cardHearts2.png")
    imageLoader.add("images/cardHearts3.png")
    imageLoader.add("images/cardHearts4.png")
    imageLoader.add("images/cardHearts5.png")
    imageLoader.add("images/cardHearts6.png")
    imageLoader.add("images/cardHearts7.png")
    imageLoader.add("images/cardHearts8.png")
    imageLoader.add("images/cardHearts9.png")
    imageLoader.add("images/cardHeartsA.png")
    imageLoader.add("images/cardHeartsJ.png")
    imageLoader.add("images/cardHeartsK.png")
    imageLoader.add("images/cardHeartsQ.png")

    imageLoader.add("images/cardJoker.png")

    imageLoader.add("images/cardSpades10.png")
    imageLoader.add("images/cardSpades2.png")
    imageLoader.add("images/cardSpades3.png")
    imageLoader.add("images/cardSpades4.png")
    imageLoader.add("images/cardSpades5.png")
    imageLoader.add("images/cardSpades6.png")
    imageLoader.add("images/cardSpades7.png")
    imageLoader.add("images/cardSpades8.png")
    imageLoader.add("images/cardSpades9.png")
    imageLoader.add("images/cardSpadesA.png")
    imageLoader.add("images/cardSpadesJ.png")
    imageLoader.add("images/cardSpadesK.png")
    imageLoader.add("images/cardSpadesQ.png")

    imageLoader.start(startGame);
    
}

function startGame()
{
    console.log("StartGame");

    lstSprites = [];
    for (let image of Object.values(imageLoader.getListImages()))
    {
        let mySprite = new Sprite(image);
        mySprite.x = rnd(400,800);
        mySprite.y = rnd(300,600);
        lstSprites.push(mySprite);
    }   

    gameReady = true;
}

function update(dt)
{
    if (!gameReady)
    {
        return;
    }
    // Suite quand le jeu est prêt
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




