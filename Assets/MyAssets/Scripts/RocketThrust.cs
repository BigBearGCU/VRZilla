using UnityEngine;
using System;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class RocketThrust: MonoBehaviour {
	public float thrust;
	public Rigidbody rb;
	public String thrustKey = "space";
	private bool thrustOn = false;

	private bool boost = false;


	SteamVR_TrackedObject trackedObj;

	void Awake()
	{

	}

	void Start() 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		//rb = GetComponent<Rigidbody>();

			

	}

	void FixedUpdate() 
	{

		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Pressed Trigger");
			thrustOn = true;
		} 
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Leggo Trigger");
			thrustOn = false;
		}

		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log ("Pressed Boost" + (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).ToString() ));
			boost = true;
		} 
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			Debug.Log ("Leggo Boost");
			boost = false;
		}


		if (thrustOn) {
			float multiplier = (device.GetAxis (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x);
			Debug.Log ("Thrust " + multiplier);
			rb.AddForce (transform.forward *-1 * (thrust*multiplier));
			device.TriggerHapticPulse(1000);
		}

		if (boost) {

			Debug.Log ("Boost");
		//	rb.AddForce (transform.forward *-1 * thrust*10);
			boost = false;
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

