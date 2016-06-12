using UnityEngine;
using System.Collections;

/**
 * Power up manager
 * */
public class PowerUpManager : MonoBehaviour {

	/**
	 * List of power ups
	 * */
	public GameObject[] powerUps;
	
	int powerIndicator;

	[Range(0, 100)]
	public int powerUpChanceOnDeath;

	/**
	 * Try and Spawn Random power up
	 * */
	public void SpawnPowerUp(Vector3 position){
		if (Random.Range (0, 100) < powerUpChanceOnDeath) {
			powerIndicator = (int)Random.Range(0,powerUps.Length);
			Instantiate (powerUps [powerIndicator], position, Quaternion.identity);
		}
	}
	
}