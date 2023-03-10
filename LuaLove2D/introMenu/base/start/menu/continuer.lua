local menuContinuer = {}

menuContinuer.movieMenu = love.graphics.newVideo("movie/intro/naratrice.ogv")

local movieW, movieH = menuContinuer.movieMenu:getDimensions()
local introX = 500 / movieW
local introY = 665 / movieH


menuContinuer.load = function()
end

menuContinuer.update = function(dt)
end

menuContinuer.draw = function()
    menuContinuer.movieMenu:play()
    love.graphics.draw(menuContinuer.movieMenu, 150, 0, 0, introX, introY)
end

menuContinuer.keypressed = function(key)
    if key == "escape" then
        menuContinuer.movieMenu:pause()
    end
end

menuContinuer.mousepressed = function(x, y, button)
end

return menuContinuer