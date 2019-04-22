using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguePersonagem : MonoBehaviour {
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float damping = 1;
	[SerializeField]
	private float lookAheadFactor = 3;
	[SerializeField]
	private float lookAheadReturnSpeed = 0.5f;
	[SerializeField]
	private float lookAheadMoveThreshold = 0.1f;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	
	// Start is called before the first frame update
	void Start() {
	   lastTargetPosition = target.position;
	   offsetZ = (transform.position - target.position).z;
	   transform.parent = null; 
	}

	// Update is called once per frame
	void Update() {
		float xMoveDelta = (target.position - lastTargetPosition).x;

		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);  
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		transform.position = newPos;

		lastTargetPosition = target.position; 
	}
}
