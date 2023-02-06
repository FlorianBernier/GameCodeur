--Empèche love de filtrer les contours de l'image quand elle est redimensionnées (pixel art)
love.graphics.setDefaultFilter("nearest")
------VARIABLE------

CAMERA_V = 1


------TABLEAU------
heros = {}

math.randomseed(love.timer.getTime())

--liste d'éléments
listeSprites = {}
listeTirs = {}
listeAliens = {}

--niveau 16x12
niveau = {}
table.insert(niveau, { 0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0 })
table.insert(niveau, { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 })
table.insert(niveau, { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 })

-- camera
camera = {}
camera.y = 0

--imgTuiles
imgTuiles = {}
local n
for n = 1, 3 do
    imgTuiles[n] = love.graphics.newImage("images/tuile_"..n..".png")
end


sonShoot = love.audio.newSource("sons/shoot.wav", "static")
sonExplode = love.audio.newSource("sons/explode_touch.wav", "static")

-- createAliens() permet de créé nimporte quel "aliens" du dossier images en appelant juste son nom 
function createAliens(pType, pX, pY)

    local nomImg = ""
    if pType == 1 then
        nomImg = "enemy1"
    elseif pType == 2 then
        nomImg = "enemy2"
    elseif pType == 3 then
        nomImg = "tourelle"
    end

        local alien = createSprite(nomImg, pX, pY)

        alien.type = pType

    alien.sleep = true
    alien.chronotir = 0

    if pType == 1 then
        alien.vy = 2
        alien.vx = 0
        alien.energie = 1
    elseif pType == 2 then
        alien.vy = 2
        local direction = math.random(1,2)
        if direction == 1 then
        alien.vx = 1
        else 
            alien.vx = -1
        end
        alien.energie = 3
    elseif pType == 3 then
        alien.vx = 0
        alien.vy = CAMERA_V
        alien.energie = 5
    end
        table.insert(listeAliens, alien)
end

-- createSprite() permet de créé nimporte quel "sprite" du dossier images en appelant juste son nom 
function createSprite(pNomImg, pX, pY)
    
    sprite = {}
        sprite.x = pX
        sprite.y = pY
        sprite.supr = false
        sprite.img = love.graphics.newImage("images/"..pNomImg..".png")
        sprite.l = sprite.img:getWidth()
        sprite.h = sprite.img:getHeight()

    
    table.insert(listeSprites, sprite)

    return sprite
end
------FONCTION LOAD------

-- startGame() au demagarge du jeu place le hero et crée les aliens
function startGame()
    -- place le hero
    heros.x = larg/2
    heros.y = haut - (heros.h*2)

    -- création des aliens 
    local ligne = 4
    createAliens(1, larg/2, -(64/2)-(64*(ligne-1)))
    ligne = 10
    createAliens(2, larg/2, -(64/2)-(64*(ligne-1)))
    ligne = 11
    createAliens(3, 3*64, -(64/2)-(64*(ligne-1)))

    --remetre a zero la camera
    camera.y = 0

end
------FONCTION UPDATE------
------FONCTION DRAW------
------FONCTION KEYPRESSED------

function creeTir(pType, pNomImg, pX, pY, pVitesseX, pVitesseY)
    local tir = createSprite(pNomImg, pX, pY)
    tir.type = pType
    tir.vx = pVitesseX
    tir.vy = pVitesseY
    table.insert( listeTirs, tir)

    sonShoot:play()
end

------FONCTION MOUSEPRESSED------
------FONCTION UTILE------
function math.angle(x1,y1, x2,y2) return math.atan2(y2-y1, x2-x1) end

-- colision entre 2 sprite avec les meme proprietes
function collide(a1, a2)
    if (a1==a2) then return false end
    local dx = a1.x - a2.x
    local dy = a1.y - a2.y
    if (math.abs(dx) < a1.img:getWidth()*2+a2.img:getWidth()*2) then
     if (math.abs(dy) < a1.img:getHeight()*2+a2.img:getHeight()*2) then
      return true
     end
    end
    return false
   end

-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()
    -- definir taille écrant 
    love.window.setMode(1024, 768)
    -- defenir nom écrant
    love.window.setTitle("Shoot'em Up")

    -- definir larg et haut suivant la taille de l'écrant
    larg = love.graphics.getWidth()
    haut = love.graphics.getHeight()

    -- definir heros pour créé un listeSprites suivant larg et haut
    heros = createSprite("heros", larg/2, haut/2)

    startGame()

