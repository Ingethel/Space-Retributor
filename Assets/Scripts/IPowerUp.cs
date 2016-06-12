using UnityEngine;
using System.Collections;

/**
 * Basic behaviour of power ups
 * To be extended from child classes
 * */
public class IPowerUp : MonoBehaviour {

	// target tag
	public string target;

	protected GameObject _target;

	// collider of power up
	BoxCollider2D _collider;
	// rigid body of power up
	Rigidbody2D _body;

	// particle system for effect
	GameObject fairies;

	protected virtual void Start(){
		_collider = gameObject.GetComponent<BoxCollider2D> ();
		if (_collider == null)
			_collider = gameObject.AddComponent<BoxCollider2D> ();
		_collider.isTrigger = true;
		
		_body = gameObject.GetComponent<Rigidbody2D> ();
		if(_body == null)
			_body = gameObject.AddComponent<Rigidbody2D> ();
		_body.gravityScale = 0.2f;
		_target = GameObject.FindGameObjectWithTag (target);
		fairies = Instantiate(Resources.Load ("Fairies"), transform.position, Quaternion.identity) as GameObject;
	}

	void FixedUpdate(){
		fairies.transform.position = transform.position;
		if (transform.position.y < -2) {
			destroy ();
		}
	}

	/**
	 * behaviour of power up
	 * */
	public virtual void Behaviour(){
		destroy ();
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.tag == target) {
			Behaviour();
		}
	}

	void destroy(){
		Destroy (fairies);
		Destroy (gameObject);
	}
}
