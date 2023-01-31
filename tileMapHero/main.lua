
love.graphics.setDefaultFilter("nearest")
------VARIABLE------
------TABLEAU------
------FONCTION LOAD------
------FONCTION UPDATE------
------FONCTION KEYPRESSED------
------FONCTION MOUSEPRESSED------
------FONCTION UTILE------
function math.dist(x1,y1, x2,y2) return ((x2-x1)^2+(y2-y1)^2)^0.5 end

local myGame = require("game")


-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()
    love.window.setMode(1024, 768)

    Larg = love.graphics.getWidth()
    Haut = love.graphics.getHeight()

    myGame.load()
    
end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)
    myGame.update(dt)


    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end


-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()
    myGame.draw()
end



-----KEYPRESSED----- : ACTION DU JOUEUR CLAVIER
function love.keypressed(key)
    print(key) 
end

-----MOUSEPRESSED----- : ACTION DU JOUEUR SOURIS
function love.mousepressed()
end