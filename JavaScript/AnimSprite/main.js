let canvas = document.getElementById("canvas");
let ctx = canvas.getContext("2d");
let interval;

let derniereUpdate = Date.now();

function run() 
{
    let maintenant = Date.now();
    let dt = (maintenant - derniereUpdate) / 1000;
    derniereUpdate = maintenant;
    update(dt);
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    draw(ctx);
}

function init() 
{
    ctx.imageSmoothingEnabled = false;
    ctx.msImageSmoothingEnabled = false;
    ctx.webkitImageSmoothingEnabled = false;
    ctx.mozImageSmoothingEnabled = false;
    load();
    interval = setInterval(run, 1000 / 60);
}

init();










