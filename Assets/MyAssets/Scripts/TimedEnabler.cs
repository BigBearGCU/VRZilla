using UnityEngine;
using System.Collections;

public class TimedEnabler : MonoBehaviour {

	HingeJoint joint;
	// Use this for initialization
	void Start () {
		joint = GetComponent<HingeJoint> ();
		joint.autoConfigureConnectedAnchor = false;
		StartCoroutine (enabledTimed());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator enabledTimed()
	{
		yield return new WaitForSeconds (0.25f);
		joint.autoConfigureConnectedAnchor = true;

	}
}
