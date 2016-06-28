using UnityEngine;
using System;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ChestThrust: MonoBehaviour {
	public float thrust;
	public Rigidbody rb;

	private bool thrustOn = false;


	SteamVR_TrackedObject trackedObj;

	void Awake()
	{ 

	}

	void Start() 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();


	}

	void FixedUpdate() 
	{


		var device = SteamVR_Controller.Input((int)trackedObj.index);

	



	}

	void Update() {
		//base.UpdateController (); 
	}



}


