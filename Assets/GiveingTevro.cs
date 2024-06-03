using UnityEngine;

public class GiveingTevro : MonoBehaviour
{
    public void GiveingTevroByNumder(int number)
    {
        Globalprefs.LoadTevroPrise(-number);
    }
}
