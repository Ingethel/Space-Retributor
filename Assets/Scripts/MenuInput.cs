using UnityEngine;
using System.Collections;
#if UNITY_EDITOR 
using UnityEditor;
#endif

/**
 * Input handler for Menu
 * Click/Touch full support
 * Minimal Keybord input
 * */
public class MenuInput : MonoBehaviour {

	// UI screens
	GameObject menu;
	GameObject plot;
	GameObject scores;

	// Menu buttons
	GameObject NewGameButton;
	GameObject HighScoreButton;
	GameObject StoryButton;
	GameObject ExitButton;

	void Start(){
		// pause time until assignment is complete
		Time.timeScale = 0;
		menu = GameObject.FindGameObjectWithTag ("Menu");
		menu.SetActive(true);

		NewGameButton = GameObject.FindGameObjectWithTag("NewGame");
		HighScoreButton = GameObject.FindGameObjectWithTag("HighScore");
		StoryButton = GameObject.FindGameObjectWithTag("Story");
		ExitButton = GameObject.FindGameObjectWithTag("Exit");

		plot = GameObject.FindGameObjectWithTag ("Plot");
		plot.SetActive(false);
		scores = GameObject.FindGameObjectWithTag ("HighScoreScreen");
		scores.SetActive(false);
		Time.timeScale = 1;
	}

	void Update () {
		if (clickInput ()) {
		} else if (keyInput ()) {
		}
	}
	
	bool clickInput(){
		bool flag = false;
		if (Input.GetMouseButtonDown (0)) {
			Collider2D _collider = Physics2D.OverlapPoint(Input.mousePosition);
			if (_collider != null) {
				flag = true;
				if(menu.activeSelf){
					// LAUNCH GAME
					if(_collider.tag == NewGameButton.GetComponent<Collider2D>().tag){
						StartCoroutine(NewGame());
					}
					// SHOW HIGHSCORES
					else if(_collider.tag == HighScoreButton.GetComponent<Collider2D>().tag){
						StartCoroutine(HighScore());
					}
					// SHOW PLOT
					else if(_collider.tag == StoryButton.GetComponent<Collider2D>().tag){
						StartCoroutine(Story());
					}
					// EXIT
					else if(_collider.tag == ExitButton.GetComponent<Collider2D>().tag){
						StartCoroutine(Exit());
					}
				// RETURN TO MENU
				} else {
					plot.SetActive(false);
					scores.SetActive(false);
					menu.SetActive(true);
				}

			}
		}
		return flag;
	}
	
	bool keyInput(){
		bool flag = false;
		if (Input.GetKeyDown(KeyCode.Escape)){
			if(menu.activeSelf){
				Exit();
			} else {
				plot.SetActive(false);
				scores.SetActive(false);
				menu.SetActive(true);
			}
		}
		return flag;
	}

	/**
	 * Animate button and launch game
	 * */
	IEnumerator NewGame(){
		NewGameButton.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		NewGameButton.GetComponent<PanelPressed>().setPressed(false);

		Application.LoadLevel(1);
	}
	
	/**
	 * Animate button and launch highscore screen
	 * */
	IEnumerator HighScore(){
		HighScoreButton.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		HighScoreButton.GetComponent<PanelPressed>().setPressed(false);

		menu.SetActive(false);
		scores.SetActive(true);
		scores.GetComponent<HighScoreDisplay>().Display();
	}
	
	/**
	 * Animate button and launch story screen
	 * */
	IEnumerator Story(){
		StoryButton.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		StoryButton.GetComponent<PanelPressed>().setPressed(false);

		menu.SetActive(false);
		plot.SetActive(true);
	}
	
	/**
	 * Animate button and exit
	 * Support quit on Editor
	 * */
	IEnumerator Exit(){
		ExitButton.GetComponent<PanelPressed>().setPressed(true);
		yield return new WaitForSeconds (0.2f);
		ExitButton.GetComponent<PanelPressed>().setPressed(false);

		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
