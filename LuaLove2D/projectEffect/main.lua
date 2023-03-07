Setting = require("setting")
Intro = require("intro")
--- --- --- --- --- --- --- --- --- --- --- --- ---

love.load = function()
    Setting.load()
    --- --- ---
    Intro.load()
end

love.update = function(dt)
    Setting.update(dt)
    --- --- ---
    Intro.update()
end

love.draw = function()
    Setting.draw()
    --- --- ---
    Intro.draw()
end

love.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
    Intro.keypressed(key)
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end