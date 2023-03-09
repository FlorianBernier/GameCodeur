local gameIntro = {}




gameIntro.load = function()
    Setting.load()
    --- --- ---
end

gameIntro.update = function(dt)
    Setting.update(dt)
    --- --- ---
end

gameIntro.draw = function()
    Setting.draw()
    --- --- ---
end

gameIntro.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

gameIntro.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end



return gameIntro