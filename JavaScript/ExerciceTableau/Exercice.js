console.log("Exercice")

let ligne = [1,1,1,0,1,0,1,1,1,0,1,1];



let groupes = [];

let compteur = 0;

for (let n=0; n<ligne.length; n++)
{
    if (ligne[n] == 1)
    {
        compteur++;

    }
    else
    {
        if (compteur > 0)
        {
            groupes.push(compteur);
            compteur = 0;
        }
        
    }
}
if (compteur > 0 )
{
    groupes.push(compteur);
}


console.log({ groupes });








