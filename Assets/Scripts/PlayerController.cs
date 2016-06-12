using UnityEngine;
using System.Collections;

/**
 * Player Handler class for movement and power up interactions
 * */
public class PlayerController : MonoBehaviour {

	/**
	 * player's missiles
	 * */
	public GameObject missile;
	/**
	 * player's movement speed
	 * */
	public int speed;

	// player state
	StateIndicator health;
	StateIndicator armor;
	PlayerState state;

	// player velocity (direction/magnitude)
	int moveVelocity;

	// fire frequency
	float lastHit = -10f;
	float fireFrequency = 0.5f;
	float fireFrequencyBoosted = 0.2f;
	float currentFrequency;

	// boost fire -- power up
	int boostTime = 20;
	bool boosted;
	int boostFires;

	// player's vulnerability -- power up
	bool isVulnerable;
	BoxCollider2D[] colliders;

	PoolManager pool;
	Vector3 missileSize = new Vector3(0.05f, 0.05f, 0.1f);

	void Start(){
		isVulnerable = true;
		colliders = GetComponents<BoxCollider2D> ();
		boosted = false;
		boostFires = 0;
		state = GetComponent<PlayerState> ();
		health = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<StateIndicator> ();
		armor = GameObject.FindGameObjectWithTag ("ArmorBar").GetComponent<StateIndicator> ();
		currentFrequency = fireFrequency;
		pool = FindObjectOfType<PoolManager> ();
		pool.CreatePool (missile, 15);
	}

	void Update () {
		if (state.isAlive()) {
			GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (moveVelocity*speed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = 0;
		}
		health.setState(state.health);
		armor.setState(state.armor);
	}

	public void Fire(){
		float tick = Time.time;
		if (tick - lastHit > currentFrequency) {
			if(boosted){
				boostFires++;
				if(boostFires >= boostTime){
					boosted = false;
					currentFrequency = fireFrequency;
					boostFires = 0;
				}
			}

			lastHit = tick;
			pool.SpawnObject(missile, GetComponent<Transform>().position, missileSize);
		}
	}

	/**
	 * Set player velocity
	 * 
	 * Param: integer direction
	 * */
	public void setVelocity(int i){
		moveVelocity = i;
	}

	/**
	 * Order player to move to position
	 * 
	 * Param: Vector3 position to move
	 * */
	public void followMouse(Vector3 pos){
		transform.position = Vector2.Lerp(transform.position, new Vector3(pos.x, transform.position.y, transform.position.z), 0.05f);
	}

	/**
	 * Boosts fire speed of player -- power up interaction
	 * */
	public void boostFireSpeed(){
		currentFrequency = fireFrequencyBoosted;
		boostFires = 0;
		boosted = true;
	}

	/**
	 * Sets player invulnerable -- power up interaction
	 * */
	public void setInvulnerable(){
		if (isVulnerable)
			StartCoroutine (Invulnerability ());
	}

	/**
	 * Disable player colliders for 5 seconds and animate invulnerability
	 * */
	IEnumerator Invulnerability(){
		isVulnerable = false;
		foreach (BoxCollider2D c in colliders)
			c.enabled = false;
		GetComponent<Animator> ().SetBool ("isInvulnerable", true);
		yield return new WaitForSeconds (5);
		foreach (BoxCollider2D c in colliders)
			c.enabled = true;
		GetComponent<Animator> ().SetBool ("isInvulnerable", false);
		isVulnerable = true;
	}
}
