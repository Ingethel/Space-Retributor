using UnityEngine;
using System.Collections;

/**
 * State implementation of player
 * */
public class PlayerState : State {

	public int armor;
	int maxArmor;
	PlayerManager manager;

	public override void Spawn (Vector3 position, Quaternion rotation, Vector3 scale) {
		maxArmor = armor;
		if(maxArmor > 0)
			StartCoroutine (ReplenishArmor());
		manager = FindObjectOfType<PlayerManager> ();
		base.Spawn(position, rotation, scale);
	}

	IEnumerator ReplenishArmor(){
		while (true) {
			if(armor == 0){
				yield return new WaitForSeconds (5f);
				if(lives)
					armor = maxArmor;
				else break;
			}
			yield return new WaitForSeconds (0.5f);
		}
	}

	public override void getDamage(int d){
		if (armor > 0) {
			int temp = armor;
			armor -= d;
			d -= temp;
			if (armor < 0)
				armor = 0;
		}
		base.getDamage (d);
	}

	protected override void onDeath ()
	{
		manager.changeState();
	}
	
}
