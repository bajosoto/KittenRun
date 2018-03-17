using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour {

	void OnGUI(){
		if (GUI.Button (new Rect (300, 30, 100, 100), "Start")) {
			SceneManager.LoadScene ("cubes");
		}
		if (GUI.Button (new Rect (300, 200, 100, 100), "Quit")) {
			Application.Quit ();
		}
	}
}
