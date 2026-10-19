using System.Collections.Generic;
using UnityEngine;

public class HDRP3DModelLoader : MonoBehaviour
{
    public string HDRPMODEL;
    internal static readonly HashSet<HDRP3DModelLoader> Live = new HashSet<HDRP3DModelLoader>();
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetRegistry() { Live.Clear(); }
    void OnEnable() { Live.Add(this); }
    void OnDisable() { Live.Remove(this); }
    void OnDestroy() { Live.Remove(this); }
}
