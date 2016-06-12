using UnityEngine;
using System.Collections;

/**
 * Behaviour of enemy missiles
 * */
public class EnemyMissile : IMissile {

	protected override void OnTriggerEnter2D(Collider2D c){
		if (c.tag == target) {
			c.GetComponentInParent<State>().getDamage(damage);
			Destroy ();
		}
	}

}
