using UnityEngine;
using System.Collections;

public class bossFight : MonoBehaviour {

	public GameObject boss;
	GameObject bossInstance;
	Vector3 spawnLocation = new Vector3(0f,13f,1f);

	void Start () {
		spawnBoss ();
	}
	
	void Update () {
	
	}

	public void spawnBoss(){
		bossInstance = (GameObject)Instantiate(boss, spawnLocation, Quaternion.identity);
	}

}
