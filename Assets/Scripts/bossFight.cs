using UnityEngine;
using System.Collections;

public class BossFight : MonoBehaviour {

	public GameObject boss;
	bool bossSpawned;
	HighScoreManager score;
	public int scoreTrigger;

	void Start () {
		bossSpawned = false;
		score = FindObjectOfType<HighScoreManager> ();
	}
	
	void Update () {
		if (!bossSpawned) {
			if (score.getHighScore () >= scoreTrigger) {
				spawnBoss();
			}
		}
	}

	public void spawnBoss(){
		bossSpawned = true;
		Instantiate(boss, Vector3.zero, Quaternion.identity);
	}

}
