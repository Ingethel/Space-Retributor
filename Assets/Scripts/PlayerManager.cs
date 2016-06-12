using UnityEngine;
using System.Collections;

/**
 * Wrapper for basic player interactions handled by game state
 * */
public class PlayerManager : MonoBehaviour {

	private bool state;
	PlayerController player_controller;
	public GameObject player;

	void Start(){
		state = true;
		player.GetComponent<PlayerState> ().Spawn (Vector3.zero, Quaternion.identity, Vector3.one);
		player_controller = player.GetComponent<PlayerController> ();
	}

	public bool getState(){
		return state;
	}

	public void changeState(){
		state = false;
		StartCoroutine(GetComponent<GameInput> ().LaunchEndScreen ());
	}

	public void setVelocity(int i){
		if (state) {
			player_controller.setVelocity(i);
		}
	}

	public void Fire(){
		if (state) {
			player_controller.Fire();
		}
	}

	public void setActive(bool flag){
		if (state) {
			player.SetActive(flag);
		}
	}

	public void followMouse(Vector3 pos){
		if (state) {
			player_controller.followMouse(pos);
		}
	}

}
