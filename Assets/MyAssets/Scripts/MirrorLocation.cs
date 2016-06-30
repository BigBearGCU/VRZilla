using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MirrorLocation : MonoBehaviour {

	public List<Transform> from;
	public List<Transform> to;
	public GameObject root;

	// Use this for initialization
	void Start () {
		foreach (Transform t in root.transform) {
			from.Add (t);
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (!root)
			return;

		root.transform.position = transform.position;
		root.transform.rotation = transform.rotation;
		///if (from == null) {
		//	return;
		//}

		for (int i = 0; i < from.Count; i++) {
			to[i].transform.position = from[i].transform.position;
			to[i].transform.rotation = from[i].transform.rotation;
		}
		//transform.position = from.transform.position;
		//transform.rotation = from.transform.rotation;
	}
}
