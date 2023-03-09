local intro = {}

intro.load = function()
    Setting.load()
    --- --- ---
end

intro.update = function(dt)
    Setting.update(dt)
    --- --- ---
end

intro.draw = function()
    Setting.draw()
    --- --- ---
end

intro.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

intro.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end











return intro