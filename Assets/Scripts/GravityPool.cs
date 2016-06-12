using UnityEngine;
using System.Collections;

/**
 * Applies gravitational forces to targeted objects for basic movement 
 * */
public class GravityPool : MonoBehaviour {

	// list of targets
	GameObject[] target;
	/**
	 * Tag of objects to target
	 * */
	public string target_name;

	GameState gameState;
	Rigidbody2D body;

	void Start (){
		body = GetComponent<Rigidbody2D> ();
		gameState = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameState> ();
	}

	/**
	 * Apply gravitational forces
	 * */
	void FixedUpdate () {
		if (gameState.getState() == 0) {
			target = GameObject.FindGameObjectsWithTag (target_name);
			foreach (GameObject o in target) {
				Vector3 dir = o.transform.position - transform.position;
				float mag = 1/(dir.sqrMagnitude) > 1 ? 1 : 1/(dir.sqrMagnitude);
				body.AddForce (dir * mag);
			}
		}
	}

}
