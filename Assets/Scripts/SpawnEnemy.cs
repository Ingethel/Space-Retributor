using UnityEngine;
using System.Collections;

/**
 * Enemy spawn manager
 * */
public class SpawnEnemy : MonoBehaviour {

	/**
	 * enemy to spawn
	 * */
	public GameObject enemy;
	public GameObject enemyMissile;

	// list of spawn points
	GameObject[] spawnPoints;

	/**
	 * spawn time intervals
	 * */
	public float spawnTime;

	float lastSpawnTime;

	// state of game
	GameState gameState;

	PoolManager pool;

	void Start () {
		gameState = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameState> ();
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		lastSpawnTime = Time.time;
		pool = FindObjectOfType<PoolManager> ();
		pool.CreatePool (enemy, 15);
		pool.CreatePool (enemyMissile, 20);
	}
	
	void Update () {
		// if game playable spawn enemies
		if (gameState.getState() == 0) {
			if (Time.time - lastSpawnTime > spawnTime) {
				lastSpawnTime = Time.time;
				pool.SpawnObject(enemy, spawnPoints [Random.Range (0, spawnPoints.Length)].GetComponent<Transform> ().position);
			}
		}
	}

}
