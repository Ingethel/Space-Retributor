using UnityEngine;
using System.Collections;

public class GunnerRotation : MonoBehaviour {

	Transform target;
	public float offset;
	public float step;

	[HideInInspector]
	public Vector3 moveDirection;

	void Start(){
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update () {
		moveDirection = target.position - transform.position; 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle+offset, Vector3.forward), step);
		}
	}

	public Vector3 getDirection(){
		return -transform.up;
	}
}
