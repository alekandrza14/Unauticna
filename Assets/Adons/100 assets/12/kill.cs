using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kill : MonoBehaviour {
	private int count;

	private Text hp;
	public GameObject t;

	void Start () {
		hp = GameObject.Find ("Text").GetComponent <Text> ();
	}

	void OnTriggerEnter (Collider t) {
		count++;
		hp.text = t.gameObject.name + " " + count.ToString ();
		if (t.gameObject.tag == "live")
		if (count == 5)
		SceneManager.LoadScene ("test");
}
}
