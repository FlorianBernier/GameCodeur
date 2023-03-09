local gameIntro = {}

gameIntro.movieIntro = {
    love.graphics.newVideo("movie/intro/soanaraStudio.ogv"),
    love.graphics.newVideo("movie/intro/game.ogv")
}

gameIntro.currentMovie = 1
local movieW, movieH = gameIntro.movieIntro[gameIntro.currentMovie]:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH

gameIntro.load = function()
    gameIntro.movieIntro[gameIntro.currentMovie]:play()
end

gameIntro.update = function(dt)
    if not gameIntro.movieIntro[gameIntro.currentMovie]:isPlaying() then
        if gameIntro.currentMovie < #gameIntro.movieIntro then
            gameIntro.currentMovie = gameIntro.currentMovie + 1
            gameIntro.movieIntro[gameIntro.currentMovie]:play()
            movieW, movieH = gameIntro.movieIntro[gameIntro.currentMovie]:getDimensions()
            introX = 800 / movieW
            introY = 600 / movieH
        end
    end
end

gameIntro.draw = function()
    if gameIntro.movieIntro[gameIntro.currentMovie] then
        love.graphics.draw(gameIntro.movieIntro[gameIntro.currentMovie], 0, 0, 0, introX, introY)
    end
end

gameIntro.keypressed = function(key)
end

gameIntro.mousepressed = function(x, y, button)
end

return gameIntro