Setting = require("base/setting")
local gameIntro = require("base/intro")
local gameMenu = require("base/menu")

--- --- --- --- --- --- --- --- --- --- --- --- ---

love.load = function()
    Setting.load()
    gameIntro.load()
    gameMenu.load()
    --- --- ---
end

love.update = function(dt)
    Setting.update(dt)
    gameIntro.update(dt)
    gameMenu.update(dt)
    --- --- ---
end

love.draw = function()
    Setting.draw()
    gameIntro.draw()
    gameMenu.draw()
    --- --- ---
end

love.keypressed = function(key)
    Setting.keypressed(key)
    gameIntro.keypressed(key)
    gameMenu.keypressed(key)
    --- --- ---
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    gameIntro.mousepressed()
    gameMenu.mousepressed()
    --- --- ---
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end