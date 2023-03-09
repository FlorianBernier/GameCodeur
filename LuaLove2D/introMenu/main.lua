Setting = require("Base/setting")
local start = require("Base/start")

--- --- --- --- --- --- --- --- --- --- --- --- ---

love.load = function()
    Setting.load()
    start.load()
    --- --- ---
end

love.update = function(dt)
    Setting.update(dt)
    start.update(dt)
    --- --- ---
end

love.draw = function()
    Setting.draw()
    start.draw()
    --- --- ---
end

love.keypressed = function(key)
    Setting.keypressed(key)
    start.keypressed(key)
    --- --- ---
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    start.mousepressed()
    --- --- ---
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end