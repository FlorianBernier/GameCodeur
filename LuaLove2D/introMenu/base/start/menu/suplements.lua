local menuSuplements = {}

menuSuplements.imageMenu = love.graphics.newImage("image/menu/suplement.png")
menuSuplements.soundMenu = love.audio.newSource("sound/menu/suplement.wav", "stream")

local movieW, movieH = menuSuplements.imageMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH

menuSuplements.load = function()
end

menuSuplements.update = function(dt)
end

menuSuplements.draw = function()
    menuSuplements.soundMenu:play()
    love.graphics.draw(menuSuplements.imageMenu, 0, 0, 0, introX, introY)
end

menuSuplements.keypressed = function(key)
    if key == "escape" then
        menuSuplements.soundMenu:pause()
        menuSuplements.soundMenu:seek(0)
    end
end

menuSuplements.mousepressed = function(x, y, button)
end

return menuSuplements