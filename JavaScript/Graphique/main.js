

let canvas = document.getElementById("canvas");
let ctx = canvas.getContext("2d")
let interval; 

function run()
{
    update();
    ctx.clearRect(0,0,canvas.Width, canvas.height);
    draw(ctx);
}




function init()
{
    console.log("init")
    load();
    interval = setInterval(run, 1000/60);

}


init();











