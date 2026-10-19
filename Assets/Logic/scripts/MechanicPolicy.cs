using System;

namespace Unauticna.Mechanics
{
    public enum MechanicMode { Off, On, Auto }
    public enum MechanicId
    {
        Inventory, Needs, AutoEat, Raymarch, RaymarchPick, Sync, CameraSync,
        PolygonSync, TerrainSync, HdrpSync, RemoteInput, Building, Creative,
        Timeline, Economy, WorldEvents, CustomScripts, CustomItems, Markers,
        Strategy, Dimensions, ExternalApps, DebugHud, Count
    }

    // Pure policy: no Unity objects, I/O or scene queries. Shared by the ECS system and tests.
    public static class MechanicPolicy
    {
        public static readonly string[] Names = {
            "inventory", "needs", "autoeat", "raymarch", "raymarch.pick", "sync", "sync.camera",
            "sync.polygons", "sync.terrain", "sync.hdrp", "remote", "building", "creative",
            "timeline", "economy", "events", "scripts", "customitems", "markers",
            "strategy", "dimensions", "externalapps", "debug"
        };
        public static readonly string[] Titles = {
            "Инвентарь", "Потребности", "  Автоматический поиск еды", "Raymarch-рендер", "  Raymarch для предметов", "Второй рендер", "  Камера",
            "  Полигоны", "  Ландшафт", "  HDRP-модели", "Геймпад с телефона", "Строительство", "Творческие инструменты",
            "История / перемотка времени", "Экономика", "Фоновые события", "Пользовательские скрипты", "  Функции CO-предметов", "Метки",
            "Режим стратегии", "Управление W/H/N", "Внешние приложения", "Отладочный HUD"
        };
        public static MechanicMode Default(MechanicId id)
        {
            switch (id)
            {
                case MechanicId.Inventory: case MechanicId.Needs: case MechanicId.AutoEat:
                case MechanicId.CustomItems: case MechanicId.CameraSync: case MechanicId.PolygonSync:
                case MechanicId.TerrainSync: case MechanicId.HdrpSync: case MechanicId.RaymarchPick:
                    return MechanicMode.On;
                case MechanicId.Sync: case MechanicId.RemoteInput: return MechanicMode.Auto;
                default: return MechanicMode.Off;
            }
        }
        public static bool Evaluate(MechanicId id, MechanicMode[] modes, bool renderer, bool hdrp, bool remote)
        {
            if (modes[(int)id] == MechanicMode.Off) return false;
            // Even On requires a receiver. It never writes to a nonexistent renderer.
            switch (id)
            {
                case MechanicId.Sync: return renderer;
                case MechanicId.CameraSync: case MechanicId.PolygonSync: case MechanicId.TerrainSync:
                    return Evaluate(MechanicId.Sync, modes, renderer, hdrp, remote);
                case MechanicId.HdrpSync: return hdrp && Evaluate(MechanicId.Sync, modes, renderer, hdrp, remote);
                case MechanicId.RaymarchPick: return Evaluate(MechanicId.Raymarch, modes, renderer, hdrp, remote);
                case MechanicId.AutoEat:
                    return Evaluate(MechanicId.Needs, modes, renderer, hdrp, remote)
                        && Evaluate(MechanicId.Inventory, modes, renderer, hdrp, remote);
                case MechanicId.CustomItems: return Evaluate(MechanicId.Inventory, modes, renderer, hdrp, remote);
                case MechanicId.RemoteInput: return remote;
                default: return true;
            }
        }
        public static bool TryId(string name, out MechanicId id)
        {
            for (int i = 0; i < Names.Length; i++)
                if (string.Equals(name, Names[i], StringComparison.OrdinalIgnoreCase)) { id = (MechanicId)i; return true; }
            id = default; return false;
        }
    }
}
