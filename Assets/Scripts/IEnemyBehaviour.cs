using UnityEngine;
using System.Collections;

/**
 * Basic implementation of enemy behaviour
 * To be extended from child classes
 * */
public class IEnemyBehaviour : MonoBehaviour {

	/**
	 * object to target
	 * */
	protected GameObject target;

	/**
	 * missiles of enemy
	 * */
	protected GameObject missile;
	Vector3 missileSize = new Vector3(0.05f, 0.05f, 0.1f);

	/**
	 * fire frequency
	 * */
	protected float frequency = 1f;
	float lastHit = -10f;

	// state of game
	protected GameState gameState;
	
	// gravity pools used for basic movement
	protected GravityPool gravity;

	protected Rigidbody2D body;

	PoolManager pool;

	protected void Start(){
		body = GetComponent<Rigidbody2D> ();
		body.WakeUp();
		gravity = GetComponent<GravityPool> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		missile = Resources.Load ("EnemyMissile") as GameObject;
		pool = PoolManager.instance;
		gravity.enabled = true;
	}

	/**
	 * behaviour implentation
	 * */
	public virtual void behave(){
	}

	/**
	 * Basic fire mechanic based on time intervals
	 * */
	protected bool Fire(float freq){
		bool flag = false;
		if(onScreen()){
			float tick = Time.time;
			if (tick - lastHit > freq) {
				lastHit = tick;
				pool.SpawnObject(missile, transform.position, missileSize);
				flag = true;
			}
		}
		return flag;
	}

	bool onScreen(){
		return (transform.position.x < 3 && transform.position.x > -3 && transform.position.y > 0 && transform.position.y < 8);
	}
}
