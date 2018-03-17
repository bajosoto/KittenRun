using UnityEngine;
using System.Collections;
using uPLibrary.Networking.M2Mqtt;
using System.Collections.Generic;
using System;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

public class MqttHandler : MonoBehaviour {
	public GameObject go;
	private Rigidbody rb;
	public float step_width;
	public float jump_height;
	public float duck_height;
	public float plank_height;
	private string subscribe_channel;
	private string publish_channel;
	private Dictionary<string,Action> handlers;

	private bool jumpFlag;
	private bool leftFlag;
	private bool rightFlag;

	public void Start () {
		rb = go.GetComponent<Rigidbody> ();
//		step_width = 0.5f;
//		jump_height = 1.0f;
//		duck_height = -0.5f;
//		plank_height = -0.5f;
		subscribe_channel = "pao/controls";
		publish_channel = "vr/status";
		handlers = new Dictionary<string,Action> (); // {
		handlers.Add("jump", jump);
		handlers.Add ("duck", duck);
		handlers.Add ("plank", plank);
		handlers.Add ("left", left);
		handlers.Add ("right", right);

		jumpFlag = false;

//
		Debug.Log("Starting MqttClient"); 
		try{

			MqttClient client = new MqttClient("192.168.0.10");
			client.Connect("vrapp");

			client.MqttMsgPublishReceived += HandleClientMqttMsgPublishReceived;            
			client.Subscribe(new string[]{subscribe_channel}, new byte[]{1});

			client.Publish(publish_channel,Encoding.UTF8.GetBytes("VR is listening.."),1, true);}
		catch(Exception e){
			Debug.Log ("Could not connect");
		}
	}

	void HandleClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
	{
		string msg = System.Text.Encoding.UTF8.GetString(e.Message);
		Debug.Log ("Received message from " + e.Topic + " : " + msg);
		try {
			handlers [msg] ();
		}catch(Exception e1){
			Debug.Log("Unknown Message");
		}

	}

	void jump(){
		Debug.Log("Jump");
		jumpFlag = true;
	}
	void duck(){
		Debug.Log("Duck"); 
		Vector3 movement = new Vector3(0.0f,duck_height,0.0f);
		rb.AddForce(movement);
	}
	void plank(){
		Debug.Log("Plank"); 
		Vector3 movement = new Vector3(0.0f,plank_height,0.0f);
		rb.AddForce(movement);
	}
	void left(){
		Debug.Log("Left"); 
		leftFlag = true;
	}
	void right(){
		Debug.Log("Right"); 
		rightFlag = true;
	}

	// Update is called once per frame
	void Update () {
		if (jumpFlag == true) {
			Vector3 movement = new Vector3 (0.0f, jump_height, 0.0f);
			rb.AddForce (movement);
			jumpFlag = false;
		} else if(leftFlag == true){
			Vector3 movement = new Vector3(-1.0f*step_width,0.0f,0.0f);
			rb.AddForce(movement);
			leftFlag = false;
		} else if(rightFlag == true){
			Vector3 movement = new Vector3(step_width,0.0f,0.0f);
			rb.AddForce(movement);
			rightFlag = false;
		}
	}
}
