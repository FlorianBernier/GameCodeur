

let img;
let img2;

function load()
{
    img = new Sprite("images/hero.png", 100, 100);
    img2 = new Sprite("images/hero.png", 0, 0);
       
}

function update()
{
    img.x++
    img.y++
}

function draw(pCtx)
{
    img.draw(pCtx)
    img2.draw(pCtx)

}




