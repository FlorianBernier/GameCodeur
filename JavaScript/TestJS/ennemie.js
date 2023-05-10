class Ennemie
{
    constructor(px, py)
    {
        this.x = px;
        this.y = py;
        this.energie = 100;
    }

    hit(nNbrPoint)
    {
        this.energie -= nNbrPoint;
        console.log("L'ennemie a maintenant : ", this.energie);
    }
}