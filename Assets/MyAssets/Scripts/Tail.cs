using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour {
	public float tailDistanceXZFromHead = 0.1f;
	public float tailDistanceYFromHead = 0.5f;

	public GameObject tailController = null;
	public GameObject headController = null;

	private void Awake()
	{


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tailController == null || headController == null) {
			return;
		}

		Vector3 direction = tailController.transform.position - headController.transform.position;
		direction.y = 0.0f;
		direction.Normalize ();

		if(direction.sqrMagnitude <= 0.0f)
		{
			return;
		}

		transform.rotation = Quaternion.LookRotation (direction);
		transform.Rotate (new Vector3(90.0f, 0.0f, 0.0f), Space.Self);
		transform.position = headController.transform.position + (direction * tailDistanceXZFromHead) - (Vector3.up * tailDistanceYFromHead);
	}
}
