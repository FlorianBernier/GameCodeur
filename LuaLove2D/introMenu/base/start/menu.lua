local gameMenu = {}

gameMenu.movieMenu = love.graphics.newVideo("movie/menu/gameMenu.ogv")
gameMenu.soundMenu = love.audio.newSource("sound/menu/gameMenu.wav", "stream")

local movieW, movieH = gameMenu.movieMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH
local playVideo = false



gameMenu.load = function()
end

gameMenu.update = function(dt)
end

gameMenu.draw = function()
    if playVideo then
        love.graphics.draw(gameMenu.movieMenu, 0, 0, 0, introX, introY)
    end
end

gameMenu.keypressed = function(key)
    if key == "space" then
        playVideo = true
        gameMenu.movieMenu:play()
        gameMenu.soundMenu:play()
    end
end

gameMenu.mousepressed = function(x, y, button)
end


return gameMenu