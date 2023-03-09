local gameMenu = {}

gameMenu.movieMenu = love.graphics.newVideo("movie/menu/gameMenu.ogv")
gameMenu.soundMenu = love.audio.newSource("sound/menu/gameMenu.wav", "stream")

gameMenu.btn = {
    {text = "CONTINUER", x=75, y=75, w=200, h=50},
    {text = "NOUVELLE HISTOIRE", x=175, y=175, w=200, h=50},
    {text = "CHAPITRES", x=275, y=275, w=200, h=50},
    {text = "OPTIONS", x=375, y=375, w=200, h=50},
    {text = "SUPPLEMENTS", x=475, y=475, w=200, h=50}
}
local font = love.graphics.newFont(15)

local movieW, movieH = gameMenu.movieMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH
local playVideo = false



gameMenu.load = function()
end

gameMenu.update = function(dt)
end

gameMenu.draw = function()
    if playVideo then
        love.graphics.draw(gameMenu.movieMenu, 0, 0, 0, introX, introY)
    end
    for i, v in ipairs(gameMenu.btn) do
        love.graphics.rectangle("line", v.x, v.y, v.w, v.h)
        love.graphics.setFont(font)
        love.graphics.printf(v.text, v.x, v.y + v.h/2 - font:getHeight()/2, v.w, "center")
    end
end

gameMenu.keypressed = function(key)
    if key == "space" then
        playVideo = true
        gameMenu.movieMenu:play()
        gameMenu.soundMenu:play()
    end
end

gameMenu.mousepressed = function(x, y, button)
end


return gameMenu