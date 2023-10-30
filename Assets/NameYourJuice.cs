using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameYourJuice : MonoBehaviour
{ 
    public InputField ifd;
    public itemName itemName;
    // Start is called before the first frame update
    void Start()
    {
        ifd.text = (itemName.ItemData.Replace(' ', 'È')).Replace('\n', 'Ʀ');
    }

    // Update is called once per frame
   public void Return()
    {
        
            itemName.ItemData = (ifd.text.Replace(' ', 'È')).Replace('\n', 'Ʀ');
            Global.PauseManager.Play();
            Destroy(gameObject);
        
    }
}
