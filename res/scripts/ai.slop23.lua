-- ============================================================
-- Замок: 15 комнат (5x3) + 3 башни + мосты
-- Пол:   "Bedrock"
-- Стены: "пена"
-- Декор: "AppleJuice"
-- Движок: MoonSharp + Unity 3D (Unauticna)
-- Файл:   C:\data\ai.slop2.lua
-- ============================================================
-- Зазоры:  GAP_X = 2  (по X между комнатами)
--         GAP_Z = 3  (по Z между комнатами)
--         Игрок не застревает, мосты перекинуты в зазорах.
-- Дверные проёмы: ШИРОКИЕ И ВЫСОКИЕ (DOOR_W x DOOR_H блоков),
--                 гарантированно есть на каждой внешней стене комнаты
--                 (стыкуются с мостами).
-- ============================================================

-- Размеры комнат
local ROOM_W = 9
local ROOM_D = 9
local ROOM_H = 6
local GAP_X  = 2
local GAP_Z  = 3
local GRID_X = 5
local GRID_Z = 3          -- 5 * 3 = 15

local CASTLE_W = GRID_X * (ROOM_W + GAP_X) - GAP_X
local CASTLE_D = GRID_Z * (ROOM_D + GAP_Z) - GAP_Z

-- Дверной проём (в блоках) — ШИРЕ И ВЫШЕ
local DOOR_W = 2   -- ширина проёма (по стене)
local DOOR_H = 3   -- высота проёма (снизу вверх)

if DOOR_H > ROOM_H - 1 then DOOR_H = ROOM_H - 1 end

-- Материалы
local MAT_FLOOR  = "Bedrock"
local MAT_WALL   = "пена"
local MAT_BRIDGE = "пена"
local MAT_DECOR  = "AppleJuice"

-- Согласованный список материалов
itemList = {}

