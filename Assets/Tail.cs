using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour {

	private void Awake()
	{


	}

	private void CreateTailSegment()
	{
		GameObject segment = new GameObject ();
		segment.transform.name = "Tail" + 0;

		//BMD - for Hamid, commenting this out so I can add to version control
		//segment.AddComponent(new UnityEngine
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
