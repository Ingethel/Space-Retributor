using UnityEngine;
using System.Collections;

public class GunnerState : State {
	public ParticleSystem explosion;

	protected override void Awake ()
	{
		base.Awake ();
		if(explosion != null)
			explosion.enableEmission = false;
	}

	protected override void onDeath ()
	{
		FindObjectOfType<HighScoreManager> ().increaseHighScore (500);
		if(explosion != null)
			explosion.enableEmission = true;
	}

	public override void WakeUp(){
		base.WakeUp();
		GetComponent<BoxCollider2D> ().enabled = true;
	}
}
