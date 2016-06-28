using UnityEngine;
using System;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class RocketThrust: MonoBehaviour {
	public float thrust;
	public Rigidbody rb;
	public Transform chest;

	public String thrustKey = "space";
	private bool thrustOn = false;

	private bool boost = false;
	public float thrustDelay = 1f;
	public float thrustDuration = 3f;
	private float thrustDurationRemaining = 3f;
	private float thrustDelayRemaining = 0f;

	private bool chestOn = false;


	SteamVR_TrackedObject trackedObj;

	void Awake()
	{ 

	}

	void Start() 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		//rb = GetComponent<Rigidbody>();

		thrustDurationRemaining = thrustDuration;
		thrustDelayRemaining = 0f;

			

	}

	void FixedUpdate() 
	{
		thrustDelayRemaining -= Time.deltaTime;

		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			thrustOn = true;
		} 
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			thrustOn = false;
		}

		if (device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Touchpad)) {
		//	Debug.Log ("Pressed Boost" + (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).ToString() ));
			boost = true;

			device.TriggerHapticPulse(1);
		} 
			
		if	(device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Touchpad)) {
			boost = false;
		}


		if (thrustOn) {
			float multiplier = (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
			rb.AddForce (transform.forward *-1 * (thrust*multiplier));
			device.TriggerHapticPulse(1000);
		}

		if (boost && thrustDelayRemaining <=0) {
					thrustDurationRemaining-=Time.deltaTime;
			if (thrustDurationRemaining <= 0) {
				thrustDurationRemaining = thrustDuration;
				thrustDelayRemaining = thrustDelay;
			} else
				Debug.Log (thrustDurationRemaining);
			rb.AddForce (transform.forward *-1 * thrust*10);
		}

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Grip)) {
			chestOn = true;
		} 
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Grip)) {
			chestOn = false;
		}
		if (chestOn) {
			rb.AddForce (chest.forward * thrust);
		}




	}

	void Update() {
		//base.UpdateController (); 
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

