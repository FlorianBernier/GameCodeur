---PIXEL ART / f1: 800x600 / f2: fullScreen / f3: quit / mousepressed(1,2,3): get pos / 
love.graphics.setDefaultFilter("nearest")
SetFullScreen = love.window.setFullscreen(false)
local function load_full_screen()
    if (SetFullScreen) then
        ScreenWidth, ScreenHeight = love.window.getMode()
        Scale_x = ScreenWidth / 800
        Scale_y = ScreenHeight / 600
    end
end
local function draw_full_screen()
    if (SetFullScreen) then love.graphics.scale(Scale_x,Scale_y) end
end
local function keypressed_key(key)
    if (key == "f1") then
        SetFullScreen = love.window.setFullscreen(false)
    end
    if (key == "f2") then
        SetFullScreen = love.window.setFullscreen(true)
    end
    if (key == "f3") then
        love.event.quit()
    end
end
local function mousepressed_get_pos()
    if love.mouse.isDown(1,2,3) then
        print(love.mouse.getPosition())
    end
end
--- --- --- --- --- --- --- --- --- --- --- --- ---
local CONST = {speedHero = 100, speedSprite = 7}

local listSprite = {}
local hero = {}


function createSprite(pList, pType, pImgFileName, pFrame)
    local mySprite = {}
    mySprite.type = pType
    mySprite.img = {}
    mySprite.currentFrame = 1
    for i = 1, pFrame do
        local fileName = "images/"..pImgFileName..tostring(i)..".png"
        print("Loading frame "..fileName)
        mySprite.img[i] = love.graphics.newImage(fileName)
    end

    mySprite.x = 0
    mySprite.y = 0
    mySprite.w = mySprite.img[1]:getWidth()
    mySprite.h = mySprite.img[1]:getHeight()

    table.insert(pList, mySprite)
    return mySprite
end

--- --- --- --- --- --- --- --- --- --- --- --- ---

function createHero()
    hero = createSprite(listSprite, "hero", "player_", 4)
    hero.x = ScreenWidth / 2
    hero.y = (ScreenHeight / 6) * 5
end

function createZombie()
    local myZombie = createSprite(listSprite, "zombie", "monster_", 2)
    myZombie.x = math.random(10, ScreenWidth - 10)
    myZombie.y = math.random(10, (ScreenHeight/2) - 10)
end

love.load = function()
    load_full_screen()
    ScreenWidth = love.graphics.getWidth()/2--larg(800)x
    ScreenHeight = love.graphics.getHeight()/2--haut(600)y

    createHero()

    local nZombies
    for nZombie = 1, 10 do
        createZombie()
    end
end


function animeSprite(dt)
    for i, sprite in ipairs(listSprite) do
        sprite.currentFrame = sprite.currentFrame + CONST.speedSprite*dt
        if sprite.currentFrame >= #sprite.img+1 then-- +1: du fait d'avoir utiliser math.floor(frame)
            sprite.currentFrame = 1
        end
    end
end

function moveHero(dt)
    if love.keyboard.isDown("left") and hero.x > 0 then
        hero.x = hero.x - CONST.speedHero * dt
    end
    if love.keyboard.isDown("right") and hero.x < ScreenWidth then
        hero.x = hero.x + CONST.speedHero * dt
    end
    if love.keyboard.isDown("up") and hero.y > 0 then
        hero.y = hero.y - CONST.speedHero * dt
    end
    if love.keyboard.isDown("down") and hero.y < ScreenHeight then
        hero.y = hero.y + CONST.speedHero * dt
    end
end

love.update = function(dt)
    animeSprite(dt)
    moveHero(dt)
end


love.draw = function()
    draw_full_screen()
    love.graphics.push()
    love.graphics.scale(2, 2)
    for i, sprite in ipairs(listSprite) do
        local frame = sprite.img[math.floor(sprite.currentFrame)]
        love.graphics.draw(frame, sprite.x - (sprite.w/2), sprite.y - (sprite.h/2))
    end
    love.graphics.pop()
end


love.keypressed = function(key)
    keypressed_key(key)
    print(key)
end


love.mousepressed = function()
    mousepressed_get_pos()
end