
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	public GameObject mainCamera;

	private int pos;

	// Use this for initialization
	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0.0f, 1.6f, 0.0f );
		mainCamera.transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		pos = 0;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	void FixedUpdate()
	{
		MoveObj ();
		
		if (Input.GetKeyDown (KeyCode.A)) {
			if (pos == 0) {
				ChangeViewMidLeft ();
				pos = -1;
			} else if (pos == 1) {
				ChangeViewRightMid ();
				pos = 0;
			}
		}
		
		if (Input.GetKeyDown (KeyCode.D)) {
			if (pos == 0) {
				ChangeViewMidRight ();
				pos = 1;
			} else if (pos == -1) {
				ChangeViewLeftMid ();
				pos = 0;
			}
		}
	}
	
	
	void MoveObj() {		
		float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate ( 0f, 0f, moveAmount );	
	}



	void ChangeViewMidLeft() {
		//transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( -2.5f, 1.6f, 0.0f );
		//mainCamera.transform.localRotation = Quaternion.Euler (14, 90, 0);
	}

	void ChangeViewMidRight() {
		//transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( 2.5f, 1.6f, 0.0f );
		//		mainCamera.transform.localRotation = Quaternion.Euler ( 19, 180, 0 );
		//		moveSpeed = -20f;	
	}

	void ChangeViewRightMid() {
		//transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( 0.0f, 1.6f, 0.0f );
		//		mainCamera.transform.localRotation = Quaternion.Euler ( 19, 180, 0 );
		//		moveSpeed = -20f;
	}

	void ChangeViewLeftMid() {
		//transform.position = new Vector3 (0, 2, 10);
		// x:0, y:1, z:52
		mainCamera.transform.localPosition = new Vector3 ( 0.0f, 1.6f, 0.0f );
		//		mainCamera.transform.localRotation = Quaternion.Euler ( 19, 180, 0 );
		//		moveSpeed = -20f;
	}
}























