using UnityEngine;
using System.Collections;

public class GunnerRotation : MonoBehaviour {

	Transform target;
	public float offset;

	void Start(){
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update () {
		Vector3 moveDirection = target.position - transform.position; 
		if (moveDirection != Vector3.zero) 
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+offset, Vector3.forward);
		}
	}
}
