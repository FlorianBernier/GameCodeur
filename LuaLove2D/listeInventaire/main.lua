
------VARIABLE------
------TABLEAU------
Inventaire = {}

------FONCTION LOAD------
function AjouteALinventaire(pID, pEtat, pNiveau)
    local obj = {}
    obj.ID = pID
    obj.Etat = pEtat
    obj.Niveau = pNiveau
    table.insert(Inventaire, obj)
end
------FONCTION UPDATE------
------FONCTION KEYPRESSED------
function MonteDeNiveau(pID)
    for k, v in ipairs(Inventaire) do 
        if v.ID == pID then
            v.Niveau = v.Niveau +1
            break
        end
    end
end

------FONCTION MOUSEPRESSED------
------FONCTION UTILE------





-----LOAD----- : ACTION DU JEU AU DEMARAGE
function love.load()
    AjouteALinventaire("EPEE", 100, 1)
    AjouteALinventaire("DAGUE", 100, 1)
    AjouteALinventaire("HACHE", 100, 1)

end


-----UPDATE----- : ACTION DU JEU A CHAQUE FRAME  
function love.update(dt)



    -----------------------------------
    if love.mouse.isDown(1) then
        print(love.mouse.getPosition())
    end
end


-----DRAW----- : DESSINE CE QUE TU VOIS A L'ECRAN
function love.draw()
    local x  = 1
    local y = 1
    for k, v in ipairs(Inventaire) do
        love.graphics.print(v.ID.." ".. v.Niveau, x, y)
        x = x + 100
    end
end



-----KEYPRESSED----- : ACTION DU JOUEUR 
function love.keypressed(key)
    print(key)
    if key == "space" then
       MonteDeNiveau("EPEE")
    end
end