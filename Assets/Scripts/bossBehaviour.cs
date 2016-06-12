using UnityEngine;
using System.Collections;

public class bossBehaviour : MonoBehaviour {

	Vector3 fightLocation = new Vector3(0, 7.5f, 1);

	void Start () {
		StartCoroutine(moveToFight ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator moveToFight(){
		while (transform.position.y-fightLocation.y > 0.1) {
			transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
			yield return null;
		}
		Debug.Log ("running");
	}

}
