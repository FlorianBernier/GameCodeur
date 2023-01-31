

-- variable pad droit
pad2 = {}
pad2.x = 0
pad2.y = 0
pad2.largeur = 20
pad2.hauteur = 80

-- variable du pad gauche
pad = {}
pad.x = 0
pad.y = 0
pad.largeur = 20
pad.hauteur = 80

-- variable de la balle
balle = {}
balle.x = 400
balle.y = 300
balle.largeur = 20
balle.hauteur = 20
balle.vitesse_x = 2
balle.vitesse_y = 2

-- variable de score
score_joueur1 = 0
score_joueur2 = 0

-- trainé de la balle
listeTrail = {}


function CentreBalle()
    balle.x = love.graphics.getWidth()/2 - balle.largeur/2
    balle.y = love.graphics.getHeight()/2 - balle.hauteur/2
    
    balle.vitesse_x = 8
    balle.vitesse_y = 8
end


-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()
    -- place la balle au centre de l'ecrant
    CentreBalle()

    -- placer les pad de gauche et droite 
    pad.x = 0
    pad.y = 0

    pad2.x = love.graphics.getWidth() - pad2.largeur
    pad2.y = love.graphics.getHeight() - pad2.hauteur
end


-----UPDATE----- : ACTION DU JEU ET DU JOUEUR A CHAQUE FRAME / la logique
function love.update(dt)
    -- deplacement du pad gauche
    if love.keyboard.isDown("q") and pad.y + pad.hauteur < love.graphics.getHeight() then
        pad.y = pad.y + 9
    end
    if love.keyboard.isDown("a") and pad.y > 0 then
        pad.y = pad.y -9
    end

    -- deplacement du pad droit
    if love.keyboard.isDown("down") then
        pad2.y = pad2.y +9
    end
    if love.keyboard.isDown("up") then
        pad2.y = pad2.y -9
    end

    -- maTrainee  
    for n=#listeTrail,1,-1 do
        local t = listeTrail[n]
        t.vie = t.vie - dt
        if t.vie <= 0 then
            table.remove(listeTrail, n)
        end
    end

    local maTrainee = {}
    maTrainee.x = balle.x
    maTrainee.y = balle.y
    maTrainee.vie = 0.5
    table.insert(listeTrail, maTrainee)

    -- deplacement de la balle 
    balle.x = balle.x + balle.vitesse_x
    balle.y = balle.y + balle.vitesse_y


    --rebont de la balle sur les mur
    if balle.y > love.graphics.getHeight() - balle.hauteur then
        balle.vitesse_y = -balle.vitesse_y
    end
    if balle.x > love.graphics.getWidth() - balle.largeur then
        --perdu pour le joueur de droit
        CentreBalle()
        score_joueur1 = score_joueur1 + 1
    end
    if balle.y < 0 then
        balle.vitesse_y = -balle.vitesse_y
    end
    if balle.x < 0 then
    -- perdu pour le joueur de gauche
    CentreBalle()
    score_joueur2 = score_joueur2 + 1

    end

    -- la balle a atteint la raquette gauche ? 
    if balle.x <= pad.x + pad.largeur then
        -- tester si la balle est sur la raquette
        -- bord bas balle > bord haut raquette ?
        -- et 
        -- bord haut balle < bord bas raquette
        if balle.y + balle.hauteur > pad.y and balle.y < pad.y + pad.hauteur then
            balle.vitesse_x = -balle.vitesse_x
            balle.x = pad.x + pad.largeur
        end
    end


    -- la balle a atteint la raquette droit ? 
    if balle.x + balle.largeur > pad2.x then
        -- tester si la balle est sur la raquette
        -- bord bas balle > bord haut raquette ?
        -- et 
        -- bord haut balle < bord bas raquette
        if balle.y + balle.hauteur > pad2.y and balle.y < pad2.y + pad2.hauteur then
            balle.vitesse_x = -balle.vitesse_x
        end
    end




    --------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end

-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN / l'affichage 
function love.draw()
    -- dessin des pad gauche et droit
    love.graphics.rectangle("fill", pad.x, pad.y, pad.largeur, pad.hauteur)
    love.graphics.rectangle("fill", pad2.x, pad2.y, pad2.largeur, pad2.hauteur)

    -- dessin de la trainée 
    for n=1,#listeTrail do
        local t = listeTrail[n]
        love.graphics.setColor(1, 1, 1, t.vie/2)
        love.graphics.rectangle("fill", t.x, t.y, balle.largeur, balle.hauteur)
    end

    -- dessin de la balle
    love.graphics.setColor(1, 1, 1, 1) -- dessin de la trainee
    love.graphics.rectangle("fill", balle.x, balle.y, balle.largeur, balle.hauteur)

    -- affichage score 
    local score = score_joueur1.."-"..score_joueur2
    love.graphics.print(score, 400, 0)
end




-----KEYPRESSED----- : ACTION DU JOUEUR
function love.keypressed(key)
    print(key) 
end