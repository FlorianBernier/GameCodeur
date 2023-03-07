Intro = {}

local snd = {
    love.graphics.newVideo("movie/soaStudioGame.ogv"),
    love.graphics.newVideo("movie/lordOfSoul.ogv"),
    love.graphics.newVideo("movie/intro.ogv")
}

local currentVideo = 1
local videoWidth, videoHeight = snd[currentVideo]:getDimensions()
local xIntro = 800 / videoWidth
local yIntro = 600 / videoHeight
local isSpacePressed = false


Intro.load = function()
    snd[currentVideo]:play()
end

Intro.update = function(dt)
    if currentVideo == 2 and isSpacePressed == false and snd[currentVideo]:isPlaying() == false then
        return -- ne fait rien si l'accès à la troisième vidéo n'est pas autorisé
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
    if currentVideo == 3 then
        love.graphics.draw(snd[currentVideo], 100, 0, 0, xIntro, yIntro)
    else
        love.graphics.draw(snd[currentVideo], 0, 0, 0, xIntro, yIntro)
    end
end

Intro.keypressed = function(key)
    if key == "space" then
        isSpacePressed = false
        if currentVideo == 2 then
            isSpacePressed = true
            currentVideo = 3
            local videoWidth, videoHeight = snd[currentVideo]:getDimensions()
         xIntro = 600 / videoWidth
         yIntro = 600 / videoHeight
        end

        for i=1,#snd do
            snd[i]:pause()
        end
        snd[currentVideo]:play()
    end
end


return Intro