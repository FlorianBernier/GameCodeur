

local Game = {}


Game.Map = {}
Game.Map.Grid =  {
    {10, 10, 10, 10, 10, 10, 10, 10, 10, 61, 10, 13, 10, 10, 10, 10, 10, 10, 13, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
    {10, 10, 10, 10, 10, 11, 11, 11, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 14, 15, 15, 129, 15, 15, 15, 15, 15, 15, 68, 15, 15},
    {10, 10, 61, 10, 11, 19, 19, 19, 11, 10, 10, 13, 10, 10, 169, 10, 10, 10, 10, 13, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
    {10, 10, 10, 11, 19, 19, 19, 19, 19, 11, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 13, 14, 15, 15, 15, 68, 15, 15, 15, 15, 15, 15},
    {10, 10, 10, 11, 19, 19, 19, 19, 19, 11, 10, 13, 10, 10, 10, 10, 10, 10, 61, 10, 10, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
    {10, 10, 61, 10, 11, 19, 19, 19, 11, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 10, 14, 15, 15, 129, 15, 15, 15, 68, 15, 129, 15},
    {10, 10, 10, 10, 10, 11, 11, 11, 10, 10, 61, 13, 10, 10, 10, 10, 10, 10, 10, 10, 10, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15},
    {10, 10, 10, 10, 10, 13, 13, 13, 13, 13, 13, 13, 10, 10, 10, 10, 10, 169, 10, 10, 10, 13, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15},
    {10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 61, 10, 13, 14, 14, 14, 14, 14, 14, 14, 15, 129},
    {10, 10, 10, 10, 10, 10, 10, 10, 13, 55, 10, 58, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 13, 14, 14},
    {10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 10, 10, 55, 10, 58, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
    {10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 58, 10, 10, 10, 10, 10, 10, 169, 10, 10, 10, 10, 10, 10, 61, 10, 10, 10, 10, 10, 1, 1},
    {10, 10, 10, 10, 10, 10, 10, 10, 13, 10, 10, 10, 58, 10, 10, 10, 10, 10, 10, 10, 10, 61, 10, 10, 10, 10, 10, 10, 10, 1, 37, 37},
    {13, 13, 13, 13, 13, 13, 13, 13, 13, 10, 55, 10, 10, 10, 55, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 37, 37, 37},
    {10, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 55, 10, 10, 10, 10, 169, 10, 10, 10, 10, 10, 10, 10, 10, 1, 37, 37, 37, 37, 37},
    {10, 10, 10, 10, 13, 10, 10, 10, 10, 142, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 37, 37, 37, 37, 37, 37},
    {10, 10, 10, 10, 13, 10, 10, 10, 10, 10, 10, 10, 10, 142, 10, 10, 10, 10, 10, 10, 10, 169, 10, 10, 1, 37, 37, 37, 37, 37, 37, 37},
    {14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 1, 37, 37, 37, 37, 37, 37, 37},
    {14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 1, 37, 37, 37, 37, 37, 37, 37},
    {19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 1, 37, 37, 37, 37, 37, 37, 37},
    {20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 1, 37, 37, 37, 37, 37, 37},
    {21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 1, 37, 37, 37, 37},
    {21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 1, 37, 37, 37}
    }

Game.Map.FogGrid = {}



Game.Map.MAP_WIDTH = 32
Game.Map.MAP_HEIGHT = 23
Game.Map.TILE_WIDTH = 32
Game.Map.TILE_HEIGHT = 32

Game.TileSheet = nil
Game.TileTextures = {}
Game.TileTypes = {}

Game.Hero = require("Hero")

function Game.Map.isSolid(pID)
    local TileTypes = Game.TileTypes[pID]
    if TileTypes == "Sea" or
        TileTypes == "Tree" or
        TileTypes == "Rock" then
        return true
    end

    return false
end

function Game.load()
    print("Game : chargement des textures ...")

    Game.TileSheet = love.graphics.newImage("images/TileSheet.png")
    local nbColumns = Game.TileSheet:getWidth() / Game.Map.TILE_WIDTH
    local nbLines = Game.TileSheet:getHeight() / Game.Map.TILE_HEIGHT

    Game.TileTextures[0] = nil

    local l,c
    local id = 1
    for l = 1, nbLines do
        for c = 1, nbColumns do

            Game.TileTextures[id] = love.graphics.newQuad(
                (c-1)*Game.Map.TILE_WIDTH,
                (l-1)*Game.Map.TILE_HEIGHT,
                Game.Map.TILE_WIDTH,
                Game.Map.TILE_HEIGHT,
                Game.TileSheet:getWidth(),
                Game.TileSheet:getHeight()
                )

            id = id + 1
        end
    end



Game.TileTypes[1] = "Gravel"
Game.TileTypes[10] = "Grass"
Game.TileTypes[11] = "Grass"
Game.TileTypes[13] = "Sand"
Game.TileTypes[14] = "Sand"
Game.TileTypes[15] = "Sand"
Game.TileTypes[19] = "Wather"
Game.TileTypes[20] = "Wather"
Game.TileTypes[21] = "Sea"
Game.TileTypes[37] = "Lava"
Game.TileTypes[55] = "Tree"
Game.TileTypes[58] = "Tree"
Game.TileTypes[61] = "Tree"
Game.TileTypes[68] = "Tree"
Game.TileTypes[129] = "Rock"
Game.TileTypes[169] = "Rock"

print("Game : chargement des textures terminees ...")


print("Creation du brouillard de guerre")
Game.Map.FogGrid = {}
local l,c

    for l = 1, Game.Map.MAP_HEIGHT do
        Game.Map.FogGrid[l] = {}
        for c = 1, Game.Map.MAP_WIDTH do
            Game.Map.FogGrid[l][c] = 1
        end
    end


print("fin de Creation du brouillard de guerre")

Game.Map.ClearFog2(Game.Hero.line, Game.Hero.column)
end

function Game.update(dt)
    Game.Hero.update(Game.Map, dt)
end

function Game.Map.ClearFog(pLine, pCol)
    print("Clear fog!")
    local l,c
    for l = pLine - 1, pLine + 1 do
        for c = pCol - 1, pCol + 1 do
            if c > 0 and c < Game.Map.MAP_WIDTH and l > 0 and l < Game.Map.MAP_HEIGHT then
                Game.Map.FogGrid[l][c] = 0
            end
        end
    end
end

function Game.Map.ClearFog2(pLine, pCol)
    print("Clear fog version 2!")
    local l,c

    for l = 1, Game.Map.MAP_HEIGHT do
        for c = 1, Game.Map.MAP_WIDTH do
            if c > 0 and c < Game.Map.MAP_WIDTH and l > 0 and l < Game.Map.MAP_HEIGHT then
                local dist = math.dist(c, l,pCol, pLine)
                if dist < 4 then
                    Game.Map.FogGrid[l][c] = 0
                end
            end
        end
    end
end


function Game.draw()
    local l,c

    for l = 1, Game.Map.MAP_HEIGHT do
        for c = 1, Game.Map.MAP_WIDTH do
            local id = Game.Map.Grid[l][c]
            local texQuad = Game.TileTextures[id]
            if texQuad ~= nil then
                local x = (c-1)*Game.Map.TILE_WIDTH
                local y = (l-1)*Game.Map.TILE_HEIGHT
                love.graphics.draw(Game.TileSheet, texQuad, x, y)
                if Game.Map.FogGrid[l][c] > 0 then
                    love.graphics.setColor(0,0,0)
                    love.graphics.rectangle("fill", x, y, Game.Map.TILE_WIDTH, Game.Map.TILE_HEIGHT)
                    love.graphics.setColor(255,255,255)
                end

            end
        end
    end

    Game.Hero.draw(Game.Map)

    local x = love.mouse.getX()
    local y = love.mouse.getY()
    local col = math.floor(x / Game.Map.TILE_WIDTH) + 1
    local lig = math.floor(y / Game.Map.TILE_HEIGHT) + 1
    if col > 0 and col <= Game.Map.MAP_WIDTH and lig > 0 and lig <= Game.Map.MAP_HEIGHT then
        local id = Game.Map.Grid[lig][col]
        love.graphics.print("Type de tile:".. tostring(Game.TileTypes[id]).."(".. tostring(id)..")",1,1)
    else
        love.graphics.print("Hors du tableau",1,1)
    end
end

return Game










