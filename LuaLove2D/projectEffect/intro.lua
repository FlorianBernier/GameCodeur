Intro = {}

local snd = {
    love.graphics.newVideo("movie/soaStudioGame.ogv"),
    love.graphics.newVideo("movie/lordOfSoul.ogv"),

    love.graphics.newVideo("menu/start.ogv"),
    love.graphics.newVideo("movie/intro.ogv"),
}


local play = love.graphics.newImage("image/test1.png")
local test = love.graphics.newVideo("movie/test.ogv")

local currentVideo = 1
local videoWidth, videoHeight = snd[currentVideo]:getDimensions()
local xIntro = 800 / videoWidth
local yIntro = 600 / videoHeight
local isSpacePressed = false
local showIntro = false


Intro.load = function()
    snd[currentVideo]:play()
    test:play()
end

Intro.update = function(dt)
    if currentVideo == 2 and isSpacePressed == false and snd[currentVideo]:isPlaying() == false then
        return
    end
    if currentVideo == 3 and showIntro == false and snd[currentVideo]:isPlaying() == false then
        snd[currentVideo]:seek(0)
        snd[currentVideo]:play()
        return
    end
    if snd[currentVideo]:isPlaying() == false and currentVideo < #snd then
        currentVideo = currentVideo + 1
        videoWidth, videoHeight = snd[currentVideo]:getDimensions()
        xIntro = 800 / videoWidth
        yIntro = 600 / videoHeight

        snd[currentVideo]:play()
        if currentVideo == 2 then
            currentVideo = currentVideo
        end
    end
end

Intro.draw = function()
    if currentVideo == 1 then
        love.graphics.draw(snd[currentVideo], 0, 0, 0, xIntro, yIntro)
    end
    if currentVideo == 2 then
        love.graphics.draw(snd[currentVideo], 0, 0, 0, xIntro, yIntro)
    end
    if currentVideo == 4 then
        love.graphics.draw(snd[currentVideo], 150, 0, 0, xIntro, yIntro)
    end
    if currentVideo == 3 then
        love.graphics.setColor(0.7,0.7,0.7,1)
        love.graphics.draw(snd[currentVideo], 0, 0, 0, xIntro, yIntro)
        love.graphics.setColor(1,1,1)
        love.graphics.draw(play, 0, 500)
    end
    love.graphics.draw(test, 0, 0, 0, 0.5, 0.5)
end

Intro.keypressed = function(key)
    if key == "space" then
        if currentVideo == 2 then
            isSpacePressed = true
            currentVideo = 3
            local videoWidth, videoHeight = snd[currentVideo]:getDimensions()
            xIntro = 800 / videoWidth
            yIntro = 700 / videoHeight
        elseif currentVideo == 3 then
            showIntro = true
            currentVideo = 4
            local videoWidth, videoHeight = snd[currentVideo]:getDimensions()
            xIntro = 500 / videoWidth
            yIntro = 600 / videoHeight
        end

        for i=1,#snd do
            snd[i]:pause()
        end
        snd[currentVideo]:play()
    end
end


return Intro