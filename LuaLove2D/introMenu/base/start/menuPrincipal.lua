local gameMenuPrincipal = {}

local continuer = require("Base/start/menu/continuer")
local nouvelleHistoire = require("Base/start/menu/nouvelleHistoire")
local chapitres = require("Base/start/menu/chapitres")
local options = require("Base/start/menu/options")
local suplements = require("Base/start/menu/suplements")

gameMenuPrincipal.movieMenu = love.graphics.newVideo("movie/menu/gameMenuPrincipal.ogv")
gameMenuPrincipal.soundMenu = love.audio.newSource("sound/menu/gameMenuPrincipal.wav", "stream")
gameMenuPrincipal.on = true
gameMenuPrincipal.play = false

gameMenuPrincipal.btn = {
    {text = "CONTINUER", x=75, y=75, w=200, h=50, on = false},
    {text = "NOUVELLE HISTOIRE", x=175, y=175, w=200, h=50, on = false},
    {text = "CHAPITRES", x=275, y=275, w=200, h=50, on = false},
    {text = "OPTIONS", x=375, y=375, w=200, h=50, on = false},
    {text = "SUPPLEMENTS", x=475, y=475, w=200, h=50, on = false}
}
local font = love.graphics.newFont(15)
local spacePressed = false
local spaceWidth = font:getWidth("")

local movieW, movieH = gameMenuPrincipal.movieMenu:getDimensions()
local introX = 800 / movieW
local introY = 600 / movieH


local function loadBtn()
    for i,button in ipairs(gameMenuPrincipal.btn) do
        button.letters = {}
        for j=1,#button.text do
          table.insert(button.letters, {
            x = math.random(love.graphics.getWidth()),
            y = math.random(love.graphics.getHeight()),
            targetX = button.x + button.w/2 - font:getWidth(button.text)/2 + (j-1)*spaceWidth + font:getWidth(button.text:sub(1,j))-font:getWidth(" ") + (button.text:sub(j,j) == "I" and 2 or 0),
            targetY = button.y + button.h/2 - font:getHeight()/2,
            letter = button.text:sub(j,j),
            speed = math.random(50,100),
            done = false
          })
        end
    end
end

gameMenuPrincipal.load = function()
    loadBtn()
end


local function updateBtn(dt)
    if spacePressed then -- vérifier si la touche "space" a été enfoncée
        for i,button in ipairs(gameMenuPrincipal.btn) do
          for j,letter in ipairs(button.letters) do
            if not letter.done then
              local dx = letter.targetX - letter.x
              local dy = letter.targetY - letter.y
              local distance = math.sqrt(dx*dx + dy*dy)
              local nx = dx/distance
              local ny = dy/distance
              local moveDistance = letter.speed * dt
              if moveDistance > distance then
                letter.x = letter.targetX
                letter.y = letter.targetY
                letter.done = true
              else
                letter.x = letter.x + nx * moveDistance
                letter.y = letter.y + ny * moveDistance
              end
              if letter.letter == "I" then
                letter.x = letter.x + 0.1
                end
            end
          end
        end
      end
  end

gameMenuPrincipal.update = function(dt)
    updateBtn(dt)
end


local function drawMenuPrincipal()
    if gameMenuPrincipal.on == true then
        gameMenuPrincipal.movieMenu:play()
        gameMenuPrincipal.soundMenu:play()

        love.graphics.draw(gameMenuPrincipal.movieMenu, 0, 0, 0, introX, introY)
        for i = 1, #gameMenuPrincipal.btn do
            local v = gameMenuPrincipal.btn[i]
            love.graphics.rectangle("line", v.x, v.y, v.w, v.h)
            love.graphics.setFont(font)
            for j,letter in ipairs(v.letters) do
                if letter.letter == "I" then
                    love.graphics.print(letter.letter, letter.x + 4, letter.y)
                else
                    love.graphics.print(letter.letter, letter.x, letter.y)
                end
            end
        end
    end
    if gameMenuPrincipal.on == false and gameMenuPrincipal.play == false then
        gameMenuPrincipal.play = true
        gameMenuPrincipal.movieMenu:pause()
        gameMenuPrincipal.soundMenu:pause()
    end
end

local function drawMenu()
    for i = 1, #gameMenuPrincipal.btn do
        local v = gameMenuPrincipal.btn[i]
        if v.text == "CONTINUER" and v.on == true then
            continuer.draw()
        elseif v.text == "NOUVELLE HISTOIRE" and v.on == true then
            nouvelleHistoire.draw()
        elseif v.text == "CHAPITRES" and v.on == true then
            chapitres.draw()
        elseif v.text == "OPTIONS" and v.on == true then
            options.draw()
        elseif v.text == "SUPPLEMENTS" and v.on == true then
            suplements.draw()
        end
    end
end


gameMenuPrincipal.draw = function()
    drawMenuPrincipal()
    drawMenu()
end


local function returnMenuPrincipal(key)
    if key == "space" then
        spacePressed = true
    end
    if key == "escape" then
        gameMenuPrincipal.on = true
        gameMenuPrincipal.play = false
        for i = 1, #gameMenuPrincipal.btn do
            local v = gameMenuPrincipal.btn[i]
            v.on = false
        end
    end
end

gameMenuPrincipal.keypressed = function(key)
    returnMenuPrincipal(key)
    continuer.keypressed(key)
    nouvelleHistoire.keypressed(key)
    chapitres.keypressed(key)
    options.keypressed(key)
    suplements.keypressed(key)
end


local function selectMenu(x, y, button)
    for i = button, #gameMenuPrincipal.btn do
        local v = gameMenuPrincipal.btn[i]
        if Mouse_x > v.x and Mouse_x < v.x + v.w and Mouse_y > v.y and Mouse_y < v.y + v.h then
            gameMenuPrincipal.movieMenu:seek(0)
            gameMenuPrincipal.soundMenu:seek(0)
            if v.text == "CONTINUER" then
                gameMenuPrincipal.on = false
                v.on = true
            elseif v.text == "NOUVELLE HISTOIRE" then
                gameMenuPrincipal.on = false
                v.on = true
            elseif v.text == "CHAPITRES" then
                gameMenuPrincipal.on = false
                v.on = true
            elseif v.text == "OPTIONS" then
                gameMenuPrincipal.on = false
                v.on = true
            elseif v.text == "SUPPLEMENTS" then
                gameMenuPrincipal.on = false
                v.on = true
            end
        end
    end
end

gameMenuPrincipal.mousepressed = function(x, y, button)
    selectMenu(x, y, button)
end


return gameMenuPrincipal