using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRealyty1D : MonoBehaviour
{
    public void Backward()
    {
        VarSave.LoadTrash("RealityX",-1);
    }
    public void Forward()
    {
        VarSave.LoadTrash("RealityX", 1);
    }
}
