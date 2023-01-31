--permet d'afficher des traces dans la console pendant l'execution
io.stdout:setvbuf('no')
--permet de deboguer pas a pas dans ZeroBraneStudio
if arg[#arg] == "-debug" then require("mobdebug").start() end
---------------------------------------------------------------------------

------VARIABLE------
------TABLEAU------
local pad = {
    x = 0, y = 0, larg = 80, haut = 20
}

local balle = {
    x = 0, y = 0, rad = 10, colle = false, vx = 0, vy = 0

}

local brique = {}
local niveau = {}
------FONCTION LOAD------
function Demarre()
    balle.colle = true

    niveau = {}
    local l,c

    for l=1,6 do
        niveau[l] = {}
        for c=1,15 do
        niveau[l][c] = 1
        end
    end
end
------FONCTION UPDATE------
------FONCTION KEYPRESSED------
------FONCTION MOUSEPRESSED------
------FONCTION UTILE------



-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()

    Larg = love.graphics.getWidth()
    Haut = love.graphics.getHeight()

    brique.larg = Larg / 15
    brique.haut = 25

    -- ou demarre la balle
    pad.y = Haut - (pad.haut / 2)
    Demarre()
end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)
    pad.x = love.mouse.getX()

    if balle.colle == true then
        balle.x = pad.x
        balle.y = pad.y - pad.haut / 2 - balle.rad / 2
    else
        balle.x = balle.x + (balle.vx*dt)
        balle.y = balle.y + (balle.vy*dt)
    end

    local c = math.floor(balle.x / brique.larg) +1
    local l = math.floor(balle.y / brique.haut) +1

    if l >= 1 and l <= #niveau and c >= 1 and c <= 15 then
        if niveau[l][c] == 1 then
        balle.vy = 0 - balle.vy
        niveau [l][c] = 0
        end
    end

    --rebond balle droit
    if balle.x > Larg then
        balle.vx = 0 - balle.vx
        balle.x = Larg
    end
    --rebond balle gauche
    if balle.x < 0 then
        balle.vx = 0 - balle.vx
        balle.x = 0
    end
    --rebond balle haut
    if balle.y < 0 then
        balle.vy = 0 - balle.vy
        balle.y = 0
    end
    -- colle la balle a la raquette
    if balle.y > Haut then
        balle.colle = true
    end
    -- colision de la balle avec le pad
    local posColisionPad = pad.y - (pad.haut / 2) - balle.rad
        if balle.y > posColisionPad then
            local dist = math.abs(pad.x - balle.x)
            if dist < pad.larg / 2 then
                balle.vy = 0 - balle.vy
                balle.y = posColisionPad
            end
        end

    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end


-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()

    local l,c
    local bx,by = 0,0
    for l = 1,6 do
        bx = 0
    for c = 1,15 do
        if niveau[l][c] == 1 then
            love.graphics.rectangle("fill", bx +1, by+1, brique.larg-2, brique.haut-2)
        end
        bx = bx + brique.larg
    end
    by = by + brique.haut
end

    love.graphics.rectangle("fill", pad.x - (pad.larg / 2), pad.y - (pad.haut / 2), pad.larg, pad.haut)

    love.graphics.circle("fill", balle.x, balle.y, balle.rad)
end


-----KEYPRESSED----- : ACTION DU JOUEUR
function love.keypressed(key)
    print(key)
end


-----MOUSEPRESSED--------- : ACTION DU JOUEUR SOURIS
function love.mousepressed(x, y, button)
    if balle.colle == true then
        balle.colle = false
        balle.vx = 400
        balle.vy = -400

    end
end