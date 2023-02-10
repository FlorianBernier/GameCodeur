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
local listSprite = {}
local hero = {}

function createSprite()
    local mySprite = {}
    
    return mySprite
end

love.load = function()
    load_full_screen()
    ScreenWidth = love.graphics.getWidth()--larg(800)
    ScreenHeight = love.graphics.getHeight()--haut(600)

    hero = createSprite()
end

love.update = function(dt)
end

love.draw = function()
    draw_full_screen()
end

love.keypressed = function(key)
    keypressed_key(key)
    print(key)
end

love.mousepressed = function()
    mousepressed_get_pos()
end