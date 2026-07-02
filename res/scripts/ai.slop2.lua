-- ============================================================
-- Замок: 15 комнат (5x3) + 3 башни
-- Пол:   "Bedrock"
-- Стены: "пена"
-- Декор: "AppleJuice"
-- Движок: MoonSharp + Unity 3D (Unauticna)
-- Файл:   C:\data\ai.slop2.lua
-- ============================================================
-- ПРАВИЛА (из главы ошибок):
-- * НЕЛЬЗЯ: local vec3 / local ditem / vec3 = {} / ditem = {}
-- * НЕЛЬЗЯ: return s  (только return vec3 / return ditem)
-- * НЕЛЬЗЯ: vec3[#vec3+1]  (только vec3.Add / RemoveAt / Clear)
-- * Каждые 3 вызова vec3.Add(x) vec3.Add(y) vec3.Add(z) = 1 блок
-- * item-длина должна совпадать с длиной vec3/3
-- * Build возвращает vec3, Item возвращает ditem
-- ============================================================

-- Размеры замка (комнаты БОЛЬШЕ)
local ROOM_W = 9          -- ширина комнаты по X  (было 5)
local ROOM_D = 9          -- глубина комнаты по Z  (было 5)
local ROOM_H = 6          -- базовая высота комнаты (было 4)
local GAP    = 2          -- зазор между комнатами (было 1)
local GRID_X = 5          -- 5 комнат по X
local GRID_Z = 3          -- 3 ряда (5*3 = 15)
local CASTLE_W = GRID_X * (ROOM_W + GAP) - GAP
local CASTLE_D = GRID_Z * (ROOM_D + GAP) - GAP

-- Материалы
local MAT_FLOOR   = "Bedrock"
local MAT_WALL    = "пена"
local MAT_DECOR   = "AppleJuice"

-- Внутренний список, чтобы Build и Item были согласованы
itemList = {}

------------------------------------------------------------
-- Добавление одного блока с указанием материала
------------------------------------------------------------
local function block(x, y, z, mat)
    vec3.Add(x)
    vec3.Add(y)
    vec3.Add(z)
    itemList[#itemList + 1] = mat
end

-- Пол + потолок + 4 стены с возможным дверным проёмом
local function walls(rx, rz, w, d, h, open, midX, midZ)
    -- пол (Bedrock)
    for x = rx, rx + w do
        for z = rz, rz + d do
            block(x, 0, z, MAT_FLOOR)
        end
    end
    -- потолок (Bedrock)
    for x = rx, rx + w do
        for z = rz, rz + d do
            block(x, h, z, MAT_FLOOR)
        end
    end
    -- 4 стены (пена)
    for y = 1, h - 1 do
        for x = rx, rx + w do
            if not (open == 0 and y == 1 and x == midX) then
                block(x, y, rz, MAT_WALL)
            end
            if not (open == 1 and y == 1 and x == midX) then
                block(x, y, rz + d, MAT_WALL)
            end
        end
        for z = rz, rz + d do
            if not (open == 2 and y == 1 and z == midZ) then
                block(rx, y, z, MAT_WALL)
            end
            if not (open == 3 and y == 1 and z == midZ) then
                block(rx + w, y, z, MAT_WALL)
            end
        end
    end
end

------------------------------------------------------------
function Build(patrn)
    vec3.Clear()
    itemList = {}

    math.randomseed(patrn * 7919 + 31)

    --------------------------------------------------------
    -- 15 комнат: сетка GRID_X x GRID_Z
    --------------------------------------------------------
    for row = 0, GRID_X - 1 do
        for col = 0, GRID_Z - 1 do
            local rx = row * (ROOM_W + GAP)
            local rz = col * (ROOM_D + GAP)

            local h = ROOM_H + math.random(0, 1)         -- 6..7

            local open = math.random(0, 3)
            local midX = rx + math.floor(ROOM_W / 2)
            local midZ = rz + math.floor(ROOM_D / 2)

            walls(rx, rz, ROOM_W, ROOM_D, h, open, midX, midZ)

            -- сокровища AppleJuice внутри комнаты (1..2 бутылки)
            local decorCount = math.random(1, 2)
            for d = 1, decorCount do
                local dx = rx + 1 + math.random(0, ROOM_W - 2)
                local dz = rz + 1 + math.random(0, ROOM_D - 2)
                block(dx, 1, dz, MAT_DECOR)
            end
        end
    end

    --------------------------------------------------------
    -- 3 башни по углам
    --------------------------------------------------------
    local TOWER_W = 5
    local TOWER_H = 16
    local TOWER_MID = math.floor(TOWER_W / 2)

    local towers = {
        { 0, 0 },
        { CASTLE_W - TOWER_W, 0 },
        { 0, CASTLE_D - TOWER_W }
    }

    for t = 1, 3 do
        local tx = towers[t][1]
        local tz = towers[t][2]

        -- Полый параллелепипед (только внешние грани)
        for h = 0, TOWER_H do
            for x = tx, tx + TOWER_W do
                for z = tz, tz + TOWER_W do
                    local onEdge =
                        (x == tx) or (x == tx + TOWER_W) or
                        (z == tz) or (z == tz + TOWER_W)
                    if onEdge then
                        if h == 0 or h == TOWER_H then
                            block(x, h, z, MAT_FLOOR)   -- пол/крыша башни
                        else
                            block(x, h, z, MAT_WALL)    -- стены
                        end
                    end
                end
            end
        end

        -- Дверной проём (один блок на y=1)
        block(tx + TOWER_MID, 1, tz, MAT_FLOOR)

        -- Зубцы на крыше башни
        for x = tx, tx + TOWER_W, 2 do
            for z = tz, tz + TOWER_W, 2 do
                block(x, TOWER_H + 1, z, MAT_WALL)
            end
        end

        -- Сокровищница наверху — AppleJuice в центре крыши
        block(tx + TOWER_MID, TOWER_H + 1, tz + TOWER_MID, MAT_DECOR)
    end

    return vec3
end

------------------------------------------------------------
function Item(patrn)
    ditem.Clear()

    local i = 1
    while i <= #itemList do
        ditem.Add(itemList[i])
        i = i + 1
    end

    return ditem
end
function Big_constuction (patrn) -- это абсолютно важно игрок не будет в 1 кадр в 4 секунды и унего нет супер научного оборудования перемещаться по этой мегаструктуре!
	stat.Add(true);
	return stat;
end

