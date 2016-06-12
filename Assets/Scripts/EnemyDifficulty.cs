using UnityEngine;
using System.Collections;

/**
 * Sets enemy behaviour based on current difficulty.
 * Difficulty is adjusted based on player's curretn score
 * */
public class EnemyDifficulty : MonoBehaviour {

	bool engage = false;

	int behaviourLevel = 1;
	int maxDifficulty = 3;

	/**
	 * Set enemies to engaged status
	 * */
	public void setEngaged(){
		engage = true;
	}

	/**
	 * Engaged status
	 * */
	public bool Engaged(){
		return engage;
	}

	/**
	 * Set enemy difficulty
	 * */
	public void setDiff(int level){
		behaviourLevel = level;
	}

	/**
	 * Enemy difficulty
	 * */
	public int getDiff(){
		return behaviourLevel;
	}

	/**
	 * Set enemy difficulty with random factors based on game state
	 * */
	public int setNewEnemyDifficulty(){
		if (behaviourLevel == 1) {
			return 1;
		} else if (behaviourLevel == 2) {
			if (Random.value < 0.5f)
				return 1;
			else
				return 2;
		} else if (behaviourLevel == 3) {
			float value = Random.value;
			if(value < 0.2)
				return 1;
			else if (value < 0.6f)
				return 2;
			else 
				return 3;
		} else {
			if(Random.value < 0.4)
				return 2;
			else 
				return 3;
		}
	}

	/**
	 * Maximum difficulty
	 * */
	public int getMaxDiff(){
		return maxDifficulty;
	}
}
