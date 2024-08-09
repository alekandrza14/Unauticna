using UnityEngine;

public class TryBar : MonoBehaviour
{
    public GameObject Bar;
    public GameObject Again;
    void Update()
    {
        Bar.SetActive(Globalprefs.TryBar);
        Again.SetActive(VarSave.GetFloat(
          "встал_и_пошол" + "_gameSettings", SaveType.global) < 1.0f);
    }
    public void TryAgain()
    {
        mover.main().death();
    }
    public void TryNow()
    {
        mover.main().hp = 900;
        Globalprefs.TryBar = false;
    }
}
