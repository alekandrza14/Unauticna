using UnityEngine;
namespace Unauticna.HyperbolicSpace
{
    // Plain serializable data only. Unity JsonUtility supports background threads for these calls.
    internal sealed class HyperbolicCatalogJson : IHyperbolicCatalogJson
    {
        public string Encode<T>(T value)=>JsonUtility.ToJson(value);
        public T Decode<T>(string text)=>JsonUtility.FromJson<T>(text);
    }
}
