using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Display current highscores
 * */
public class HighScoreDisplay : MonoBehaviour{

	/**
	 * high scores
	 * */
	public Text[] Scores = new Text[5];
	/**
	 * efforts where the scores occured
	 * */
	public Text[] EffortNumber = new Text[5];

	int[] _scores = new int[5];
	int[] _efforts = new int[5];

	// labels to retrieve from saved files
	string[] _scoreNames = new string[5]{"Score1", "Score2", "Score3", "Score4", "Score5"};
	string[] _effortNames = new string[5]{"Effort1", "Effort2", "Effort3", "Effort4", "Effort5"};

	private static int versionID = 2;

	void Start(){
		checkUpdate ();
	}

	/**
	 * Display Scores
	 * */
	public void Display () {
		for (int i = 0; i < 5; i++) {
			_scores[i] = PlayerPrefs.GetInt(_scoreNames[i]);
			_efforts[i] = PlayerPrefs.GetInt(_effortNames[i]);
		}
		for (int i = 0; i < 5; i++) {
			Scores[i].text = _scores[i] > 0 ? _scores[i].ToString() : "...";
			EffortNumber[i].text = _efforts[i] > 0 ? _efforts[i].ToString() : "...";
		}
	}

	private void checkUpdate(){
		if (PlayerPrefs.GetInt ("VersionID") != versionID) {
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("VersionID", versionID);

		}
	}

}
