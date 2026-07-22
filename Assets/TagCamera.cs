using UnityEngine;

public class TagCamera : MonoBehaviour
{ 
    Metka[] metka;
	Metka[] UpdateTargets()
    {
        return metka = GameObject.FindObjectsByType<Metka>(sortmode.main);
    }
	private void OnGUI()
    {   
		
	    metka = UpdateTargets();
		if (metka.Length != 0)
        {
            for (int i = 0; i < metka.Length; i++)
            {

                if (metka[i] != null)
                {
                    Vector3 t = Camera.main.WorldToViewportPoint(metka[i].transform.position);
                    if (t.z > 0)
                    {
                        Vector3 u = Camera.main.ViewportToScreenPoint(t);
                        GUI.DrawTexture(new Rect(u.x - 10, (Screen.height - u.y) - 10, 20, 20), metka[i].GetComponent<MeshRenderer>().sharedMaterial.GetTexture("_MainTex"));
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 10, (Screen.height / 2) - 10, 20, 20), Resources.Load<Texture>("cursor"));
        }
	}
}
