using UnityEngine;
using System.Collections;

/**
 * Basic implementation of state for characters
 * to be extended from child classes
 * */
public class State : IPoolObject {

	public int health;
	public float anim_time;
	protected bool lives;
	BoxCollider2D[] colliders;
	Sprite sprite;

	protected override void Awake(){
		base.Awake ();
		sprite = GetComponent<SpriteRenderer> ().sprite;
	}

	public override void Spawn(Vector3 position, Quaternion rotation, Vector3 scale){
		if (ready) {
			ready = false;
			colliders = GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D c in colliders)
				c.enabled = true;
			lives = true;
			GetComponent<SpriteRenderer> ().sprite = sprite;
			base.Spawn (position, rotation, scale);
		}
	}

	void FixedUpdate () {
		if (health <= 0) {
			if(lives){
				lives = false;
				onDeath();
				StartCoroutine("Dead");
			}
		}
	}

	protected virtual void onDeath (){
	}

	protected IEnumerator Dead(){
		foreach (BoxCollider2D c in colliders)
			c.enabled = false;

		GetComponent<Animator>().SetTrigger("isDead");
		yield return new WaitForSeconds (anim_time);
		Destroy ();
	}

	public virtual void getDamage (int d){
		if (d > 0) {
			health -= d;
		}
	}

	public bool isAlive(){
		return lives;
	}
}