------------------------------------------------------------
-- Блок: 3 координаты + материал
------------------------------------------------------------
local function block(x, y, z, mat)
    vec3.Add(x)
    vec3.Add(y)
    vec3.Add(z)
    itemList[#itemList + 1] = mat
end

------------------------------------------------------------
-- Пол + потолок + 4 стены.
-- На стенах сразу вырезаны широкие дверные проёмы (DOOR_W x DOOR_H):
--   cutX — на стенах ±X (z = rz / rz+d), центр по midX
--   cutZ — на стенах ±Z (x = rx / rx+w), центр по midZ
------------------------------------------------------------
local function roomShell(rx, rz, w, d, h, cutX, cutZ, midX, midZ)
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

    local dHalf = math.floor(DOOR_W / 2)
    local hMax  = DOOR_H  -- проём идёт по y = 1..DOOR_H

    for y = 1, h - 1 do
        local inDoorY = (y >= 1 and y <= hMax)

        for x = rx, rx + w do
            -- стена -Z (z = rz)
            if not (cutX and inDoorY and (x >= midX - dHalf and x <= midX + dHalf)) then
                block(x, y, rz, MAT_WALL)
            end
            -- стена +Z (z = rz + d)
            if not (cutX and inDoorY and (x >= midX - dHalf and x <= midX + dHalf)) then
                block(x, y, rz + d, MAT_WALL)
            end
        end

        for z = rz, rz + d do
            -- стена -X (x = rx)
            if not (cutZ and inDoorY and (z >= midZ - dHalf and z <= midZ + dHalf)) then
                block(rx, y, z, MAT_WALL)
            end
            -- стена +X (x = rx + w)
            if not (cutZ and inDoorY and (z >= midZ - dHalf and z <= midZ + dHalf)) then
                block(rx + w, y, z, MAT_WALL)
            end
        end
    end
end

------------------------------------------------------------
-- Мост через зазор по X (между колонками)
------------------------------------------------------------
local function bridgeX(rx, rz)
    for x = rx, rx + GAP_X do
        for z = rz, rz + ROOM_D do
            block(x, 1, z, MAT_BRIDGE)
        end
    end
    -- перила
    for x = rx, rx + GAP_X do
        block(x, 2, rz,          MAT_WALL)
        block(x, 2, rz + ROOM_D, MAT_WALL)
    end
end

------------------------------------------------------------
-- Мост через зазор по Z (между строками)
------------------------------------------------------------
local function bridgeZ(rx, rz)
    for x = rx, rx + ROOM_W do
        for z = rz, rz + GAP_Z do
            block(x, 1, z, MAT_BRIDGE)
        end
    end
    -- перила
    for z = rz, rz + GAP_Z do
        block(rx,          2, z, MAT_WALL)
        block(rx + ROOM_W, 2, z, MAT_WALL)
    end
end

------------------------------------------------------------
function Build(patrn)
    vec3.Clear()
    itemList = {}

    math.randomseed(patrn * 7919 + 31)

    --------------------------------------------------------
    -- 15 комнат: сетка GRID_X x GRID_Z
    -- Все 4 стены с проёмами (стыкуются с мостами)
    --------------------------------------------------------
    for row = 0, GRID_X - 1 do
        for col = 0, GRID_Z - 1 do
            local rx = row * (ROOM_W + GAP_X)
            local rz = col * (ROOM_D + GAP_Z)

            local h    = ROOM_H + math.random(0, 1)         -- 6..7
            local midX = rx + math.floor(ROOM_W / 2)
            local midZ = rz + math.floor(ROOM_D / 2)

            local cutX = true
            local cutZ = true

            roomShell(rx, rz, ROOM_W, ROOM_D, h, cutX, cutZ, midX, midZ)

            -- декор: 1..2 бутылки AppleJuice внутри
            local decorCount = math.random(1, 2)
            for d = 1, decorCount do
                local dx = rx + 1 + math.random(0, ROOM_W - 2)
                local dz = rz + 1 + math.random(0, ROOM_D - 2)
                block(dx, 1, dz, MAT_DECOR)
            end
        end
    end

    --------------------------------------------------------
    -- Мосты между комнатами
    --------------------------------------------------------
    for row = 0, GRID_X - 1 do
        for col = 0, GRID_Z - 2 do
            local rx = row * (ROOM_W + GAP_X) + ROOM_W
            local rz = col  * (ROOM_D + GAP_Z)
            bridgeX(rx, rz)
        end
    end

    for row = 0, GRID_X - 2 do
        for col = 0, GRID_Z - 1 do
            local rx = row * (ROOM_W + GAP_X)
            local rz = col * (ROOM_D + GAP_Z) + ROOM_D
            bridgeZ(rx, rz)
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

        -- Полый параллелепипед
        for h = 0, TOWER_H do
            for x = tx, tx + TOWER_W do
                for z = tz, tz + TOWER_W do
                    local onEdge =
                        (x == tx) or (x == tx + TOWER_W) or
                        (z == tz) or (z == tz + TOWER_W)
                    if onEdge then
                        if h == 0 or h == TOWER_H then
                            block(x, h, z, MAT_FLOOR)
                        else
                            block(x, h, z, MAT_WALL)
                        end
                    end
                end
            end
        end

        -- Широкий дверной проём башни (DOOR_W x DOOR_H, центр на TOWER_MID)
        local dHalf = math.floor(DOOR_W / 2)
        for dy = 1, DOOR_H do
            for dx = -dHalf, dHalf do
                block(tx + TOWER_MID + dx, dy, tz, MAT_FLOOR)
            end
        end

        -- Зубцы
        for x = tx, tx + TOWER_W, 2 do
            for z = tz, tz + TOWER_W, 2 do
                block(x, TOWER_H + 1, z, MAT_WALL)
            end
        end

        -- AppleJuice на крыше
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

------------------------------------------------------------
-- Сигнал сборщику: "постройка большая, строй постепенно"
-- Ожидается, что C# зарегистрировал stat = new List<bool>()
--   UserData.RegisterType<List<bool>>();
--   script.Globals["stat"] = stat;
------------------------------------------------------------
function Big_constuction(patrn)
    stat.Add(true)
    return stat
end
