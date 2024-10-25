using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaManager : MonoBehaviour
{
    public GameObject button;
    public List<GameObject> gadiators = new();
    public int Wave;
    public TextMesh Record;
    public Text Timer;
    public Text MobCounter;
    float timer;
    int oldWave;
    static ArenaManager _main;
    static public ArenaManager main()
    {
        if (_main == null)
        {
            _main = FindFirstObjectByType<ArenaManager>();
        }
        return _main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Wave = 1;
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            RaycastHit hit = MainRay.MainHit;
            if (button == hit.collider.gameObject)
            {
                Wave = 1;
                timer = 0;
            }
        }
        if (oldWave != Wave)
        {
            GladiatorSpawner[] _gadiators = FindObjectsByType<GladiatorSpawner>(sortmode.main);
            foreach (GladiatorSpawner item in _gadiators)
            {
                item.OnWaveSpawn(Wave);
            }
            oldWave = Wave;
        }
        if (Globalprefs.item == "LifeCleaner")
        {
            Wave = 0;
            timer = 0;
        }
        if (FindAnyObjectByType<UMUITank>())
        {
            Wave = 0;
            timer = 0;
        }
        if (mover.DeadGod)
        {
            Wave = 0;
            timer = 0;
        }
        if (Wave != 0)
        {
            mover.main().tutorial = true;
            mover.main().tutorialsave = false;
            timer += Time.deltaTime;
            int hours = (int)(timer / (60 * 60));
            int minetes = (int)(timer / (60));
            float seconds = System.MathF.Round(timer, 2)%60;
            Timer.text = hours + ":" + minetes + ":" + seconds;
            MobCounter.text = "Врагов : "+ gadiators.Count;
            if (gadiators.Count != 0)
            {
                foreach (GameObject item in gadiators) 
                {
                  if(item==null)  gadiators.Remove(item); 
                }
            }
            else
            {
                Wave++;
            }
            if (Wave > 3)
            {
                if (VarSave.GetFloat("arenaTimer")!=0)
                {
                    if (VarSave.GetFloat("arenaTimer") > timer)
                    {
                        VarSave.SetFloat("arenaTimer", timer); 
                        VarSave.SetString("arenaTimerText", hours + ":" + minetes + ":" + seconds);
                    }
                    VarSave.LoadMoney("Avtoritet", 4);
                }
                if (VarSave.GetFloat("arenaTimer") == 0)
                {
                    VarSave.SetFloat("arenaTimer", timer);
                    VarSave.SetString("arenaTimerText", hours + ":" + minetes + ":" + seconds);
                }
                VarSave.LoadMoney("Avtoritet", 1);
                Record.text = "Арена гладиаторская\r\nЛучший рекорд " + VarSave.GetString("arenaTimerText") + "\r\nна арене есть 3 волны\r\nпройдите как можно быстрее";
                timer = 0;
                Wave = 0;
            }
        }
        else
        {
            Record.text = "Арена гладиаторская\r\nЛучший рекорд " + VarSave.GetString("arenaTimerText") + "\r\nна арене есть 3 волны\r\nпройдите как можно быстрее";
            mover.main().tutorial = !true;
            mover.main().tutorialsave = false;
        }
    }
}
