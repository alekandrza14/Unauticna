using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakingManager : MonoBehaviour
{
    public Scrollbar winCount;
    public Text InostrantsCounter;
    float TakingData;
    string TakingSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TakingSpace = Map_saver.total_lif+SceneManager.GetActiveScene().buildIndex;
        TakingData = VarSave.GetFloat(TakingSpace + "TakingSpace");
        if (VarSave.GetFloat(TakingSpace + "TakingSpace")==0)
        {
            TakingData = FindObjectsByType<CharacterName>(sortmode.main).Length;
            VarSave.SetFloat(TakingSpace + "TakingSpace", TakingData);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (VarSave.GetFloat(TakingSpace + "TakingVin") == 0)
        {
            VarSave.SetFloat(TakingSpace + "TakingSpaceEnemy", FindObjectsByType<CharacterName>(sortmode.main).Length);
            winCount.size = VarSave.GetFloat(TakingSpace + "TakingSpaceEnemy") / TakingData;
            InostrantsCounter.text = "Иностранцы " + VarSave.GetInt(TakingSpace + "TakingSpaceEnemy") + "\\" + TakingData;
            if (VarSave.GetInt(TakingSpace + "TakingSpaceEnemy") == 0) VarSave.SetFloat(TakingSpace + "TakingVin", 1);
        }
        if (VarSave.GetFloat(TakingSpace + "TakingVin") == 1)
        {
            winCount.size = 1;
            InostrantsCounter.text = "Требуеться \"WorkTerritory\"";
            if (FindObjectsByType<WorkTerritory>(sortmode.main).Length >= 1)
            {
                VarSave.SetFloat(TakingSpace + "TakingVin", 2);
            }
        }
        if (VarSave.GetFloat(TakingSpace + "TakingVin") == 2)
        {
            winCount.size = 1; winCount.gameObject.SetActive(false);
            InostrantsCounter.text = "Территория завоёвана";
           
        }
    }
}
