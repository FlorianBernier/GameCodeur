

Intro = {}

local movie = {
    love.graphics.newVideo("movie/soaStudioGame.ogv"),
    love.graphics.newVideo("movie/lordOfSoul.ogv"),

    love.graphics.newVideo("menu/start.ogv"),
    love.graphics.newVideo("movie/intro.ogv"),
}

local img = {
    love.graphics.newImage("image/chapitre.png"),
    love.graphics.newImage("image/option.png"),
    love.graphics.newImage("image/suplement.png"),

}

local snd = {
    love.audio.newSource("sound/chapitre.wav", "stream"),
    love.audio.newSource("sound/option.wav", "stream"),
    love.audio.newSource("sound/suplement.wav", "stream")
}

local buttons = {
    {text = "CONTINUER", x=75, y=75, width=200, height=50},
    {text = "NOUVELLE HISTOIRE", x=175, y=175, width=200, height=50},
    {text = "CHAPITRES", x=275, y=275, width=200, height=50},
    {text = "OPTIONS", x=375, y=375, width=200, height=50},
    {text = "SUPPLEMENTS", x=475, y=475, width=200, height=50}
}


local font = love.graphics.newFont(15)
local spacePressed = false

local currentImg = 1
local currentVideo = 1
local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
local xIntro = 800 / videoWidth
local yIntro = 600 / videoHeight
local isSpacePressed = false
local showIntro = false

local function loadBtn()
    for i,button in ipairs(buttons) do
        button.letters = {}
        for j=1,#button.text do
          table.insert(button.letters, {
            x = math.random(love.graphics.getWidth()),
            y = math.random(love.graphics.getHeight()),
            targetX = button.x + button.width/2 - font:getWidth(button.text)/2 + font:getWidth(button.text:sub(1,j))-font:getWidth(" "),
            targetY = button.y + button.height/2 - font:getHeight()/2,
            letter = button.text:sub(j,j),
            speed = math.random(50,100),
            done = false
          })
        end
      end
end

Intro.load = function()
    movie[currentVideo]:play()
    loadBtn()
end


local function updateVideo(dt)
    if currentVideo == 2 and isSpacePressed == false and movie[currentVideo]:isPlaying() == false then
        return
    end
    if currentVideo == 3 and showIntro == false and movie[currentVideo]:isPlaying() == false then
        movie[currentVideo]:seek(0)
        movie[currentVideo]:play()
        return
    end
    if movie[currentVideo]:isPlaying() == false and currentVideo < #movie then
        currentVideo = currentVideo + 1
        videoWidth, videoHeight = movie[currentVideo]:getDimensions()
        xIntro = 800 / videoWidth
        yIntro = 600 / videoHeight

        movie[currentVideo]:play()
        if currentVideo == 2 then
            currentVideo = currentVideo
        end
    end
end



local function updateBtn(dt)
    if spacePressed then -- vérifier si la touche "space" a été enfoncée
        for i,button in ipairs(buttons) do
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
            end
          end
        end
      end
end

Intro.update = function(dt)
    updateVideo(dt)
    updateBtn(dt)
    if currentImg == 1 then
        love.audio.play(snd[1])
    end
    if currentImg == 2 then
        love.audio.play(snd[2])
    end
    if currentImg == 3 then
        love.audio.play(snd[3])
    end
end


local function drawBtn()
    if spacePressed then
        for i,button in ipairs(buttons) do
          love.graphics.setColor(1,1,1)
          love.graphics.rectangle("line", button.x, button.y, button.width, button.height)
          love.graphics.setFont(font)
          for j,letter in ipairs(button.letters) do
            love.graphics.print(letter.letter, letter.x, letter.y)
          end
        end
      end
end

local function drawVideo()
    if currentVideo == 1 then
        love.graphics.draw(movie[currentVideo], 0, 0, 0, xIntro, yIntro)
    end
    if currentVideo == 2 then
        love.graphics.draw(movie[currentVideo], 0, 0, 0, xIntro, yIntro)
    end
    if currentVideo == 3 then
        love.graphics.setColor(0.7,0.7,0.7,1)
        love.graphics.draw(movie[currentVideo], 0, 0, 0, xIntro, yIntro)
        love.graphics.setColor(1,1,1)
        drawBtn()
    end
    if currentVideo == 4 then
        love.graphics.draw(movie[currentVideo], 150, 0, 0, xIntro, yIntro)
    end
    if currentImg == 1 then
        love.graphics.draw(img[currentImg], 0, 0, 0, xIntro, yIntro)
    end
    if currentImg == 2 then
        love.graphics.draw(img[currentImg], 0, 0, 0, xIntro, yIntro)
    end
    if currentImg == 3 then
        love.graphics.draw(img[currentImg], 0, 0, 0, xIntro, yIntro)
    end
    
end

Intro.draw = function()
    drawVideo()
end


local function keypressedSpace(key)
    if key == "space" then
        if currentVideo == 2 then
            isSpacePressed = true
            spacePressed = true
            currentVideo = 3
            local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
            xIntro = 800 / videoWidth
            yIntro = 700 / videoHeight
        elseif currentVideo == 3 then
            showIntro = true
            currentVideo = 4
            local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
            xIntro = 500 / videoWidth
            yIntro = 600 / videoHeight
        end

        for i=1,#movie do
            movie[i]:pause()
        end
        movie[currentVideo]:play()
    end
end

local function keypressedEscape(key)
    if key == "escape" then
        currentVideo = 2
    end
    for i=1,#movie do
        movie[i]:pause()
    end
    for i=1,#snd do
    snd[i]:pause()
    end
end

Intro.keypressed = function(key)
    keypressedSpace(key)
    keypressedEscape(key)
end

function Intro.mousepressed(x, y, button)
    if button == 1 then -- vérifier si le clic est le bouton gauche de la souris
        for i, button in ipairs(buttons) do
            if x >= button.x and x <= button.x + button.width and y >= button.y and y <= button.y + button.height then
                if i == 1 then -- si le bouton cliqué est le premier bouton ("CONTINUER")
                    if currentVideo == 3 then
                        showIntro = true
                        currentVideo = 4
                        local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
                        xIntro = 500 / videoWidth
                        yIntro = 600 / videoHeight
                    end
                end
                if i == 2 then -- si le bouton cliqué est le premier bouton ("CONTINUER")
                    if currentVideo == 3 then
                        showIntro = true
                        currentVideo = 4
                        local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
                        xIntro = 500 / videoWidth
                        yIntro = 600 / videoHeight
                    end
                end

                if i == 3 then -- si le bouton cliqué est le premier bouton ("CONTINUER")
                    if currentVideo == 3 then
                        showIntro = true
                        currentImg = 1
                        local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
                        xIntro = 800 / videoWidth
                        yIntro = 600 / videoHeight
                    end
                end

                if i == 4 then -- si le bouton cliqué est le premier bouton ("CONTINUER")
                    if currentVideo == 3 then
                        showIntro = true
                        currentImg = 2
                        local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
                        xIntro = 800 / videoWidth
                        yIntro = 600 / videoHeight
                    end
                end

                if i == 5 then -- si le bouton cliqué est le premier bouton ("CONTINUER")
                    if currentVideo == 3 then
                        showIntro = true
                        currentImg = 3
                        local videoWidth, videoHeight = movie[currentVideo]:getDimensions()
                        xIntro = 800 / videoWidth
                        yIntro = 600 / videoHeight
                    end
                end

                for i=1,#movie do
                    movie[i]:pause()
                end
                movie[currentVideo]:play()
            end
        end
    end
end


return Intro
