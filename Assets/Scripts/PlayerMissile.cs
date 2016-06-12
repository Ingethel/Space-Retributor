using UnityEngine;
using System.Collections;

/**
 * Behaviour of player's missiles
 * */
public class PlayerMissile : IMissile {

	protected override void OnTriggerEnter2D(Collider2D c){
		if (c.tag == "Enemy") {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<HighScoreManager> ().increaseHighScore (10);
			c.GetComponentInParent<State>().getDamage(damage);
			Destroy ();
		} else if (c.tag == "EnemyPrecusionArea") {
			EnemyBehaviour3 b = c.GetComponentInParent<EnemyBehaviour3>();
			if(b != null)
				b.StartEvasion();
		}
	}
}
