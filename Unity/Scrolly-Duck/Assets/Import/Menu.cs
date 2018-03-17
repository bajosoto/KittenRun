using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Button _Start;
	public Button Quit;
	public Button Help;

	//public Canvas canvas = GetComponentInParent <Canvas>();

	public MovingObjects gameStarting;

	// Use this for initialization
	void Start () {
		_Start.onClick.AddListener (HandleClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleClick(){
		Debug.Log ("Remove Canvas");
		//gameStarting.initializeGame ();
//		Canvas.gameObject.SetActive (false);

	}
}
