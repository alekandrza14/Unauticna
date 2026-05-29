using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kill3 : MonoBehaviour {
	private int cou;


	void OnTriggerEnter (Collider ti) {
		if (ti.gameObject.tag == "ten2")
		SceneManager.LoadScene ("test 2");
}
}
