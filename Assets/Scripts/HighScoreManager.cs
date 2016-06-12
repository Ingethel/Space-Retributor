using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Score Manager to handle current score and save it when game ends
 * */
public class HighScoreManager : MonoBehaviour {
	
	/**
	 * Displayable score
	 * */

	public Text scoreText;
	// score
	int highScore;

	EnemyDifficulty enemy;
	// difficulty thresholds to increase enemy AI behaviour when reached
	int[] diffs =  new int[3] {100, 500, 1000};

	int index = 0;

	int[] _scores = new int[5];
	int[] _efforts = new int[5];

	string[] _scoreNames = new string[5]{"Score1", "Score2", "Score3", "Score4", "Score5"};
	string[] _effortNames = new string[5]{"Effort1", "Effort2", "Effort3", "Effort4", "Effort5"};
	int currentEffort;

	void Start(){
		readScore ();
		enemy = GameObject.FindGameObjectWithTag ("EnemyManager").GetComponent<EnemyDifficulty> ();
		highScore = 0;
	}

	/**
	 * reads current highscores and number of games played
	 * */
	void readScore(){
		for (int i = 0; i < 5; i++) {
			_scores[i] = PlayerPrefs.GetInt(_scoreNames[i]);
			_efforts[i] = PlayerPrefs.GetInt(_effortNames[i]);
		}
		currentEffort = PlayerPrefs.GetInt ("CurrentEffort") + 1;
		PlayerPrefs.SetInt ("CurrentEffort", currentEffort);
	}

	void Update () {
		if (GetComponent<PlayerManager>().getState()) {
			scoreText.text = highScore.ToString();
		}
	}

	/**
	 * Updates current highscore
	 * */
	public void increaseHighScore(int h){
		if (!enemy.Engaged ())
			enemy.setEngaged ();
		highScore += h;
		if (index < enemy.getMaxDiff ()) {
			if (highScore >= diffs [index]) {
				index++;
				enemy.setDiff(index + 1);
			}
		}
	}

	public int getHighScore(){
		return highScore;
	}

	/**
	 * Sort highscores and save the top 5
	 * */
	public void saveHighScore(){
		int index = 0;
		int indexFound = 0;
		bool found = false;
		while (index < 5) {
			if (!found) {
				if (highScore > _scores[index]) {
					indexFound = index;
					found = true;
					break;
				}
			}
			index++;
		}
		if (found) {
			for(int i = 4; i > indexFound; i--){
				PlayerPrefs.SetInt(_scoreNames[i], _scores[i-1]);
				PlayerPrefs.SetInt(_effortNames[i], _efforts[i-1]);
			}
			PlayerPrefs.SetInt(_scoreNames[indexFound], highScore);
			PlayerPrefs.SetInt(_effortNames[indexFound], currentEffort);
		}
	}

}