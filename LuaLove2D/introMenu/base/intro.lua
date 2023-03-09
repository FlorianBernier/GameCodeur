local gameIntro = {}

local movieIntro = {
    love.graphics.newVideo("movie/intro/soanaraStudio.ogv"),
    love.graphics.newVideo("movie/intro/game.ogv")
}

local currentMovie = 1
local movieW, movieH = movieIntro[currentMovie]:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH
local spacePressed = false

gameIntro.load = function()
    movieIntro[currentMovie]:play()
end

gameIntro.update = function(dt)
    if not movieIntro[currentMovie]:isPlaying() then
        if currentMovie < #movieIntro then
            currentMovie = currentMovie + 1
            movieIntro[currentMovie]:play()
            movieW, movieH = movieIntro[currentMovie]:getDimensions()
            introX = 800 / movieW
            introY = 600 / movieH
        else
            if spacePressed then
                movieIntro[currentMovie]:pause()
            end
        end
    end
end

gameIntro.draw = function()
    if movieIntro[currentMovie] and not spacePressed then
        love.graphics.draw(movieIntro[currentMovie], 0, 0, 0, introX, introY)
    end
end

gameIntro.keypressed = function(key)
    if key == "space" then
        spacePressed  = true
    end
end

gameIntro.mousepressed = function(x, y, button)
end

return gameIntro