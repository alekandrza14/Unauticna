using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InseldeHoume : MonoBehaviour {

	void OnCollisionEnter (Collision other) {
		SceneManager.LoadScene ("test 2");
		
	}
}
