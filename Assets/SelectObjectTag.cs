using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class SelectObjectTag : MonoBehaviour
{
	GameObject obj;
	public float speed = 5f;

    public Vector3 Target;
    private bool moving;

    void Start()
    {
        Target = transform.position;
    }
	

   
    public void Select()
	{
		if (obj == null)
        {
            GameObject g = Resources.Load<GameObject>("UnitSelect");
            obj = Instantiate(g, transform);
        }
	}
	public void Deselect()
	{
		Destroy(obj);
	}  
	public void MoveTo(Vector3 pos)
    {
         Target = pos;

       
    }
}
