using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand : MonoBehaviour
{
    public debug script;
    Vector2 standartpos;
    // Start is called before the first frame update
    void Start()
    {
        standartpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        int rand2 =Random.Range(0, script.outsv.Count);
        transform.position = new Vector3(script.outsv[rand2].x+ standartpos.x,
            script.outsv[rand2].y + standartpos.y, 0
            );
    }
}
