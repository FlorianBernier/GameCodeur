local gameMenu = {}

local movieMenu = love.graphics.newVideo("movie/menu/gameMenu.ogv")
local soundMenu = love.audio.newSource("sound/menu/gameMenu.wav", "stream")
local playVideo = false

gameMenu.load = function()
end

gameMenu.update = function(dt)
end

gameMenu.draw = function()
    --if playVideo then
        --love.graphics.draw(movieMenu, 0, 0)
    --end
end

gameMenu.keypressed = function(key)
    if key == "space" then
        playVideo = true
        movieMenu:play()
        soundMenu:play()
    end
end

gameMenu.mousepressed = function(x, y, button)
end


return gameMenu