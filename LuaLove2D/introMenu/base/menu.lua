local gameMenu = {}




gameMenu.load = function()
    Setting.load()
    --- --- ---
end

gameMenu.update = function(dt)
    Setting.update(dt)
    --- --- ---
end

gameMenu.draw = function()
    Setting.draw()
    --- --- ---
end

gameMenu.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

gameMenu.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end



return gameMenu