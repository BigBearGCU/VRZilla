using UnityEngine;
using System.Collections;

public class ZillaAnimationController : MonoBehaviour {

	Animator animator;
	public float animationUpdateRate = 0.5f;
	public float speed;
	public Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		InvokeRepeating("UpdateAnimation", animationUpdateRate,animationUpdateRate);
		lastPosition = transform.position;
	}


	void UpdateAnimation()
	{
		Vector3 diff = transform.position - lastPosition;
		speed = diff.magnitude;
		lastPosition = transform.position;
		animator.SetFloat ("speed", speed);
	}
}
