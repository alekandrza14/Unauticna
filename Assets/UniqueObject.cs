using UnityEngine;

public class UniqueObject : MonoBehaviour
{
    public string tagUnique;
    private void Start()
    {
        UniqueObject[] objs = FindObjectsByType<UniqueObject>(sortmode.main);
        foreach (UniqueObject item in objs)
        {
            if(item.tagUnique == tagUnique)
            {
              if(item.gameObject != gameObject)  Destroy(gameObject); break;
            }
        }
    }
}
