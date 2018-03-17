using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingObjects : MonoBehaviour {
	
	const int PLAYER_POSITION = 5; //Absolute position of the player -> used for Destroy objects 
	const int FRAME =25;

	public int y = 0;
	public int x = 0;
	public int z = -2;
	public GameObject Cat;

	public bool flag = false;
	public int cont_frames = 0; //Used to create a new obstacle every 25 frames

	List<GameObject> objects_unicorns = new List<GameObject>(); //Dynamic structure to register obstacles

	// Use this for initialization
	void Start () {
		objects_unicorns.Add (this.createObstacle(x,y,z));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (++cont_frames == FRAME) {
			//It creates a new object every 25 frames
			this.generateRandomObstacles ();
			cont_frames = 0;
		}
		this.moveOstacles();
		//this.killingObstacles();
	}

	GameObject createObstacle (int x, int y, int z){
		GameObject obstacle = Instantiate(Cat,
			                      new Vector3 (x, y, z),
			                      Quaternion.identity) as GameObject;


		//Adding RigidBody component in order to detect collision
		GameObject collisionBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
		BoxCollider obstacleBody = collisionBox.AddComponent<BoxCollider> ();
		collisionBox.transform.position = new Vector3 (x, y, z + 0.2F);
		collisionBox.transform.localScale = new Vector3 (0.1F, 0.1F, 0.1F);
		collisionBox.name = "obstacle";
		objects_unicorns.Add (collisionBox);
		return obstacle;
	}

	void moveOstacles ()
	{
		objects_unicorns.ForEach( el => el.transform.position += Vector3.forward * Time.deltaTime * 4 );
	}

	void killingObstacles(){
		foreach (GameObject el in objects_unicorns) {
			if (el.transform.position.z > PLAYER_POSITION) {
				Debug.Log ("Destroy");
				objects_unicorns.Remove (el);
				Destroy (el);
//				SceneManager.LoadScene ("Starting");
			}
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