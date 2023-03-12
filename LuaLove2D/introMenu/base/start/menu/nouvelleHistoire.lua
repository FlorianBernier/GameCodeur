local menuNouvelleHistoire = {}

menuNouvelleHistoire.imageMenu = love.graphics.newImage("image/menu/nouvelleHistoire.png")
menuNouvelleHistoire.soundMenu = love.audio.newSource("sound/menu/nouvelleHistoire.wav", "stream")

local movieW, movieH = menuNouvelleHistoire.imageMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH

menuNouvelleHistoire.load = function()
end

menuNouvelleHistoire.update = function(dt)
end

menuNouvelleHistoire.draw = function()
    menuNouvelleHistoire.soundMenu:play()
    love.graphics.draw(menuNouvelleHistoire.imageMenu, 0, 0, 0, introX, introY)
end

menuNouvelleHistoire.keypressed = function(key)
    if key == "escape" then
        menuNouvelleHistoire.soundMenu:pause()
        menuNouvelleHistoire.soundMenu:seek(0)
    end
end

menuNouvelleHistoire.mousepressed = function(x, y, button)
end

return menuNouvelleHistoire