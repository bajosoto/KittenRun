using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "obstacle") {
			Debug.Log ("Collision detected"); 
			TextMesh textM = GameObject.Find ("GameOverText").GetComponent<TextMesh> ();
			textM.text = "Game Over!";
		}
	}
}
