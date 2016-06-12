using UnityEngine;
using System.Collections;

/**
 * sets state and behaviour for enemy based on difficulty level
 * */
public class EnemyFire : MonoBehaviour {

	// state of game
	GameState gameState;
	
	// behaviour attributes
	int AILevel = 0;
	EnemyDifficulty enemyManager;
	IEnemyBehaviour enemyBehaviour;
	
	public void onSpawn(){
		enemyManager = GameObject.FindGameObjectWithTag ("EnemyManager").GetComponent<EnemyDifficulty> ();
		gameState = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameState> ();
		AILevel = enemyManager.setNewEnemyDifficulty ();
		GetComponent<State> ().health = AILevel;
		setBehaviour ();
	}

	void setBehaviour(){
		if (AILevel == 1) {
			enemyBehaviour = gameObject.AddComponent<EnemyBehaviour1> ();
		} else if (AILevel == 2) {
			enemyBehaviour = gameObject.AddComponent<EnemyBehaviour3> ();
		} else if (AILevel == 3) {
			enemyBehaviour = gameObject.AddComponent<EnemyBehaviour2> ();
		}
	}

	/**
	 * checks game state and executes respective behaviour based on intelligence
	 * */
	void FixedUpdate () {
		if (gameState.getState() == 0) {
			if (GetComponent<State> ().isAlive ()) {
				if(enemyManager.Engaged()){
					enemyBehaviour.behave();
				} 
			}
		}
	}

}
