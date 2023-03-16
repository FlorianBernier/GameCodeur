
local pose = false

local lander = {
    x = 0, 
    y = 0,
    angle = -90,
    vx = 0,
    vy = 0,
    speed = 3,
    img = love.graphics.newImage("images/ship.png"),
    imgEngine = love.graphics.newImage("images/engine.png"),
    engineOn = true
}

-----LOAD----- : ACTION DU JEU AU DEMARAGE test 12
function love.load()
    largeur = love.graphics.getWidth()
    hauteur = love.graphics.getHeight()

    lander.x = largeur / 2
    lander.y = hauteur / 2
end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)
if pose == false then
    lander.vy = lander.vy + (0.6 * dt)

    if love.keyboard.isDown("right") then
        lander.angle = lander.angle + (90*dt)
    end
    if love.keyboard.isDown("left") then
        lander.angle = lander.angle - (90*dt)
    end


    if love.keyboard.isDown("up") then
        lander.engineOn = true

        local angle_radian = math.rad(lander.angle)
        local force_x = math.cos(angle_radian) * (lander.speed * dt)
        local force_y = math.sin(angle_radian) * (lander.speed * dt)
        lander.vx = lander.vx + force_x
        lander.vy = lander.vy + force_y
    else
        lander.engineOn = false
    end

    lander.x = lander.x + lander.vx
    lander.y = lander.y + lander.vy
end

    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end

 
-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()
    love.graphics.draw(lander.img, lander.x, lander.y, 
    math.rad(lander.angle), 1, 1, lander.img:getWidth()/2, lander.img:getHeight()/2)



    if lander.engineOn == true then
        love.graphics.draw(lander.imgEngine, lander.x, lander.y,
        math.rad(lander.angle), 1, 1, lander.imgEngine:getWidth()/2, lander.imgEngine:getHeight()/2)
    end
end



-----KEYPRESSED----- : ACTION DU JOUEUR 
function love.keypressed(key)
    print(key)
    if key == "space" then
        pose = not pose 
    end
end