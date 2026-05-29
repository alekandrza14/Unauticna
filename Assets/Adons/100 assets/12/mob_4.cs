using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class mob_4 : MonoBehaviour {


	public Transform igrok;
	public int dist;
	public Transform vrag;
	public float speedRotation;
	public float speedMove;





	void Update ()
	{

		if (Vector3.Distance (transform.position, igrok.transform.position) <dist)
		{
			Vector3 Rotation=igrok.position-vrag.position;
			vrag.rotation=Quaternion.Slerp(vrag.rotation,Quaternion.LookRotation(Rotation),speedRotation*Time.deltaTime);
			vrag.transform.position+=vrag.forward*speedMove*Time.deltaTime;
			vrag.transform.localPosition = new Vector3 (transform.position.x, 0.5f, transform.position.z);
		}
	}
}