end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)

    -- avance la camera
    camera.y = camera.y + CAMERA_V

    local n 

    -- traitement des tirs
    for n = #listeTirs, 1, -1 do
        local tir = listeTirs[n]
        tir.x = tir.x + tir.vx
        tir.y = tir.y + tir.vy

        -- vérifier si on touche le heros
        if tir.type == "alien" then
            if collide(heros, tir) then
                print("boom heros touches")
                tir.supr = true
                table.remove(listeTirs, n)
            end
        end

        -- vérifier si on touche un aliens
        if tir.type == "heros" then
            local nAlien
            for nAlien = #listeAliens, 1, -1 do
                local alien = listeAliens[nAlien]
                if collide(tir, alien) then
                    tir.supr = true
                    table.remove(listeTirs, n)
                    alien.energie = alien.energie -1
                    sonExplode:play()
                    if alien.energie <= 0 then
                        alien.supr = true
                        table.remove(listeAliens, nAlien)
                    end
                end
            end
        end

        -- vérifier si le tir n'est pas sortie de l'écrant
        if tir.y < 0 or tir.y > haut then
            -- marque le sprite pour le suprimer plus tard
            tir.supr = true
            table.remove(listeTirs, n)
        end
    end
    -- traitement des aliens
    for n = #listeAliens, 1, -1 do
        local alien = listeAliens[n]

        if alien.y > 0 then
            alien.sleep = false
        end

        if alien.sleep == false then
        alien.x = alien.x + alien.vx
        alien.y = alien.y + alien.vy
        
        if alien.type == 1 or alien.type == 2 then
            alien.chronotir = alien.chronotir - 1
            if alien.chronotir <= 0 then
                alien.chronotir = math.random(60, 100)
                creeTir("alien", "laser2", alien.x, alien.y, 0, 10)
            end
        elseif alien.type == 3 then
            alien.chronotir = alien.chronotir - 1
            if alien.chronotir <= 0 then
                alien.chronotir = 2
                local vx,vy
                local angle
                angle = math.angle(alien.x, alien.y, heros.x, heros.y)
                vx = 10 * math.cos(angle)
                vy = 10 * math.sin(angle)
                creeTir("alien", "laser2", alien.x, alien.y, vx, vy)
        end

        end
        else
            alien.y = alien.y + CAMERA_V
        end

        if alien.y > haut then
            alien.supr = true
            table.remove(listeAliens, n)
        end
    end




    -- purge des listeSprites à suprimer 
    for n = #listeSprites, 1, -1 do
        if listeSprites[n].supr == true then
            table.remove(listeSprites, n)
        end
    end

    -- définir les touche de deplacement du hero
    if love.keyboard.isDown("right") and heros.x < larg then
        heros.x = heros.x + 4
    end
    if love.keyboard.isDown("left") and heros.x > 0 then
        heros.x = heros.x - 4
    end
    if love.keyboard.isDown("up") and heros.y > 0 then
        heros.y = heros.y - 4
    end
    if love.keyboard.isDown("down") and heros.y < haut then
        heros.y = heros.y + 4
    end


    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end




-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()

    -- dessin du niveau
    local nblignes = #niveau
    local ligne,colonne
    local x,y

    x = 0 
    y = (0 - 64) + camera.y
    for ligne = nblignes, 1, -1 do
        for colonne = 1, 16 do
            -- dessin la tuile
            local tuile = niveau[ligne][colonne]
            if tuile > 0 then
                love.graphics.draw(imgTuiles[tuile], x, y, 0, 2, 2)
            end
            x = x + 64
        end
        x = 0
        y = y - 64
    end


    -- pour chaque listeSprites dans le tableau de listeSprites, on le dessine
    local n
    for n = 1, #listeSprites do
        local s = listeSprites[n]
        love.graphics.draw(s.img, s.x, s.y, 0, 2, 2, s.l/2, s.h/2)
    end
    -- afficher le nombre de listeTirs et le nombre de listeSprites actuel à l'écrant
    love.graphics.print("Nombre de listeTirs : "..#listeTirs.." Nombre de listeSprites : "..#listeSprites.." Nombre d'aliens : "..#listeAliens, 0, 0)

end

-----KEYPRESSED----- : ACTION DU JOUEUR CLAVIER
function love.keypressed(key)
   
    -- définir la touche de tir du hero
    if key == "space" then
        creeTir("heros", "laser1", heros.x, heros.y - (heros.h*2)/2, 0, -10)
    end

    print(key)
end

-----MOUSEPRESSED----- : ACTION DU JOUEUR SOURIS
function love.mousepressed()
end
