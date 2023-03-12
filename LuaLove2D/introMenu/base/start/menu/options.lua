local menuOptions = {}

menuOptions.imageMenu = love.graphics.newImage("image/menu/option.png")
menuOptions.soundMenu = love.audio.newSource("sound/menu/option.wav", "stream")

local movieW, movieH = menuOptions.imageMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH

menuOptions.load = function()
end

menuOptions.update = function(dt)
end

menuOptions.draw = function()
    menuOptions.soundMenu:play()
    love.graphics.draw(menuOptions.imageMenu, 0, 0, 0, introX, introY)
end

menuOptions.keypressed = function(key)
    if key == "escape" then
        menuOptions.soundMenu:pause()
        menuOptions.soundMenu:seek(0)
    end
end

menuOptions.mousepressed = function(x, y, button)
end

return menuOptions