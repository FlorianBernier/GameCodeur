local gameMenuPrincipal = {}

gameMenuPrincipal.movieMenu = love.graphics.newVideo("movie/menu/gameMenuPrincipal.ogv")
gameMenuPrincipal.soundMenu = love.audio.newSource("sound/menu/gameMenuPrincipal.wav", "stream")

gameMenuPrincipal.btn = {
    {text = "CONTINUER", x=75, y=75, w=200, h=50},
    {text = "NOUVELLE HISTOIRE", x=175, y=175, w=200, h=50},
    {text = "CHAPITRES", x=275, y=275, w=200, h=50},
    {text = "OPTIONS", x=375, y=375, w=200, h=50},
    {text = "SUPPLEMENTS", x=475, y=475, w=200, h=50}
}
local font = love.graphics.newFont(15)

local movieW, movieH = gameMenuPrincipal.movieMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH
local playVideo = false



gameMenuPrincipal.load = function()
end

gameMenuPrincipal.update = function(dt)
end

gameMenuPrincipal.draw = function()
    if playVideo then
        love.graphics.draw(gameMenuPrincipal.movieMenu, 0, 0, 0, introX, introY)
    end
    for i, v in ipairs(gameMenuPrincipal.btn) do
        love.graphics.rectangle("line", v.x, v.y, v.w, v.h)
        love.graphics.setFont(font)
        love.graphics.printf(v.text, v.x, v.y + v.h/2 - font:getHeight()/2, v.w, "center")
    end
end

gameMenuPrincipal.keypressed = function(key)
    if key == "space" then
        playVideo = true
        gameMenuPrincipal.movieMenu:play()
        gameMenuPrincipal.soundMenu:play()
    end
end

gameMenuPrincipal.mousepressed = function(x, y, button)
end


return gameMenuPrincipal