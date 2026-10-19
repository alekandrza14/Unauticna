using FFS.Libraries.StaticEcs;

namespace Unauticna.HyperbolicSpace
{
    public struct SpaceWorldType : IWorldType { }
    public abstract class SpaceWorld : World<SpaceWorldType> { }
    public struct SpaceSystemsType : ISystemsType { }
    public abstract class SpaceSystems : SpaceWorld.Systems<SpaceSystemsType> { }

    public struct StarState : IComponent
    {
        public int Slot;
        public bool Active;
        public StarDescriptor Star;
        public ProjectedStar Projection;
    }

    public struct ApplyStarFrameSystem : ISystem
    {
        // Written and read only on Unity's main thread. Worker results cross this boundary once.
        internal static StarFrame Pending;
        private StarDescriptor[] appliedCatalog;
        public void Update()
        {
            StarFrame frame=Pending;
            if(frame==null)return;
            bool catalogChanged=!object.ReferenceEquals(appliedCatalog,frame.Stars);
            foreach(var entity in SpaceWorld.Query<All<StarState>>().Entities())
            {
                ref var state=ref entity.Ref<StarState>();
                state.Active=state.Slot<frame.Stars.Length;
                if(!state.Active)
                {
                    if(catalogChanged) {state.Star=default;state.Projection=default;}
                    continue;
                }
                // Mega coordinates contain BigInteger references and a large decimal payload.
                // They remain unchanged throughout a cached catalog's lifetime.
                if(catalogChanged)state.Star=frame.Stars[state.Slot];
                state.Projection=frame.Projection[state.Slot];
            }
            appliedCatalog=frame.Stars;
            Pending=null;
        }
    }
}
