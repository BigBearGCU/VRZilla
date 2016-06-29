using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed=1.0f;
	public float turnSpeed=1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float vertAxis = Input.GetAxis ("Vertical");
		float horiAxis = Input.GetAxis ("Horizontal");

		transform.Translate(transform.forward * (Time.deltaTime*speed*vertAxis));
		transform.RotateAround (transform.position, Vector3.up, turnSpeed * Time.deltaTime * horiAxis);
	}
}
