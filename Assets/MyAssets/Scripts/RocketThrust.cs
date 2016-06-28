using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RocketThrust: MonoBehaviour {
	public float thrust;
	public Rigidbody rb;
	public String thrustKey = "space";

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		

		//detectPressedKeyOrButton ();
		if (thrustKey != null) {
			if (Input.GetKey (thrustKey)) {
				Debug.Log ("fire" + thrustKey);
				rb.AddForce (transform.up * thrust);
			}
		}


	}

	public void detectPressedKeyOrButton()
	{
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}
	}

}

