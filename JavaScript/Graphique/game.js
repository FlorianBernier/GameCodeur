

let img;
let img2;
let timer;

let keyRight = false;
let keyLeft = false;
let keyUp = false;
let keyDown = false;


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


    img = new Sprite("images/hero.png", 100, 100);
    img2 = new Sprite("images/hero.png", 0, 0);
       
    timer = 0;

}

function update(dt)
{
    timer += dt;
    if (timer >= 1)
    {
        img.x+=10; 
        img.y+=10;
        timer = 0;
    }
    
    if (keyRight)
    {
        img2.x += 1;
    }
}

function draw(pCtx)
{
    img.draw(pCtx)
    img2.draw(pCtx)

}




