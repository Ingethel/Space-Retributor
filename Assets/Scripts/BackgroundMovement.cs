using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	/**
	 * background movment speed
	 * */
	public float speed;
	/**
	 * background size
	 * */
	public float size;

	// initial position
	Vector3 startPos;
	
	void Start () {
		startPos = GetComponent<Transform> ().position;
	}
	
	void Update () {
		// get new offset based on speed and size
		float newPos = Mathf.Repeat (Time.time * speed, size);
		GetComponent<Transform> ().position = startPos + Vector3.down * newPos;
	}
}
