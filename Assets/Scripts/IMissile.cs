using UnityEngine;
using System.Collections;

/**
 * Basic behaviour for missiles
 * To be extended from child classes
 * */
public class IMissile : IPoolObject {

	/**
	 * damage of missile
	 * */
	public int damage;
	/**
	 * target of missile
	 * */
	public string target;
	
	void FixedUpdate () {
		// if it gets out of screen destroy
		if(GetComponent<Transform>().position.y > 11 
		   || GetComponent<Transform>().position.y < -2)
			Destroy ();
	}

	/**
	 * on collision behaviour
	 * */
	protected virtual void OnTriggerEnter2D(Collider2D c){
	}

}
