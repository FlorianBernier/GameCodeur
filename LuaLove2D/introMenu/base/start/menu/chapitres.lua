local menuChapitres = {}

menuChapitres.imageMenu = love.graphics.newImage("image/menu/chapitre.png")
menuChapitres.soundMenu = love.audio.newSource("sound/menu/chapitre.wav", "stream")

local movieW, movieH = menuChapitres.imageMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH

menuChapitres.load = function()
end

menuChapitres.update = function(dt)
end

menuChapitres.draw = function()
    menuChapitres.soundMenu:play()
    love.graphics.draw(menuChapitres.imageMenu, 0, 0, 0, introX, introY)
end

menuChapitres.keypressed = function(key)
    if key == "escape" then
        menuChapitres.soundMenu:pause()
        menuChapitres.soundMenu:seek(0)
    end
end

menuChapitres.mousepressed = function(x, y, button)
end

return menuChapitres