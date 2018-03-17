using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

	public GameObject fl_left;
	public GameObject fl_mid;
	public GameObject fl_right;

	private float blockLen;
	private float lastZ;

	private GameObject lastRight = null;

	// Use this for initialization
	void Start () {
		blockLen = 7.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (lastRight != null) {
			lastZ = lastRight.transform.position.z;
//			Debug.Log ("lastZ = " + lastZ);
			if (lastZ <= 30.0f - blockLen) {
//				Instantiate (fl_left, new Vector3 (-1.0f, 0.0f, lastZ + blockLen), Quaternion.identity);
//				Instantiate (fl_mid, new Vector3 (0.0f, 0.0f, lastZ + blockLen), Quaternion.identity);
				lastRight = Instantiate (fl_right, new Vector3 (0.0f, 0.0f, lastZ + blockLen), Quaternion.identity);
			}
		} else {
//			Instantiate(fl_left, new Vector3(-1.0f, 0.0f, 30.0f), Quaternion.identity);
//			Instantiate(fl_mid, new Vector3(0.0f, 0.0f, 30.0f), Quaternion.identity);
			lastRight = Instantiate(fl_right, new Vector3(0.0f, 0.0f, 30.0f), Quaternion.identity);
		}
	}

	void generateRandomObstacles (){
		int lane = Random.Range (1, 4); //In which lane the object will be created
		int type = Random.Range (0, 2); // 0 for a higher obstacle
		switch (lane) {
		case 1:
			x = 3;
			break;
		case 2:
			x = 0;
			break;
		case 3:
			x = -3;
			break;
		}
		GameObject obstacle = createObstacle(x,y,z);
		objects_unicorns.Add (obstacle);
		if (type==0) {
			//It adds the second cube above the just created one
			GameObject obstacle2 = createObstacle(x,y+1,z);
			objects_unicorns.Add (obstacle2);
		}
	}
}
