using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mob : MonoBehaviour {

	void OnCollisionEnter (Collision other) {
		SceneManager.LoadScene ("test");
		
	}
}
