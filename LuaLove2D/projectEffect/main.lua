Setting = require("setting")

--- --- --- --- --- --- --- --- --- --- --- --- ---


love.load = function()
    Setting.load()
    --- --- ---
end

love.update = function(dt)
    Setting.update(dt)
    --- --- ---
end

love.draw = function()
    Setting.draw()
    --- --- ---
end

love.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end