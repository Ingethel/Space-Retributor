using UnityEngine;
using System.Collections;

/**
 * Power up that maximises the health of the target
 * */
public class HealthPowerUp : IPowerUp {

	public override void Behaviour ()
	{
		_target.GetComponent<State>().health = 3;
		base.Behaviour ();
	}
}
