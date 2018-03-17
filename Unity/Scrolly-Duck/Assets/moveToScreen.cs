using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToScreen : MonoBehaviour {

	private float speed = 10.0f; 

	// Use this for initialization
	void Start () {
		transform.Translate(0,0,Time.deltaTime * -speed);
	}

	// Update is called once per frame
	void Update () {

		transform.Translate(0,0,Time.deltaTime * -speed);
		if (transform.position.z <= -30.0) {
			Destroy (this.gameObject);
		}
	}
}

