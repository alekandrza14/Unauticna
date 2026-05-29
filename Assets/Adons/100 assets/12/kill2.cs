using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kill2 : MonoBehaviour {

	void OnTriggerEnter (Collider ti) {
		if (ti.gameObject.tag == "ten")
		SceneManager.LoadScene ("test 3");
		}
}
