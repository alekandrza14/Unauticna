using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNoItems : MonoBehaviour
{
    [SerializeField] string position;
    // Start is called before the first frame update
    void Update()
    {
      
        if (!boxItem.getInventory("i3").inventory.Getitem(position))
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator get()
    {
        
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(0.5f);
        if (!boxItem.getInventory("i3").inventory.Getitem(position))
        {
            Destroy(gameObject);
        }

    }
}
