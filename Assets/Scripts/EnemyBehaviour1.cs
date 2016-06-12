using UnityEngine;
using System.Collections;

/**
 * Enemy behaviour level 1
 * Standard fire pattern
 * */
public class EnemyBehaviour1 : IEnemyBehaviour {

	public override void behave(){
		Fire (frequency);
	}
}
