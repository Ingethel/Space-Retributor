using UnityEngine;
using System.Collections;

/**
 * Power up that increases the fire frequency of the target
 * */
public class DamagePowerUp : IPowerUp {

	public override void Behaviour ()
	{
		_target.GetComponent<PlayerController>().boostFireSpeed();
		base.Behaviour ();
	}
}
