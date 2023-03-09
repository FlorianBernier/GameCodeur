Setting = require("setting")
local sim = {
  size = 800,
  x = 600,
  y = 100,
  nbIndividus = 500,
  nbInfected = 1,
  rad = 1,
  speed = 50,
  infectedRad = 6,
  infectedTime = 5

}
local listIndividus = {}

function createIndividu(px, py, pState)
  local ind = {
      x = px,
      y = py,
      vx = 0,
      vy = 0,
      state = pState,
      iRad = 0,
      iTime = 0
  }
  ind.vx = math.random(0-sim.speed, sim.speed) 
  ind.vy = (sim.speed - math.abs(ind.vx))
  if (math.floor(math.random(2)%2) == 0)then 
      ind.vy = 0 - ind.vy
  end
  table.insert(listIndividus,ind)
end


function love.load()
    Setting.load()
  for i = 0,sim.nbInfected do
      createIndividu( 
          math.random(sim.x + sim.rad, sim.x + sim.size - sim.rad), 
          math.random(sim.y + sim.rad, sim.y + sim.size - sim.rad),
          "i" -- Safe
      )
  end

  for i = 0,sim.nbIndividus - sim.nbInfected do
      createIndividu( 
          math.random(sim.x + sim.rad, sim.x + sim.size - sim.rad), 
          math.random(sim.y + sim.rad, sim.y + sim.size - sim.rad),
          "s" -- Safe
      )
  end

end

function love.draw()
    Setting.draw()
  drawGraph()
  love.graphics.rectangle("line", sim.x, sim.y, sim.size, sim.size )

  for i = #listIndividus, 1, -1 do
      local ind = listIndividus[i]
      if (ind.state == "s") then love.graphics.setColor(1,1,1) 
      elseif (ind.state == "i") then 
          love.graphics.setColor(1,0,0)
          love.graphics.circle("line", ind.x, ind.y, ind.iRad) 
      elseif (ind.state == "r") then love.graphics.setColor(0.4,0.4,0.4) end

      love.graphics.circle("fill",ind.x, ind.y, sim.rad)
  end
  love.graphics.setColor(1,1,1)
end

function love.update(dt)
    Setting.update(dt)
  graphique(dt)
  for i = #listIndividus, 1, -1 do
      local ind = listIndividus[i]


      if (ind.state == "i") then
          isInfected(dt, ind)
      end

      local old_x = ind.x
      local old_y = ind.y
      ind.x = ind.x + ind.vx * dt
      ind.y = ind.y + ind.vy * dt
      collide(ind, old_x, old_y)
  end
end




function isInfected(dt, ind)
  -- Affichage de son rayon d'infection
  ind.iRad = ind.iRad + sim.infectedRad * dt
  if (ind.iRad >= sim.infectedRad) then
      ind.iRad = 0
  end

  -- Temp resté infecté
  ind.iTime = ind.iTime + 1 * dt
  if (ind.iTime > sim.infectedTime)then
      ind.state = "r"
  end

  --print(ind.iTime)

  -- Contamination de nouveau individus
  for i = #listIndividus, 1, -1 do
      local sus = listIndividus[i]
      
      if (dist(ind.x, ind.y, sus.x, sus.y) < sim.infectedRad  and sus.state == "s" ) then
          sus.state = "i"
      end

  end


end

function collide(ind, old_x, old_y)
  if (ind.x - sim.rad < sim.x)then 
      ind.vx  = 0 - ind.vx
      ind.x = old_x
      ind.y = old_y
  end
  if (ind.y - sim.rad < sim.y)then 
      ind.vy  = 0 - ind.vy
      ind.x = old_x
      ind.y = old_y
  end
  if (ind.x + sim.rad > sim.size + sim.x)then 
      ind.vx  = 0 - ind.vx
      ind.x = old_x
      ind.y = old_y
  end
  if (ind.y + sim.rad > sim.size + sim.y)then 
      ind.vy  = 0 - ind.vy
      ind.x = old_x
      ind.y = old_y
  end
end

function dist(x1, y1, x2, y2) 
  return math.sqrt( (x1-x2)*(x1-x2) +  (y1-y2)*(y1-y2))
end


local graphicsList= {}
local time = 0
function graphique(dt)
  time = time + 2 * dt
  if (time > 1) then
      time = 0
      local saf = 0
      local inf = 0
      local ret = 0
      
      for i = 1,#listIndividus do
          local ind = listIndividus[i]


          if ind.state == "s" then
              saf = saf + 1
          elseif ind.state == "i" then
              inf = inf + 1
          elseif ind.state == "r" then
              ret = ret + 1
          end
      end
      table.insert(graphicsList, {inf = inf, saf = saf, ret = ret })
  end
end

function drawGraph()
  
  for i = 1, #graphicsList do
      local data = graphicsList[i]

      local pcSaf = (data.saf / sim.nbIndividus) * 100
      local pcInf = (data.inf / sim.nbIndividus) * 100
      local pcRet = (data.ret / sim.nbIndividus) * 100

      love.graphics.rectangle("fill", 100 + i*3, 100, 3, pcSaf *2 )
      love.graphics.setColor(1,0,0)
      love.graphics.rectangle("fill", 100 + i*3, 100+ pcSaf *2, 3,pcInf *2  )
      love.graphics.setColor(0.4,0.4,0.4)
      love.graphics.rectangle("fill", 100 + i*3, 100+ pcSaf *2 + pcInf *2, 3, pcRet * 2 )
      love.graphics.setColor(1,1,1)
  end
  
end

love.keypressed = function(key)
    Setting.keypressed(key)
    --- --- ---
end

love.mousepressed = function(x, y, button)
    Setting.mousepressed()
    --- --- ---
end


function love.wheelmoved(x, y)
    Setting.wheelmoved(x,y)
    --- --- ---
end