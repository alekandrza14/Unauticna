using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kill1 : MonoBehaviour {
	private int count2;
	private mob_4 yo;
	private Text hp2;
	public GameObject t2;
	Animator anim;

	void Start () {
		anim = GetComponent <Animator> ();
		yo = GetComponent <mob_4> ();
		hp2 = GameObject.Find ("Text2").GetComponent <Text> ();
	}

	void OnMouseDown () {
		count2++;
		hp2.text = t2.gameObject.name + " " + count2.ToString ();
		if (t2.gameObject.tag == "kill")
		if (count2 >= 7)
			Destroy (t2);
		if (count2 >= 4)
		if (count2 <= 5){
			yo.enabled = !yo.enabled;
		}	
		if (count2 >= 4) 
		if (count2 <= 5) {
			anim.SetInteger ("kill",1);
		}
}
}
