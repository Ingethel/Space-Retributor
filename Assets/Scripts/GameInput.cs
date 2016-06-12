using UnityEngine;
using System.Collections;

/**
 * Input handler for game level
 * Keybord input for basic actions
 * Click/Touch for full range of actions
 * */
public class GameInput : MonoBehaviour {

	// UI screens for different game statesx
	GameObject gameScreen;
	GameObject endScreen;
	GameObject menuScreen;

	PlayerManager player;

	GameState gameState;

	void Start () {
		// pause time until assignmens are complete
		Time.timeScale = 0;
		player = GetComponent<PlayerManager> ();
		gameScreen = GameObject.FindGameObjectWithTag ("GameScreen");
		gameScreen.SetActive (true);
		endScreen = GameObject.FindGameObjectWithTag ("EndScreen");
		endScreen.SetActive (false);
		menuScreen = GameObject.FindGameObjectWithTag ("MenuScreen");
		menuScreen.SetActive (false);
		gameState = GetComponent<GameState> ();
		Time.timeScale = 1;
	}

	void Update () {
		// handle different input types
		if (clickInput ()) {
		} else if (keyInput ()) {
		}
	}

	/**
	 * Keybord Input Handler
	 * */
	bool keyInput(){
		bool flag = false;
		if (gameState.getState() == 0) {
			if (Input.GetKey (KeyCode.A) || 
			    Input.GetKey (KeyCode.LeftArrow)) {
				player.setVelocity(-1);
				flag = true;
			} else if (Input.GetKey (KeyCode.D) || 
			           Input.GetKey (KeyCode.RightArrow)) {
				player.setVelocity(1);
				flag = true;
			}
			if (Input.GetKey (KeyCode.Space)) {
				player.Fire();
				flag = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameState.getState () == 0){
				StartCoroutine(LaunchMenuScreen());
			} else if (gameState.getState () == 1){
				StartCoroutine(Resume());
			} else if (gameState.getState () == 2){
				StartCoroutine(Exit ());
			}
			flag = true;
		}
		return flag;
	}
	
	/**
	 * Click/Touch Input Handler
	 * */
	bool clickInput(){
		bool flag = false;
		if (gameState.getState () == 0) {
			if (Input.GetMouseButton (0)) {
				flag = true;
				Collider2D _collider = Physics2D.OverlapPoint (Input.mousePosition);
				// IN GAME SCREEN
				if (_collider != null) {
					if (_collider.tag == GameObject.FindGameObjectWithTag ("Menu").GetComponent<Collider2D> ().tag) {
						StartCoroutine(LaunchMenuScreen ());
					}
				// PLAYER MOVEMENT
				} else {
					Vector3 mousePosition;
					mousePosition = Input.mousePosition;
					mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
					player.followMouse (mousePosition);
					player.Fire ();
				}
			}
		} else {
			if(Input.GetMouseButtonDown(0)){
				flag = true;
				Collider2D _collider = Physics2D.OverlapPoint(Input.mousePosition);
				if (_collider != null) {
					// PAUSE SCREEN
					if(gameState.getState () == 1){
						if(_collider.tag == GameObject.FindGameObjectWithTag("Resume").GetComponent<Collider2D>().tag){
							StartCoroutine(Resume ());
						}else if(_collider.tag == GameObject.FindGameObjectWithTag("Exit").GetComponent<Collider2D>().tag){
							StartCoroutine(Exit ());
						}
					// EXIT SCREEN
					}else if(gameState.getState () == 2){
						if(_collider.tag == GameObject.FindGameObjectWithTag("Exit").GetComponent<Collider2D>().tag){
							StartCoroutine(Exit ());
						}else if(_collider.tag == GameObject.FindGameObjectWithTag("Replay").GetComponent<Collider2D>().tag){
							StartCoroutine(Restart ());
						}
					}
				}
			}
		}
		return flag;
	}

	/**
	 * Pause/Unpause time
	 * */
	void Pause(){
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	/**
	 * Animate menu button and then launch menu screen
	 * */
	public IEnumerator LaunchMenuScreen(){
		gameState.setPaused();

		GameObject _button = GameObject.FindGameObjectWithTag ("Menu");
		_button.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		_button.GetComponent<PanelPressed>().setPressed(false);

		gameScreen.SetActive (false);
		Pause ();
		menuScreen.SetActive (true);
	}

	/**
	 * Wait for player's death animation and then launch end game screen
	 * */
	public IEnumerator LaunchEndScreen(){
		gameState.setEndOfGame ();

		gameScreen.SetActive (false);
		yield return new WaitForSeconds (0.8f);
		Pause ();
		endScreen.SetActive (true);
	}

	/**
	 * Animate resume button and then resume game
	 * */
	public IEnumerator Resume(){
		Pause ();

		GameObject _button = GameObject.FindGameObjectWithTag ("Resume");
		_button.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		_button.GetComponent<PanelPressed>().setPressed(false);

		gameState.setPlay();
		menuScreen.SetActive (false);
		gameScreen.SetActive (true);
	}

	/**
	 * Animate exit button and then go to menu
	 * */
	public IEnumerator Exit(){
		Pause ();

		GameObject _button = GameObject.FindGameObjectWithTag ("Exit");
		_button.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		_button.GetComponent<PanelPressed>().setPressed(false);

		GetComponent<HighScoreManager> ().saveHighScore ();
		Application.LoadLevel(0);
	}

	/**
	 * Animate restart button and then restart level
	 * */
	public IEnumerator Restart(){
		Pause ();

		GameObject _button = GameObject.FindGameObjectWithTag ("Replay");
		_button.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		_button.GetComponent<PanelPressed>().setPressed(false);

		GetComponent<HighScoreManager> ().saveHighScore ();
		Application.LoadLevel(Application.loadedLevel);
	}

	/**
	 * Handler for interrupts by phone
	 * */
	void OnApplicationPause(bool pauseStatus) {
		if (pauseStatus && !endScreen.activeSelf) {
			LaunchMenuScreen();
		}
	}
}
