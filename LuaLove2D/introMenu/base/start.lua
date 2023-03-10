local start = {}

local gameIntro = require("Base/start/intro")
local gameMenu = require("Base/start/menuPrincipal")

start.spacePressed = false

start.load = function()
    gameIntro.load()
    gameMenu.load()
end

start.update = function(dt)
    if not start.spacePressed then
        gameIntro.update(dt)
    else
        gameMenu.update(dt)
    end
end

start.draw = function(f)
    if not start.spacePressed then
        gameIntro.draw()
    else
        gameMenu.draw()
    end
end

start.keypressed = function(key)
    gameMenu.keypressed(key)
    if key == "space" then
        start.spacePressed = true
        gameIntro.movieIntro[gameIntro.currentMovie]:pause()
    end
end

start.mousepressed = function(x, y, button)
    gameMenu.mousepressed(x, y, button)

end

return start