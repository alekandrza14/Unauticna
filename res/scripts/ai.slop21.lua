-- ============================================================
-- Замок: 15 случайных комнат + 3 башни
-- Движок: MoonSharp + Unity 3D (Unauticna)
-- Файл: C:\data\ai.slop2.lua
-- ============================================================
-- ПРАВИЛА (из главы ошибок):
-- * НЕЛЬЗЯ: local vec3 / local ditem / vec3 = {} / ditem = {}
-- * НЕЛЬЗЯ: return s  (только return vec3 / return ditem)
-- * НЕЛЬЗЯ: vec3[#vec3+1]  (только vec3.Add / RemoveAt / Clear)
-- * Каждые 3 вызова vec3.Add(x) vec3.Add(y) vec3.Add(z) = 1 блок
-- * ditem[i] должен иметь ту же длину, что и vec3/3
-- * Build возвращает vec3, Item возвращает ditem
-- ============================================================

-- Глобальный счётчик блоков (переживает между Build и Item)
blockCount = 0

-- Размеры замка
local ROOM_W = 5          -- ширина комнаты по X
local ROOM_D = 5          -- глубина комнаты по Z
local ROOM_H = 4          -- базовая высота комнаты
local GAP = 1             -- зазор между комнатами
local GRID_X = 5          -- 5 комнат в ряд
local GRID_Z = 3          -- 3 ряда   (5 * 3 = 15)
local CASTLE_W = GRID_X * (ROOM_W + GAP) - GAP   -- 29
local CASTLE_D = GRID_Z * (ROOM_D + GAP) - GAP   -- 17

------------------------------------------------------------
-- Вспомогательные: добавление одного блока и стен
------------------------------------------------------------
local function block(x, y, z)
    vec3.Add(x)
    vec3.Add(y)
    vec3.Add(z)
    blockCount = blockCount + 1
end

-- Стена: прямоугольник из блоков (4 вертикальных ребра + 4 горизонтальных)
local function roomShell(rx, rz, w, d, h)
    -- пол
    for x = rx, rx + w do
        for z = rz, rz + d do
            block(x, 0, z)
        end
    end
    -- потолок
    for x = rx, rx + w do
        for z = rz, rz + d do
            block(x, h, z)
        end
    end
    -- 4 стены
    for y = 1, h - 1 do
        for x = rx, rx + w do
            block(x, y, rz)
            block(x, y, rz + d)
        end
        for z = rz, rz + d do
            block(rx, y, z)
            block(rx + w, y, z)
        end
    end
end

------------------------------------------------------------
function Build(patrn)
    vec3.Clear()
    blockCount = 0

    -- Рандом (разный при каждом patrn)
    math.randomseed(patrn * 7919 + 31)

    --------------------------------------------------------
    -- 15 комнат: сетка GRID_X x GRID_Z со случайной высотой
    --------------------------------------------------------
    for row = 0, GRID_X - 1 do
        for col = 0, GRID_Z - 1 do
            local rx = row * (ROOM_W + GAP)
            local rz = col * (ROOM_D + GAP)

            -- Случайная высота 4..5
            local h = ROOM_H + math.random(0, 1)

            -- Случайно убираем одну стену (дверной проём)
            local open = math.random(0, 3)
            local midX = rx + math.floor(ROOM_W / 2)
            local midZ = rz + math.floor(ROOM_D / 2)

            -- пол
            for x = rx, rx + ROOM_W do
                for z = rz, rz + ROOM_D do
                    block(x, 0, z)
                end
            end
            -- потолок
            for x = rx, rx + ROOM_W do
                for z = rz, rz + ROOM_D do
                    block(x, h, z)
                end
            end
            -- стены (с возможным проёмом на 1 блок в середине)
            for y = 1, h - 1 do
                for x = rx, rx + ROOM_W do
                    if not (open == 0 and y == 1 and x == midX) then
                        block(x, y, rz)
                    end
                    if not (open == 1 and y == 1 and x == midX) then
                        block(x, y, rz + ROOM_D)
                    end
                end
                for z = rz, rz + ROOM_D do
                    if not (open == 2 and y == 1 and z == midZ) then
                        block(rx, y, z)
                    end
                    if not (open == 3 and y == 1 and z == midZ) then
                        block(rx + ROOM_W, y, z)
                    end
                end
            end
        end
    end

    --------------------------------------------------------
    -- 3 башни в углах замка
    --------------------------------------------------------
    local TOWER_W = 3
    local TOWER_H = 12

    local towers = {
        { 0, 0 },                              -- угол (0,0)
        { CASTLE_W - TOWER_W, 0 },             -- угол (X+,0)
        { 0, CASTLE_D - TOWER_W }              -- угол (0,Z+)
    }

    for t = 1, 3 do
        local tx = towers[t][1]
        local tz = towers[t][2]

        -- Полый параллелепипед (только внешние стены)
        for h = 0, TOWER_H do
            for x = tx, tx + TOWER_W do
                for z = tz, tz + TOWER_W do
                    local onEdge =
                        (x == tx) or (x == tx + TOWER_W) or
                        (z == tz) or (z == tz + TOWER_W)
                    if onEdge then
                        block(x, h, z)
                    end
                end
            end
        end

        -- Зубцы на крыше башни
        for x = tx, tx + TOWER_W, 2 do
            for z = tz, tz + TOWER_W, 2 do
                block(x, TOWER_H + 1, z)
            end
        end
    end

    return vec3
end

------------------------------------------------------------
function Item(patrn)
    ditem.Clear()

    -- Каждый блок = камень "пена"
    local i = 1
    while i <= blockCount do
        ditem.Add("пена")
        i = i + 1
    end

    -- Декоративные предметы (по примеру)
    ditem.Add("СветойМаналит(1)")
    ditem.Add("like")
    ditem.Add("like")

    return ditem
end
function Big_constuction (patrn) -- это абсолютно важно игрок не будет в 1 кадр в 4 секунды и унего нет супер научного оборудования перемещаться по этой мегаструктуре!
	stat.Add(true);
	return stat;
end
