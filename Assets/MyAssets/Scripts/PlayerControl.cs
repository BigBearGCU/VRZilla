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

		transform.Translate( new Vector3(0.0f,0.0f,Time.deltaTime*speed*vertAxis));
		transform.Rotate (0.0f,turnSpeed * Time.deltaTime * horiAxis,0.0f ,Space.Self);
	}
}
