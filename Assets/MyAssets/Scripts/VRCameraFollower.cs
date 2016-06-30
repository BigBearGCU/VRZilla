using UnityEngine;
using System.Collections;

public class VRCameraFollower : MonoBehaviour {

	public Vector3 cameraOffset = Vector3.zero;

	public GameObject VRCameraGO;

	public GameObject neck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!VRCameraGO || !neck)
			return;
		
		Vector3 globalGodzillaPosition = transform.position;
		Vector3 globalNeckPosition = neck.transform.position;

		Vector3 cameraPosition = VRCameraGO.transform.position;


		Vector3 neckDiff = cameraPosition - globalNeckPosition;
		neckDiff.y = 0.0f;
		globalGodzillaPosition += neckDiff;
		transform.position = globalGodzillaPosition;

		float previousYPos = transform.position.y;
		float previousXRot = transform.eulerAngles.x;
		float previousZRot = transform.eulerAngles.z;

		//transform.position = new Vector3(VRCameraGO.transform.position.x + cameraOffset.x, 0.0f, VRCameraGO.transform.position.z + cameraOffset.z);
		transform.eulerAngles  = new Vector3 (previousXRot, VRCameraGO.transform.eulerAngles.y, previousZRot);


		globalNeckPosition = neck.transform.position;
		globalNeckPosition.y = transform.position.y;

		float angle = Vector3.Angle(globalGodzillaPosition - globalNeckPosition, transform.position - globalNeckPosition);
		transform.RotateAround(globalNeckPosition, Vector3.up, angle);

		transform.position += transform.right * cameraOffset.x;
		transform.position += transform.forward * cameraOffset.z;
	}
}
