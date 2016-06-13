using UnityEngine;
using System.Collections;

public class GunnerState : State {
	public ParticleSystem explosion;

	protected override void Awake ()
	{
		base.Awake ();
		lives = true;
		explosion.enableEmission = false;
	}

	protected override void onDeath ()
	{
		explosion.enableEmission = true;
	}
}
