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
-- Returns the distance between two points.
function math.dist(x1,y1, x2,y2) return ((x2-x1)^2+(y2-y1)^2)^0.5 end

-- Returns the angle between two vectors assuming the same origin.
function math.angle(x1,y1, x2,y2) return math.atan2(y2-y1, x2-x1) end

local VAR = {speedSprite = 7, speedHero = 100}

local ZSTATES = {NONE = "", WALK = "walk", ATTACK = "attack", BITE = "bite", CHANGEDIR = "change"}

local imgAlert = love.graphics.newImage("images/alert.png")

local listSprite = {}
local hero = {}

imhZombie= {
    love.graphics.newImage("images/monster_1.png"), 
    love.graphics.newImage("images/monster_2.png")}



function createSprite(pList, pType, pImgFileName, pFrame)
    local mySprite = {}
    mySprite.type = pType
    mySprite.visible = true
    mySprite.img = {}
    mySprite.currentFrame = 1
    mySprite.img = imhZombie

    mySprite.x = 0
    mySprite.y = 0
    mySprite.vx = 0
    mySprite.vy = 0
    mySprite.w = mySprite.img[1]:getWidth()
    mySprite.h = mySprite.img[1]:getHeight()

    table.insert(pList, mySprite)
    return mySprite
end

--- --- --- --- --- --- --- --- --- --- --- --- ---

function createHero()
    --local hero = {}
    hero = createSprite(listSprite, "hero", "player_", 4)
    hero.x = ScreenWidth / 2
    hero.y = (ScreenHeight / 6) * 5
    hero.speed = 0
    hero.life = 100
    hero.hurt = function()
        hero.life = hero.life - 0.1
        if hero.life <= 0 then
            hero.life = 0
            hero.visible = false
        end
    end
    --return hero
end

function createZombie()
    local myZombie = createSprite(listSprite, "zombie", "monster_", 2)
    myZombie.x = math.random(10, ScreenWidth - 10)
    myZombie.y = math.random(10, (ScreenHeight/2) - 10)
    myZombie.speed = math.random(5, 50) / 200
    myZombie.range = math.random(10, 150)
    myZombie.target = nil

    myZombie.state = ZSTATES.NONE
end

love.load = function()
    load_full_screen()
    ScreenWidth = love.graphics.getWidth()/2--larg(800)x
    ScreenHeight = love.graphics.getHeight()/2--haut(600)y

    createHero()

    local nZombies
    for nZombie = 1, 100 do
        createZombie()
    end

end


function animeSprite(dt)
    for i, sprite in ipairs(listSprite) do
        sprite.currentFrame = sprite.currentFrame + VAR.speedSprite*dt
        if sprite.currentFrame >= #sprite.img+1 then-- +1: du fait d'avoir utiliser math.floor(frame)
            sprite.currentFrame = 1
        end
        sprite.x = sprite.x + sprite.vx * dt
        sprite.y = sprite.y + sprite.vy * dt

        if sprite.type == "zombie" then
            updateZombie(sprite, listSprite)
        end
    end
end

function moveHero(dt)
    if love.keyboard.isDown("left") and hero.x > 0 then
        hero.x = hero.x - VAR.speedHero * dt
    end
    if love.keyboard.isDown("right") and hero.x < ScreenWidth then
        hero.x = hero.x + VAR.speedHero * dt
    end
    if love.keyboard.isDown("up") and hero.y > 0 then
        hero.y = hero.y - VAR.speedHero * dt
    end
    if love.keyboard.isDown("down") and hero.y < ScreenHeight then
        hero.y = hero.y + VAR.speedHero * dt
    end
end

function updateZombie(pZombie, pEntities)
    if pZombie.state == ZSTATES.NONE then
        pZombie.state = ZSTATES.CHANGEDIR
    elseif pZombie.state == ZSTATES.WALK then
        --collide with border 
        local bordCollide = false
        if pZombie.x < 0 then
            pZombie.x = 0
            bordCollide = true
        end
        if pZombie.x > ScreenWidth then
            pZombie.x = ScreenWidth
            bordCollide = true
        end
        if pZombie.y < 0 then
            pZombie.y = 0
            bordCollide = true
        end
        if pZombie.y > ScreenHeight then
            pZombie.y = ScreenHeight
            bordCollide = true
        end
        if bordCollide then
            pZombie.state = ZSTATES.CHANGEDIR
        end

        --look for hero 
        for i, sprite in ipairs(pEntities) do
            if sprite.type == "hero" and sprite.visible == true then
                local distance = math.dist(pZombie.x, pZombie.y, sprite.x, sprite.y)
                if distance < pZombie.range then
                    pZombie.state = ZSTATES.ATTACK
                    pZombie.target = sprite
                end
            end
        end

    
    elseif pZombie.state == ZSTATES.ATTACK then
        if pZombie.target == nil then
            pZombie.state = ZSTATES.CHANGEDIR
        elseif math.dist(pZombie.x, pZombie.y, pZombie.target.x, pZombie.target.y) > pZombie.range and pZombie.target.type == "hero" then
            pZombie.state = ZSTATES.CHANGEDIR
        elseif math.dist(pZombie.x, pZombie.y, pZombie.target.x, pZombie.target.y) < 5 and pZombie.target.type == "hero" then
            pZombie.state = ZSTATES.BITE
            pZombie.vx = 0
            pZombie.vy = 0
        else
            --attack
            local destX, destY
            destX = math.random(pZombie.target.x-20, pZombie.target.x+20)
            destY = math.random(pZombie.target.y-20, pZombie.target.y+20)
            local angle = math.angle(pZombie.x, pZombie.y, destX, destY)
            pZombie.vx = pZombie.speed* 2 * 60 * math.cos(angle)
            pZombie.vy = pZombie.speed* 2 * 60 * math.sin(angle)
        end
    elseif pZombie.state == ZSTATES.BITE then
        if math.dist(pZombie.x, pZombie.y, pZombie.target.x, pZombie.target.y) > 5 and pZombie.target.type == "hero" then
            pZombie.state = ZSTATES.ATTACK
        else
            if pZombie.target.hurt ~= nil then
            pZombie.target.hurt()
            end
            if pZombie.target.visible == false then
                pZombie.state = ZSTATES.CHANGEDIR
            end
        end
    elseif pZombie.state == ZSTATES.CHANGEDIR then
        local angle = math.angle(pZombie.x, pZombie.y, math.random(0, ScreenWidth), math.random(0, ScreenHeight))
        pZombie.vx = pZombie.speed * 60 * math.cos(angle)
        pZombie.vy = pZombie.speed * 60 * math.sin(angle)
        pZombie.state = ZSTATES.WALK
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
    love.graphics.print("LIFE:"..tostring(math.floor(hero.life)), 1, 1)
    for i, sprite in ipairs(listSprite) do
        if sprite.visible == true then
            local frame = sprite.img[math.floor(sprite.currentFrame)]
            love.graphics.draw(frame, sprite.x - (sprite.w/2), sprite.y - (sprite.h/2))
            if sprite.type == "zombie" then
                if love.keyboard.isDown("a") then
                    love.graphics.print(sprite.state, sprite.x - 10, sprite.y - sprite.h - 10)
                end
                if sprite.state == ZSTATES.ATTACK then
                    love.graphics.draw(imgAlert, sprite.x - imgAlert:getWidth()/2, sprite.y - sprite.h - 2)
                end
            end
        end
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