---SCREEN : f1: 800x600 / f2: fullScreen / f3: quit / mousepressed(1,2,3): get pos / 
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
        load_full_screen()
    end
    if (key == "f2") then
        SetFullScreen = love.window.setFullscreen(true)
        load_full_screen()
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
--- --- --- --- --- --- --- --- --- --- --- --- --- toto

local mask_shader = love.graphics.newShader[[
   vec4 effect(vec4 color, Image texture, vec2 texture_coords, vec2 screen_coords) {
      if (Texel(texture, texture_coords).rgba == vec4(0.0)) {
         // a discarded pixel wont be applied as the stencil.
         discard;
      }
      return vec4(1.0);
   }
]]

local scaleZoom = 40

local kirk = {}
kirk.isBeam = true
kirk.beamLevel = 1
kirk.maxPercent = 60
kirk.img = nil
kirk.x = 0
kirk.y = 0

local sndTransporter = love.audio.newSource("sons/voyager.wav", "static")

--- --- --- --- --- --- --- --- --- --- --- --- ---

function createKirk()
    kirk.img = love.graphics.newImage("images/kirk.png")
    kirk.x = math.floor(ScreenWidth/2) - math.floor(kirk.img:getWidth()/2)
    kirk.y = math.floor(ScreenHeight/2) - math.floor(kirk.img:getHeight()/2)

    love.audio.play(sndTransporter)
end

love.load = function()
    load_full_screen()
    love.graphics.setBackgroundColor(0,0.9,0.9)
    ScreenWidth = love.graphics.getWidth() / scaleZoom--larg
    ScreenHeight = love.graphics.getHeight() / scaleZoom--haut
    --- --- ---
    createKirk()
end


function updateKirk(dt)
    if kirk.isBeam then
        local coef = 0.4 * 60 * dt
        kirk.beamLevel = kirk.beamLevel + coef

        if kirk.beamLevel >= kirk.maxPercent then
            kirk.isBeam = false
            kirk.beamLevel = 1
        end
        print(kirk.beamLevel)
    end
    --move
    if love.keyboard.isDown("left") then
        kirk.x = kirk.x - 100 * dt
    end
    if love.keyboard.isDown("right") then
        kirk.x = kirk.x + 100 * dt
    end
    if love.keyboard.isDown("up") then
        kirk.y = kirk.y - 100 * dt
    end
    if love.keyboard.isDown("down") then
        kirk.y = kirk.y + 100 * dt
    end
end

love.update = function(dt)
    updateKirk(dt)
end


function myStencilFunction()
    love.graphics.setShader(mask_shader)
    love.graphics.draw(kirk.img, kirk.x, kirk.y)
    love.graphics.setShader()
end

function drawKirk()
    if kirk.isBeam == false then
        love.graphics.draw(kirk.img, kirk.x, kirk.y)
    else
        --kirk en filigramme
        love.graphics.setColor(1,1,1,1*(kirk.beamLevel)/(kirk.maxPercent))
        love.graphics.draw(kirk.img, kirk.x, kirk.y)

        local percent
        if kirk.beamLevel <= kirk.maxPercent / 2 then
            percent = (kirk.beamLevel * 2 ) / 100
        else
            percent = ((kirk.maxPercent - kirk.beamLevel) * 2 ) / 100
        end
        local l,h = kirk.img:getWidth(), kirk.img:getHeight()
        local nbPoint = (l*h) * percent

        love.graphics.stencil(myStencilFunction, "replace", 1)
        love.graphics.setStencilTest("greater", 0)
        love.graphics.setColor(1,0,0,1)
        local np
        for np = 1, nbPoint do
            local rx,ry = math.random(0,l-1), math.random(0,h-1)
            
            love.graphics.rectangle("fill", kirk.x + rx, kirk.y + ry, 1,1)
        end
        love.graphics.setStencilTest()
        love.graphics.setColor(1,1,1)
    end
end

love.draw = function()
    draw_full_screen()
    love.graphics.scale(scaleZoom,scaleZoom)
    --- --- ---
    drawKirk()
end


love.keypressed = function(key)
    keypressed_key(key)
    print(key)
end


love.mousepressed = function()
    mousepressed_get_pos()
end
