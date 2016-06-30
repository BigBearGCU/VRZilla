using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AngularVelocity : MonoBehaviour {

	private Rigidbody rigidBody;

	private Vector3 previousForward;
	private Vector3 currentForward;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		previousForward = currentForward;
		currentForward = transform.forward;

		Vector3 distance = currentForward - previousForward;
		//rigidBody.angularVelocity = distance * (1.0f / Time.fixedTime);

		//Debug.Log(rigidBody.angularVelocity);
	}
}
