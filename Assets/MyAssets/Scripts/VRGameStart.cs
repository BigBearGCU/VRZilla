using UnityEngine;
using System.Collections;

public class VRGameStart : MonoBehaviour {
	public GameObject character;
	public GameObject VRCamera;

	// Use this for initialization
	void Start () {
		character.SetActive(false);
		character.transform.position = VRCamera.transform.position;
		character.transform.rotation = VRCamera.transform.rotation;
		character.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
