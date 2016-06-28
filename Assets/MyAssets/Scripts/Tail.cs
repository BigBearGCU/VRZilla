using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tail : MonoBehaviour {
	public float tailDistanceXZFromHead = 0.1f;
	public float tailDistanceYFromHead = 0.5f;

	public GameObject tailController = null;
	public GameObject headController = null;

	public float jointlimitY = 30;
	public float jointlimitXMin=0;
	public float jointlimitXMax=30;
	public float jointLimitXMaxInit=5;
	public float jointLimitStepValue = 5;

	public ConfigurableJoint[] joints;
	public List<Rigidbody> rigidBodies = new List<Rigidbody> (); 

	private void Awake()
	{

	}

	// Use this for initialization
	void Start () {

		//rigidBodies.Add (GetComponent<Rigidbody> ());
		rigidBodies.AddRange (GetComponentsInChildren<Rigidbody> ());

		joints=GetComponentsInChildren<ConfigurableJoint> ();
		float currentJointLimit = jointLimitXMaxInit;
		SoftJointLimit currentSoftJointLimit=new SoftJointLimit();
		ConfigurableJoint j;
		for(int i=0;i<joints.Length;++i)
		{
			j = joints [i];
			j.connectedBody = rigidBodies [i];
			//Y Limit
			currentSoftJointLimit=j.angularYLimit;
			currentSoftJointLimit.limit = jointlimitY;
			j.angularYLimit=currentSoftJointLimit;


			//currentSoftJointLimit=j.lowAngularXLimit;
			//currentSoftJointLimit.limit = jointlimitXMin;
			//j.lowAngularXLimit=currentSoftJointLimit;


			currentSoftJointLimit = j.angularZLimit;
			currentSoftJointLimit.limit = Mathf.Max (currentJointLimit, jointlimitXMax);
			j.angularZLimit=currentSoftJointLimit;
			jointlimitXMax = i * jointLimitStepValue;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
