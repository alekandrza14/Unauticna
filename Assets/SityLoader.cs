using Photon.Realtime;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SityLoader : MonoBehaviour
{
    public GameObject CO;
    public SityJson sity = new SityJson();
    public InputField sityname;
    public void Load()
    {
        if (File.Exists(("res/UserWorckspace/Sitys/" + sityname.text + ".json")))
        {
            sity = JsonUtility.FromJson<SityJson>(File.ReadAllText(("res/UserWorckspace/Sitys/" + sityname.text + ".json")));
            int i = 0;
            foreach (string item in sity.Home)
            {
                Ray r = new Ray((mover.main().transform.right*(sity.Pos[i].x))
                    + (mover.main().transform.up * (sity.Pos[i].y))
                    + (mover.main().transform.forward *( sity.Pos[i].z))
                    + (mover.main().transform.up*1000) + mover.main().transform.position, -mover.main().transform.up);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        CustomObject c = Instantiate(CO, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity).GetComponent<CustomObject>();
                        c.s = item;
                        i++;
                    }
                }
            }
        }
        //  File.WriteAllText("res/UserWorckspace/Sitys/" + "uniqsity.json", JsonUtility.ToJson(sity));
    }
}
