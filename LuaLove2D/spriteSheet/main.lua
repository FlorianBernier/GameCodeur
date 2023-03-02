

------VARIABLE------
------TABLEAU------
animation = {
    up = {},
    down = {},
    left = {},
    right = {}
  }
animation.x = 0
animation.y = 0


------FONCTION LOAD------
------FONCTION UPDATE------
------FONCTION KEYPRESSED------
------FONCTION MOUSEPRESSED------
------FONCTION UTILE------

-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()
    animation.img = love.graphics.newImage("images/hero.png")

    -- Chargement des quads pour les différentes directions
    local directions = {"up", "left", "down", "right"}

    for i, direction in ipairs(directions) do
        for j = 0, 9 do
            animation[direction][j+1] = love.graphics.newQuad(j * 64, 64 * (i+7), 64, 64, animation.img)
        end
    end
    animation.nbImg = 9
    animation.imgActuelle = 0
    animation.direction = "down"
end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)
    if love.keyboard.isDown("up") then
        animation.direction = "up"
        animation.y = animation.y - 100 * dt

    elseif love.keyboard.isDown("down") then
        animation.direction = "down"
        animation.y = animation.y + 100 * dt

    elseif love.keyboard.isDown("left") then
        animation.direction = "left"
        animation.x = animation.x - 100 * dt
        
    elseif love.keyboard.isDown("right") then
        animation.direction = "right"
        animation.x = animation.x + 100 * dt
    end

    animation.imgActuelle = animation.imgActuelle + animation.nbImg * dt
    if animation.imgActuelle >= animation.nbImg then
        animation.imgActuelle = 0
    end


    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end


-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()
    local directions = {
        up = animation.up,
        down = animation.down,
        left = animation.left,
        right = animation.right
      }
      
      love.graphics.draw(animation.img, directions[animation.direction][math.floor(animation.imgActuelle)+1], animation.x, animation.y)
    end



-----KEYPRESSED----- : ACTION DU JOUEUR CLAVIER
function love.keypressed(key)
    print(key) 
end

-----MOUSEPRESSED----- : ACTION DU JOUEUR SOURIS
function love.mousepressed()
end


