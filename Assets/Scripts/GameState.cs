using UnityEngine;
using System.Collections;

/**
 * Denotes game state
 * */
public class GameState : MonoBehaviour {

	// current state
	private int state;

	void Start () {
		state = 0;
	}

	public void setPlay(){
		state = 0;
	}

	public void setPaused(){
		state = 1;
	}

	public void setEndOfGame(){
		state = 2;
	}

	/**
	 *  0 = play, 1 = pause, 2 = end
	 * */
	public int getState(){
		return state;
	}

}
