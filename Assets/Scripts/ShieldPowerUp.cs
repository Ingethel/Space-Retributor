using UnityEngine;
using System.Collections;

/**
 * Power up that renders the player invulnerable for a period of time
 * */
public class ShieldPowerUp : IPowerUp {
	
	public override void Behaviour ()
	{
		_target.GetComponent<PlayerController>().setInvulnerable();
		base.Behaviour ();
	}
}
