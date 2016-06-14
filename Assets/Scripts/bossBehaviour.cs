using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {
	
	public GameObject[] weapons;

	bool waeponsDead = false;
	Animator animator;
	SpawnEnemy enemyManager;

	void Start () {
		enemyManager = FindObjectOfType<SpawnEnemy> ();
		enemyManager.bossFight = true;
		animator = GetComponent<Animator> ();
		Invoke ("WeaponsReady" , 2.5f);
	}
	
	void FixedUpdate () {
		waeponsDead = true;
		foreach (GameObject o in weapons) {
			if(o.activeInHierarchy){
				waeponsDead = false;
				break;
			}
		}
		if (waeponsDead) {
			StartCoroutine(MoveFromFight());
		}
	}

	void WeaponsReady(){
		foreach (GameObject o in weapons) {
			o.GetComponent<GunnerState>().WakeUp();
		}
	}


	IEnumerator MoveFromFight(){
		animator.SetTrigger ("Death");
		enemyManager.bossFight = false;
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
