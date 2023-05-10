console.log("Hello world !");

let score = 100;

let vies;
vies = 5;

let marge1 = 5.5;
let porteOuverte = true;
let autreBool = false;

const marge = 10;
let nom = "Soanara";

vies = vies - 1;
vies--;
vies++;

vies+=5;
vies-=5;

nom += " Heresie"

console.log(nom)

console.log("vies : ", vies);

let hero = {
    x: 10,
    y: 50,
    speed: 2
}

console.log(hero.x);


function test(px, py = 100){
    console.log("test : ", px, py);
    let x = 3;
    console.log("x = ", x)
}

test(1);

if (vies >= 3 || vies <=5 ){
    console.log("Il vous reste moins de 5 vies!")
}

if (vies != 5)
{
    console.log("Vous n'avez pas 5 vies")
}

if (!porteOuverte)
{
    console.log("La porte est fermé")
} 
else 
{
    console.log("La porte est ouverte")
}

for (let i = 10; i > 0; i--)
{
    console.log("i =", i);
}

let index = 0;
do 
{
    console.log("index", index);
    index++;
}
while (index < 10);

index = 0;
while (index < 10)
{
    console.log("index", index);
    index++;
}

let jour = ["lundi", "mardi", "mercredi", "jeudi", "vendredi"];
console.log(jour[0]);

let listeEnnemis = [];



let monEnnemie = new Ennemie();
listeEnnemis.push(monEnnemie)
console.log(monEnnemie.energie)

for (let n=0; n<10; n++)
{
    let monEnnemie = new Ennemie(1,1);
    listeEnnemis.push(monEnnemie);
}

console.log(listeEnnemis.length)

listeEnnemis[0].hit(10);














