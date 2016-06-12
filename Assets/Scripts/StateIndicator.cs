using UnityEngine;
using System.Collections;

/**
 * Indicators for player status
 * */
public class StateIndicator : MonoBehaviour {

	/**
	 * list of states of indicator
	 * */
	public Sprite[] barStates;

	// renderer
	SpriteRenderer currentState;

	void Start () {
		currentState = GetComponent<SpriteRenderer> ();
	}

	/**
	 * update renderer for correct state indicator
	 * */
	public void setState (int index) {
		if (index < 0)
			index = 0;
		else if (index > barStates.Length - 1)
			index = barStates.Length - 1;

		currentState.sprite = barStates [index];
	}

}
