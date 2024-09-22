using UnityEngine;

public class LuckGive : MonoBehaviour
{
    public void PlayerLuckGive()
    {
        VarSave.LoadFloat("luck", 10);
    }
}
