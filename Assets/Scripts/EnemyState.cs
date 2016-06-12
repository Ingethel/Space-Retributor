using UnityEngine;
using System.Collections;

/**
 * State behaviours of enemies
 * */
public class EnemyState : State {
	
	PowerUpManager powerUpManager;
	EnemyFire behaviour;
	
	public override void Spawn (Vector3 position, Quaternion rotation, Vector3 scale) {
		powerUpManager = GameObject.FindGameObjectWithTag ("PowerUpManager").GetComponent<PowerUpManager> ();
		behaviour = GetComponent<EnemyFire> ();
		behaviour.onSpawn ();
		base.Spawn (position, rotation, scale);
	}

	protected override void onDeath ()
	{
		powerUpManager.SpawnPowerUp (transform.position);
		Destroy (GetComponent<IEnemyBehaviour>());
	}
}
