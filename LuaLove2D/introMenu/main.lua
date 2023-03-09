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
    love.graphics.rectangle("fill", 100+Camera_x,100+Camera_y,100,100)
end

love.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
    if button == 1 then -- vérifier si le clic est le clic gauche de la souris
        local square_x = 100
        local square_y = 100
        local square_size = 100
        if Mouse_x >= square_x and Mouse_x <= square_x + square_size and Mouse_y >= square_y and Mouse_y <= square_y + square_size then
            print("Le carré a été cliqué !")
        end
    end
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end